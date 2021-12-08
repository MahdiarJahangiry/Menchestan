using UnityEngine;
using UnityEngine.UI;

namespace Menchestan
{

    namespace Audio
    {
        [RequireComponent(typeof(Toggle))]
        public class AudioToggle : MonoBehaviour
        {
            private void Awake()
            {
                Toggle toggle = GetComponent<Toggle>();
                if (toggle != null)
                    toggle.onValueChanged.AddListener((value) => { if (value) AudioManager.Instance.PlayAudio(AudioType.SFX_BtnClick); });
            }
        }
    }
}