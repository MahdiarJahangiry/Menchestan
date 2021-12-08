using System;
using UnityEngine.UI;
using Menchestan.Localization;
using System.Collections.Generic;
using UnityEngine;

namespace Menchestan
{
    namespace Menu
    {
        public enum DialogBoxType
        {
            MessageBox,
            WinnerBox,
            LoserBox
        }
        public enum DialogBoxButtonType
        {
            Ok,
            YesNo,
            OkCancel,
            TryOffline,
            TryContinue,
            TryCancel,
            Continue
        }
        public class DialogBoxMenu : SimpleMenu<DialogBoxMenu>
        {
            public RectTransform frameBack;
 public GameObject background;
            public GameObject messageBox;
            public GameObject gameOverLoserBox;
            public GameObject gameOverWinnerBox;
            public RTLTMPro.RTLTextMeshPro coinAmount;
            public Image coinLogo;
            public Localize leftLable;
            public Localize centerLable;
            public Localize rightLable;
            public Localize title;
            public Localize message;
            public Button leftButton;
            public Button centerButton;
            public Button rightButton;
            private List<string> GetButtonsLabel(DialogBoxButtonType boxType)
            {
                List<string> btnsLabel = new List<string>();
                switch (boxType)
                {
                    case DialogBoxButtonType.Ok:
                        btnsLabel.Add("Ok");
                        break;
                    case DialogBoxButtonType.Continue:
                        btnsLabel.Add("Continue");
                        break;
                    case DialogBoxButtonType.YesNo:
                        btnsLabel.Add("Yes");
                        btnsLabel.Add("No");
                        break;
                    case DialogBoxButtonType.OkCancel:
                        btnsLabel.Add("Ok");
                        btnsLabel.Add("Cancel");
                        break;
                    case DialogBoxButtonType.TryOffline:
 background.SetActive(true);
                        btnsLabel.Add("Try");
                        btnsLabel.Add("Offline");
                        break;
                    case DialogBoxButtonType.TryContinue:
                        btnsLabel.Add("Try");
                        btnsLabel.Add("Continue");
                        break;
                    case DialogBoxButtonType.TryCancel:
                        btnsLabel.Add("Try");
                        btnsLabel.Add("Cancel");
                        break;
                    default:
                        break;
                }
                return btnsLabel;
            }
            public void ShowDialog(DialogBoxButtonType boxType, string titleTxt, string messageTxt, Action callback = null)
            {
                ShowDialog(DialogBoxType.MessageBox, GetButtonsLabel(boxType), titleTxt, null, messageTxt, null, callback != null ? new List<Action>() { callback } : null);
            }
            public void ShowDialog(List<string> buttonsLabel, string titleTxt, string messageTxt, Action callback = null)
            {
                ShowDialog(DialogBoxType.MessageBox, buttonsLabel, titleTxt, null, messageTxt, null, callback != null ? new List<Action>() { callback } : null);
            }
            public void ShowDialog(DialogBoxButtonType boxType, string titleTxt, string messageTxt, List<Action> callbacks)
            {
                ShowDialog(DialogBoxType.MessageBox, GetButtonsLabel(boxType), titleTxt, null, messageTxt, null, callbacks);
            }
            public void ShowDialog(List<string> buttonsLabel, string titleTxt, string messageTxt, List<Action> callbacks)
            {
                ShowDialog(DialogBoxType.MessageBox, buttonsLabel, titleTxt, null, messageTxt, null, callbacks);
            }
            public void ShowDialog(DialogBoxButtonType boxType, string titleTxt, List<string> titleFormatValues, string messageTxt, Action callback = null)
            {
                ShowDialog(DialogBoxType.MessageBox, GetButtonsLabel(boxType), titleTxt, titleFormatValues, messageTxt, null, callback != null ? new List<Action>() { callback } : null);
            }
            public void ShowDialog(List<string> buttonsLabel, string titleTxt, List<string> titleFormatValues, string messageTxt, Action callback = null)
            {
                ShowDialog(DialogBoxType.MessageBox, buttonsLabel, titleTxt, titleFormatValues, messageTxt, null, callback != null ? new List<Action>() { callback } : null);
            }
            public void ShowDialog(DialogBoxButtonType boxType, string titleTxt, List<string> titleFormatValues, string messageTxt, List<Action> callbacks)
            {
                ShowDialog(DialogBoxType.MessageBox, GetButtonsLabel(boxType), titleTxt, titleFormatValues, messageTxt, null, callbacks);
            }
            public void ShowDialog(List<string> buttonsLabel, string titleTxt, List<string> titleFormatValues, string messageTxt, List<Action> callbacks)
            {
                ShowDialog(DialogBoxType.MessageBox, buttonsLabel, titleTxt, titleFormatValues, messageTxt, null, callbacks);
            }
            public void ShowDialog(DialogBoxButtonType boxType, string titleTxt, string messageTxt, List<string> messageFormatValues, Action callback = null)
            {
                ShowDialog(DialogBoxType.MessageBox, GetButtonsLabel(boxType), titleTxt, null, messageTxt, messageFormatValues, callback != null ? new List<Action>() { callback } : null);
            }
            public void ShowDialog(List<string> buttonsLabel, string titleTxt, string messageTxt, List<string> messageFormatValues, Action callback = null)
            {
                ShowDialog(DialogBoxType.MessageBox, buttonsLabel, titleTxt, null, messageTxt, messageFormatValues, callback != null ? new List<Action>() { callback } : null);
            }
            public void ShowDialog(DialogBoxButtonType boxType, string titleTxt, string messageTxt, List<string> messageFormatValues, List<Action> callbacks)
            {
                ShowDialog(DialogBoxType.MessageBox, GetButtonsLabel(boxType), titleTxt, null, messageTxt, messageFormatValues, callbacks);
            }
            public void ShowWinnerBox(int amount, Action callback)
            {
                List<string> tmp = new List<string>() { GetIconByValue(amount) };
                ShowDialog(DialogBoxType.WinnerBox, GetButtonsLabel(DialogBoxButtonType.Continue), "YouWin", null, amount.ToString(), tmp, callback != null ? new List<Action>() { callback } : null);
            }
            public void ShowLoserBox(int amount, Action callback)
            {
                List<string> tmp = new List<string>() { GetIconByValue(amount) };
                ShowDialog(DialogBoxType.LoserBox, GetButtonsLabel(DialogBoxButtonType.Continue), "EndGame", null, amount.ToString(), tmp, callback != null ? new List<Action>() { callback } : null);
            }
            public void ShowDialog(List<string> buttonsLabel, string titleTxt, string messageTxt, List<string> messageFormatValues, List<Action> callbacks)
            {
                ShowDialog(DialogBoxType.MessageBox, buttonsLabel, titleTxt, null, messageTxt, messageFormatValues, callbacks);
            }
            private void SetButton(List<string> buttonsLabel, List<Action> callbacks)
            {
                leftButton.gameObject.SetActive(false);
                centerButton.gameObject.SetActive(false);
                rightButton.gameObject.SetActive(false);
                leftButton.onClick.RemoveAllListeners();
                centerButton.onClick.RemoveAllListeners();
                rightButton.onClick.RemoveAllListeners();

                if (buttonsLabel.Count == 1)
                {
                    centerButton.gameObject.SetActive(true);
                    if (callbacks == null || callbacks.Count == 0)
                    {
                        centerButton.onClick.AddListener(() => OnBackPressed());
                    }
                    else
                    {
                        centerButton.onClick.AddListener(() => callbacks[0]?.Invoke());
                    }
                    centerLable.SetKey(buttonsLabel[0]);
                }
                else if (buttonsLabel.Count == 2)
                {
                    if (LocalizationManager.Instance.isRTL)
                    {
                        leftLable.SetKey(buttonsLabel[1]);
                        rightLable.SetKey(buttonsLabel[0]);
                        if (callbacks == null || callbacks.Count == 0)
                        {
                            leftButton.onClick.AddListener(() => OnBackPressed());
                            rightButton.onClick.AddListener(() => OnBackPressed());
                        }
                        else if (callbacks.Count == 1)
                        {
                            leftButton.onClick.AddListener(() => OnBackPressed());
                            rightButton.onClick.AddListener(() => callbacks[0]?.Invoke());
                        }
                        else if (callbacks.Count == 2)
                        {
                            leftButton.onClick.AddListener(() => callbacks[1]?.Invoke());
                            rightButton.onClick.AddListener(() => callbacks[0]?.Invoke());
                        }
                    }
                    else
                    {
                        leftLable.SetKey(buttonsLabel[0]);
                        rightLable.SetKey(buttonsLabel[1]);
                        if (callbacks == null || callbacks.Count == 0)
                        {
                            leftButton.onClick.AddListener(() => OnBackPressed());
                            rightButton.onClick.AddListener(() => OnBackPressed());
                        }
                        else if (callbacks.Count == 1)
                        {
                            leftButton.onClick.AddListener(() => callbacks[0]?.Invoke());
                            rightButton.onClick.AddListener(() => OnBackPressed());
                        }
                        else if (callbacks.Count == 2)
                        {
                            leftButton.onClick.AddListener(() => callbacks[0]?.Invoke());
                            rightButton.onClick.AddListener(() => callbacks[1]?.Invoke());
                        }
                    }
                    leftButton.gameObject.SetActive(true);
                    rightButton.gameObject.SetActive(true);
                }
                else if (buttonsLabel.Count >= 3)
                {
                    if (LocalizationManager.Instance.isRTL)
                    {
                        leftLable.SetKey(buttonsLabel[2]);
                        centerLable.SetKey(buttonsLabel[1]);
                        rightLable.SetKey(buttonsLabel[0]);
                        if (callbacks == null || callbacks.Count == 0)
                        {
                            leftButton.onClick.AddListener(() => OnBackPressed());
                            centerButton.onClick.AddListener(() => OnBackPressed());
                            rightButton.onClick.AddListener(() => OnBackPressed());
                        }
                        else if (callbacks.Count == 1)
                        {
                            leftButton.onClick.AddListener(() => OnBackPressed());
                            centerButton.onClick.AddListener(() => OnBackPressed());
                            rightButton.onClick.AddListener(() => callbacks[0]?.Invoke());
                        }
                        else if (callbacks.Count == 2)
                        {
                            leftButton.onClick.AddListener(() => OnBackPressed());
                            centerButton.onClick.AddListener(() => callbacks[1]?.Invoke());
                            rightButton.onClick.AddListener(() => callbacks[0]?.Invoke());
                        }
                        else if (callbacks.Count >= 3)
                        {
                            leftButton.onClick.AddListener(() => callbacks[2]?.Invoke());
                            centerButton.onClick.AddListener(() => callbacks[1]?.Invoke());
                            rightButton.onClick.AddListener(() => callbacks[0]?.Invoke());
                        }
                    }
                    else
                    {
                        leftLable.SetKey(buttonsLabel[0]);
                        centerLable.SetKey(buttonsLabel[1]);
                        rightLable.SetKey(buttonsLabel[2]);
                        if (callbacks == null || callbacks.Count == 0)
                        {
                            leftButton.onClick.AddListener(() => OnBackPressed());
                            centerButton.onClick.AddListener(() => OnBackPressed());
                            rightButton.onClick.AddListener(() => OnBackPressed());
                        }
                        else if (callbacks.Count == 1)
                        {
                            leftButton.onClick.AddListener(() => callbacks[0]?.Invoke());
                            centerButton.onClick.AddListener(() => OnBackPressed());
                            rightButton.onClick.AddListener(() => OnBackPressed());
                        }
                        else if (callbacks.Count == 2)
                        {
                            leftButton.onClick.AddListener(() => callbacks[0]?.Invoke());
                            centerButton.onClick.AddListener(() => callbacks[1]?.Invoke());
                            rightButton.onClick.AddListener(() => OnBackPressed());
                        }
                        else if (callbacks.Count >= 3)
                        {
                            leftButton.onClick.AddListener(() => callbacks[0]?.Invoke());
                            centerButton.onClick.AddListener(() => callbacks[1]?.Invoke());
                            rightButton.onClick.AddListener(() => callbacks[2]?.Invoke());
                        }
                    }
                    leftButton.gameObject.SetActive(true);
                    centerButton.gameObject.SetActive(true);
                    rightButton.gameObject.SetActive(true);
                }
            }
            public string GetIconByValue(int amount)
            {
                int i = 0;
                if (amount < 400)
                    i = 0;
                else if (amount >= 400 && amount < 800)
                    i = 1;
                else if (amount >= 800 && amount < 2000)
                    i = 2;
                else if (amount >= 2000 && amount < 4000)
                    i = 3;
                else if (amount >= 4000 && amount < 8000)
                    i = 4;
                else
                    i = 5;
                return "coinpack00" + i.ToString();
            }
            private void ShowDialog(DialogBoxType type, List<string> buttonsLabel, string titleTxt, List<string> titleFormatValues, string messageTxt, List<string> messageFormatValues, List<Action> callbacks)
            {
                title.SetKey(titleTxt, titleFormatValues);
                message.SetKey(messageTxt, messageFormatValues);
                messageBox.SetActive(false);
                gameOverLoserBox.SetActive(false);
                gameOverWinnerBox.SetActive(false);
                if (type == DialogBoxType.MessageBox)
                {
                    messageBox.SetActive(true);
                    frameBack.sizeDelta = new Vector2(980, 360 + 60 * message.GetNumberOfLines());
                    centerButton.GetComponent<RectTransform>().sizeDelta = new Vector2(280, 125);
                }
                else if (type == DialogBoxType.LoserBox || type == DialogBoxType.WinnerBox)
                {
                    gameOverLoserBox.SetActive(true);
                    int.TryParse(messageTxt, out int value);
                    coinAmount.text = (value < 0 ? "- " : "+ ") + Mathf.Abs(value);
                    frameBack.sizeDelta = new Vector2(980, 850);
                    centerButton.GetComponent<RectTransform>().sizeDelta = new Vector2(360, 125);
                    if (type == DialogBoxType.LoserBox)
                    {
                        coinLogo.sprite = GameManager.Instance.iabManager.icons[messageFormatValues[0]];
                    }
                    else if (type == DialogBoxType.WinnerBox)
                    {
                        coinLogo.sprite = GameManager.Instance.iabManager.icons[messageFormatValues[0]];
                        gameOverWinnerBox.SetActive(true);
                    }
                }
                SetButton(buttonsLabel, callbacks);
                Show();
            }

 public void ShowBackground()
            {
               background.SetActive(false);
               MenuManager.Instance.IntroPrefab.SetActive(true);
            }
            public override void OnBackPressed()
            {
                Hide();
            }
        }
    }
}