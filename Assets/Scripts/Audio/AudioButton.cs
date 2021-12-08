using UnityEngine;
using UnityEngine.UI;

namespace Menchestan
{

    namespace Audio
    {
        [RequireComponent(typeof(Button))]
        public class AudioButton : MonoBehaviour
        {
            private void Awake()
            {
                Button btn = GetComponent<Button>();
                if (btn != null)
                    btn.onClick.AddListener(() => AudioManager.Instance.PlayAudio(AudioType.SFX_BtnClick));
            }
        }
    }
}