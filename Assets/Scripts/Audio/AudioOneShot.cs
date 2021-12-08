using UnityEngine;
using UnityEngine.UI;

namespace Menchestan
{

    namespace Audio
    {
        [RequireComponent(typeof(AudioSource))]
        public class AudioOneShot: MonoBehaviour
        {
            public AudioSource audioSource;
            private void OnEnable()
            {
                Destroy(gameObject, audioSource.clip.length);
            }
        }
    }
}