using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Backman.Client
{
    public class BackmanSettingsProvider : SettingsProvider
    {
        private const string k_settingsPath = "Assets/Backman/Resources/BackmanSettings.asset";

        private SerializedObject m_CustomSettings;
        private BackmanSettings backmanSettings;
        private Texture logoTexture;

        public BackmanSettingsProvider(string path, SettingsScope scope)
            : base(path, scope) { }

        public static BackmanSettings GetSetting()
        {
            var settings = AssetDatabase.LoadAssetAtPath<BackmanSettings>(k_settingsPath);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<BackmanSettings>();
                AssetDatabase.CreateAsset(settings, k_settingsPath);
                AssetDatabase.SaveAssets();
            }
            return settings;
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            // This function is called when the user clicks on the MyCustom element in the Settings window.
            backmanSettings = GetSetting();
            m_CustomSettings = new SerializedObject(backmanSettings);
            logoTexture = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Backman/Resources/backman_logo_black.png");
        }

        // Register the SettingsProvider
        [SettingsProvider]
        public static SettingsProvider CreateMyCustomSettingsProvider()
        {
            //check scriptable object
            if (!File.Exists(k_settingsPath))
            {
                GetSetting();
                if (!File.Exists(k_settingsPath))
                    return null;
            }

            var provider = new BackmanSettingsProvider("Project/Backman", SettingsScope.Project);
            // Automatically extract all keywords from the Styles.
            provider.keywords = GetSearchKeywordsFromPath(k_settingsPath);
            return provider;
        }

        public override async void OnGUI(string searchContext)
        {
            backmanSettings.ClientId = m_CustomSettings.FindProperty("m_clientID").stringValue;
            backmanSettings.Secret = m_CustomSettings.FindProperty("m_secret").stringValue;
            backmanSettings.Username = m_CustomSettings.FindProperty("m_username").stringValue;
            backmanSettings.Password = m_CustomSettings.FindProperty("m_password").stringValue;

            GUI.DrawTexture(new Rect(0, 0, 100, 100), logoTexture, ScaleMode.StretchToFill, true, 10.0F);
            EditorGUILayout.Space(100, true);
            EditorGUILayout.LabelField("Identity");
            EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("m_clientID"));
            EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("m_secret"));

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Developer account");
            EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("m_username"));
            EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("m_password"));

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Resources");
            EditorGUILayout.LabelField("To create resource objcet perss create button");
            if (GUILayout.Button("create"))
                await CreateResourceObjects();

            EditorUtility.SetDirty(backmanSettings);
        }

        private async Task CreateResourceObjects()
        {
            var backmanSettings = GetSetting();
            if (backmanSettings.ClientId == "") throw new System.ArgumentNullException("Client Id");
            if (backmanSettings.Secret == "") throw new System.ArgumentNullException("secret");
            if (backmanSettings.Username == "") throw new System.ArgumentNullException("Username");
            if (backmanSettings.Password == "") throw new System.ArgumentNullException("Password");

            await BackmanClient.Initial();

            if (!await BackmanClient.IdentityManager.SignIn(backmanSettings.Username, backmanSettings.Password))
                throw new System.Exception("Sign in failed.");

            if (!await BackmanClient.ResourceManager.GenerateResourceCodes(Application.dataPath + "/Backman"))
                throw new System.Exception("resource object failed.");

            Debug.Log("resource object created successfully");
            AssetDatabase.Refresh();
        }
    }
}