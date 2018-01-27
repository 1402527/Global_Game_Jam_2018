using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HacOS.Scripts.UI
{

    public class TransmitionMessage : MonoBehaviour
    {
        public TMP_Text text;
        public TMP_Text goodText;
        public TMP_Text badText;

        void SetMessage(string info)
        {
            text.SetText(info);
        }

        void SetGoodOption(string goodOption)
        {
            goodText.SetText(goodOption);
        }

        void SetBadOption(string badOption)
        {
            badText.SetText(badOption);
        }


    }
}
