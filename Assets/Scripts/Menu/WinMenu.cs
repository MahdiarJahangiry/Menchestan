using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace Menchestan
{
    namespace Menu
    {
        public class WinMenu : MonoBehaviour

        {
            public Image coinLogo;
            public Text coinText;
            public void ShowWinMenu(int amount, Action callback)
            {
                var st = DialogBoxMenu.Instance.GetIconByValue(amount);
               // coinLogo=
                coinText.text = amount.ToString();
            }

        }
    }
}
