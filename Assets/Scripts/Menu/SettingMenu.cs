using UnityEngine.UI;
using Menchestan.Audio;
using Menchestan.Localization;
namespace Menchestan
{
    namespace Menu
    {
        public class SettingMenu : SimpleMenu<SettingMenu>
        {
            public Toggle sound;
            public Toggle music;
            public Toggle farsi;
            public Toggle english;

            private void OnEnable()
            {
                music.isOn = AudioManager.Instance.SoundTrackState;

                sound.isOn = AudioManager.Instance.SfxState;

                switch (LocalizationManager.Instance.language)
                {
                    case Language.Farsi:
                        farsi.isOn = true;
                        english.isOn = false;
                        break;
                    case Language.English:
                        farsi.isOn = false;
                        english.isOn = true;
                        break;
                    default:
                        break;
                }
            }
            public void OnMusicValueChanged(bool value)
            {
                AudioManager.Instance.SoundTrackState = value;
            }
            public void OnSoundValueChanged(bool value)
            {
                AudioManager.Instance.SfxState = value;
            }
            public void OnLanguageChanged(bool value)
            {
                if (value)
                {
                    LocalizationManager.Instance.LanguageChnaged(farsi.isOn ? Language.Farsi : Language.English);
                }
            }
            public override void OnBackPressed()
            {
                Hide();
            }
        }
    }
}