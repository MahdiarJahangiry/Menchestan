using RTLTMPro;
using Menchestan.Localization;
using Menchestan.Server.Model;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Menchestan
{
    namespace Menu
    {
        public class ProfileMenu : SimpleMenu<ProfileMenu>
        {
            public Image ring;
            public Image icon;
            public List<Image> gems;
            public Localize winCont;
            public Localize loseCont;
            public RTLTextMeshPro userName;
            private void OnEnable()
            {
                UserModel playerData = new UserModel();
                if (GameManager.Instance.isOnline)
                {
                    playerData = GameManager.Instance.user;
                }
                winCont.formatValues = new List<string>() { playerData.winCont.ToString() };
                loseCont.formatValues = new List<string>() { playerData.loseCont.ToString() };
                userName.text = playerData.displayName;
                ring.sprite = GameManager.Instance.iabManager.icons[GameManager.Instance.user.selectedPieceRing];
                icon.sprite = GameManager.Instance.iabManager.icons[GameManager.Instance.user.selectedPieceIcon];
                foreach (var gem in gems)
                {
                    gem.sprite = GameManager.Instance.iabManager.icons[GameManager.Instance.user.selectedPieceGem];
                }
            }
            public void OnPlayPressed()
            {
                //GameMenu.Show();
            }

            public void OnOptionsPressed()
            {
                //OptionsMenu.Show();
            }

            public override void OnBackPressed()
            {
                Hide();
            }
        }
    }
}