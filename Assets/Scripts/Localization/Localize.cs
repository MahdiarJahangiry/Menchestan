using TMPro;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace Menchestan
{
    namespace Localization
    {
        public class Localize : MonoBehaviour
        {
            private Text texts;
            private RTLTextMeshPro rtlTMP;
            private TextMeshProUGUI tmpUGUI;
            [ValueDropdown("ValuesFunction")]
            public string identifier;
            public List<string> formatValues = new List<string>();
            private List<string> ValuesFunction()
            {
                return LocalizationManager.Instance.identifiers;
            }
            private float defaultFontSize;
            public void SetKey(string key, List<string> formatValues)
            {
                identifier = key;
                if (formatValues != null)
                {
                    this.formatValues = formatValues;
                }

                OnLanguageChanged(LocalizationManager.Instance.language);
            }

            public void SetKey(string key)
            {
                identifier = key;
                OnLanguageChanged(LocalizationManager.Instance.language);
            }
            public string GetKey()
            {
                return identifier;
            }

            private void Awake()
            {
                texts = GetComponent<Text>();
                if (texts != null)
                {
                    defaultFontSize = texts.fontSize;
                }
                rtlTMP = GetComponent<RTLTextMeshPro>();
                if (rtlTMP == null)
                    tmpUGUI = GetComponent<TextMeshProUGUI>();
                LocalizationManager.Instance.OnLanguageChanged += OnLanguageChanged;
                if (rtlTMP != null || tmpUGUI != null)
                {
                    defaultFontSize = rtlTMP.fontSize;
                    LocalizationManager.Instance.RegisterInFontPack(rtlTMP.font.GetInstanceID(), rtlTMP.fontSharedMaterial.GetInstanceID(), OnFontChanged);
                }
            }

            private void OnEnable()
            {
                OnLanguageChanged(LocalizationManager.Instance.language);
            }
            private void OnLanguageChanged(Language newLanguage)
            {
                if (identifier.Equals("None"))
                    return;

                string newText = "";
                if (LocalizationManager.Instance.identifiers.Contains(identifier))
                {
                    newText = LocalizationManager.Instance.GetContent(identifier);
                    List<object> param = new List<object>();
                    foreach (var item in formatValues)
                    {
                        if (LocalizationManager.Instance.identifiers.Contains(item))
                            param.Add(LocalizationManager.Instance.GetContent(item));
                        else
                            param.Add(item);
                    }
                    if (param.Count > 0)
                        newText = string.Format(newText, param.ToArray());
                }
                else
                {
                    newText = identifier;
                }

                SetText(newText);
            }
            public void SetText(string newText)
            {
                if (texts != null)
                {
                    texts.text = newText;
                }
                if (rtlTMP != null)
                {
                    rtlTMP.text = newText;
                }
                if (tmpUGUI != null)
                {
                    tmpUGUI.text = newText;
                }
            }
            public string GetText()
            {
                string text = string.Empty;
                if (texts != null)
                {
                    text = texts.text;
                }
                if (rtlTMP != null)
                {
                    text = rtlTMP.text;
                }
                if (tmpUGUI != null)
                {
                    text = tmpUGUI.text;
                }
                return text;
            }
            public int GetNumberOfLines()
            {
                if (texts != null)
                {
                    return texts.text.Split('\n').Length;
                }
                if (rtlTMP != null)
                {
                    return (int)(rtlTMP.preferredHeight / rtlTMP.fontSize);
                }
                if (tmpUGUI != null)
                {
                    return (int)(tmpUGUI.preferredHeight / tmpUGUI.fontSize);
                }
                return 0;
            }
            public void OnFontChanged(LangFont newFontConfig)
            {
                rtlTMP.font = newFontConfig.fontAsset;
                rtlTMP.fontMaterial = newFontConfig.m_MaterialPresets;
                if (newFontConfig.scaleFontSize != 0)
                    rtlTMP.fontSize = defaultFontSize * newFontConfig.scaleFontSize;
            }
            private void OnDestroy()
            {
                LocalizationManager.Instance.OnLanguageChanged -= OnLanguageChanged;
            }
        }
    }
}