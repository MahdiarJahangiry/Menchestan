using TMPro;
using UnityEngine;
using Sirenix.OdinInspector;
#if UNITY_EDITOR
using TMPro.EditorUtilities;
#endif
namespace Menchestan
{
    namespace Localization
    {
        public class LangFont
        {
            public TMP_FontAsset fontAsset;
#if UNITY_EDITOR
            [ValueDropdown("ValuesFunction")]
#endif
            public Material m_MaterialPresets;
            public float scaleFontSize;
#if UNITY_EDITOR
            /// <summary>
            /// Method to retrieve the material presets that match the currently selected font asset.
            /// </summary>
            /// 
            private Material[] ValuesFunction()
            {
                if (fontAsset == null) return null;
                Material m_TargetMaterial = fontAsset.material;
                return TMP_EditorUtility.FindMaterialReferences(fontAsset);
            }
#endif
        }
    }
}