using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using Menchestan.Server.Model;
using Menchestan.IO;
using System.Linq;

namespace Menchestan
{
    namespace Localization
    {
        public class LocalizationManager : SerializedMonoBehaviour
        {
            private static LocalizationManager instance;
            public static LocalizationManager Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<LocalizationManager>();
                        if (instance == null)
                        {
                            instance = new GameObject("LocalizationManager", typeof(LocalizationManager)).AddComponent<LocalizationManager>();
                        }
                        instance.isInit = false;
                        instance.Initialize(0);
                    }
                    return instance;
                }
            }
            private LocalizeCollection localizes = new LocalizeCollection();
            private int sVersion;
            private readonly string fileName = "localization.txt";
            public bool upToDate => localizes.version >= sVersion;

            private readonly Dictionary<Language, Dictionary<string, string>> content = new Dictionary<Language, Dictionary<string, string>>();
            public List<LangFontDesign> fontConfigs = new List<LangFontDesign>();
            private List<Language> languages = new List<Language>();
            public List<string> identifiers = new List<string>();
            public Action<Language> OnLanguageChanged;
            public Language language;
            private bool isInit;
            public bool isRTL => GetContent("Direction").Equals("RTL");

            [Button]
            public void Reset()
            {
                instance = null;
                Initialize(0);
            }
            public void Initialize(int sVersion)
            {
                this.sVersion = sVersion;

                if (!isInit || !upToDate)
                {
                    isInit = true;
                    content.Clear();
                    localizes = new LocalizeCollection();
                    languages.Clear();
                    identifiers.Clear();
                    OnLanguageChanged = null;
                    OnLanguageChanged += (newLanguage) => language = newLanguage;
                    if (DataIO.IsExist(fileName))
                    {
                        localizes = DataIO.FromJson<LocalizeCollection>(fileName);
                    }
                    else
                    {
                        var dataStr = Resources.Load<TextAsset>("Offline/localization") as TextAsset;
                        localizes = JsonUtility.FromJson<LocalizeCollection>(dataStr.text);
                    }
                    foreach (var item in localizes.items)
                    {
                        List<string> lineData = item.value.ToList();
                        lineData.Insert(0, item.key);
                        AddLine(lineData);
                    }
                    language = (Language)Enum.Parse(typeof(Language), PlayerPrefs.GetString("languageState", Language.Farsi.ToString()));
                    UpdateLocalize();
                    OnLanguageChanged(language);
                }
            }
            public void UpdateLocalize()
            {
                if (!upToDate)
                {
                    Server.ServerKit.Instance.GetLocalization(localizes.version, (status, response, message, code) =>
                    {
                        if (status)
                        {
                            localizes.version = sVersion;
                            foreach (var item in response.items)
                            {
                                int index = localizes.items.FindIndex(i => i.key == item.key);
                                if (index == -1)
                                {
                                    localizes.items.Add(item);
                                }
                                else
                                {
                                    localizes.items[index] = item;
                                }
                            }
                            DataIO.ToJson(fileName, localizes);
                            isInit = false;
                            Initialize(sVersion);
                        }
                    });
                }
            }
            public bool RegisterInFontPack(int fontAssetID, int fontMaterialID, Action<LangFont> OnFontChanged)
            {
                foreach (var item in fontConfigs)
                {
                    foreach (var lang in languages)
                    {
                        if (item.langFontPacks[lang].fontAsset.instanceID == fontAssetID && item.langFontPacks[lang].m_MaterialPresets.GetInstanceID() == fontMaterialID)
                        {
                            item.OnLanguageChanged += OnFontChanged;
                            if (lang != language)
                                OnFontChanged(item.langFontPacks[language]);
                            return true;
                        }
                    }
                }
                return false;
            }
            public string GetContent(string identifier)
            {
                if (content[language].ContainsKey(identifier))
                {
                    return content[language][identifier];
                }
                else
                {
                    DebugX.Warning("Localization {0} not found in csv file list", identifier);
                    return "* " + identifier + " *";
                }
            }

            public void LanguageChnaged(Language newLanguage)
            {
                language = newLanguage;
                PlayerPrefs.SetString("languageState", language.ToString());
                OnLanguageChanged?.Invoke(language);
                foreach (var item in fontConfigs)
                {
                    item.OnLanguageChanged?.Invoke(item.langFontPacks[language]);
                }
            }
            private void AddLine(List<string> line)
            {
                if (line != null)
                {
                    if (line.Count > 0)
                    {
                        if (line[0] == "Language")
                        {
                            AddLanguages(line);
                        }
                        else
                        {
                            AddContent(line);
                        }
                    }
                }
            }
            private void AddLanguages(List<string> line)
            {
                for (int i = 1; i < line.Count; i++)
                {
                    Language newLanguage = (Language)Enum.Parse(typeof(Language), line[i]);
                    content[newLanguage] = new Dictionary<string, string>();
                    languages.Add(newLanguage);
                }
            }
            private void AddContent(List<string> line)
            {
                for (int i = 0; i < languages.Count; i++)
                {
                    if (i < line.Count - 1)
                    {
                        if (i == 0)
                            identifiers.Add(line[0]);
                        content[languages[i]].Add(line[0], line[i + 1]);
                    }
                }
            }
            //private void LoadFromCSV(string file_contents)
            //{
            //    int file_length = file_contents.Length;

            //    // read char by char and when a , or \n, perform appropriate action
            //    int cur_file_index = 0; // index in the file
            //    List<string> cur_line = new List<string>(); // current line of data
            //    System.Text.StringBuilder cur_item = new StringBuilder("");
            //    bool inside_quotes = false; // managing quotes
            //    while (cur_file_index < file_length)
            //    {
            //        char c = file_contents[cur_file_index++];

            //        switch (c)
            //        {
            //            case '"':
            //                if (!inside_quotes)
            //                {
            //                    inside_quotes = true;
            //                }
            //                else
            //                {
            //                    if (cur_file_index == file_length)
            //                    {
            //                        // end of file
            //                        inside_quotes = false;
            //                        goto case '\n';
            //                    }
            //                    else if (file_contents[cur_file_index] == '"')
            //                    {
            //                        // double quote, save one
            //                        cur_item.Append("\"");
            //                        cur_file_index++;
            //                    }
            //                    else
            //                    {
            //                        // leaving quotes section
            //                        inside_quotes = false;
            //                    }
            //                }
            //                break;
            //            case '\r':
            //                // ignore it completely
            //                break;
            //            case ',':
            //                goto case '\n';
            //            case '\n':
            //                if (inside_quotes)
            //                {
            //                    // inside quotes, this characters must be included
            //                    cur_item.Append(c);
            //                }
            //                else
            //                {
            //                    // end of current item
            //                    cur_line.Add(cur_item.ToString());
            //                    cur_item.Length = 0;
            //                    if (c == '\n' || cur_file_index == file_length)
            //                    {
            //                        // also end of line, call line reader
            //                        AddLine(cur_line);
            //                        cur_line.Clear();
            //                    }
            //                }
            //                break;
            //            default:
            //                // other cases, add char
            //                cur_item.Append(c);
            //                break;
            //        }
            //    }
            //}
        }
    }
}