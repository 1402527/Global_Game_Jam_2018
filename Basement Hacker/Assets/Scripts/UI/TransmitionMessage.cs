using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HacOS.Scripts.UI
{

    public class TransmitionMessage : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private TMP_Text goodText;
        [SerializeField] private TMP_Text badText;

        // not sure how to complete this, there is an error in transmision controller.
       //public void SetActive (bool)
       // {

       // }

       public void SetMessage(string info)
        {
            text.SetText(info);
        }

        public void SetGoodOption(string goodOption)
        {
            goodText.SetText(goodOption);
        }

        public void SetBadOption(string badOption)
        {
            badText.SetText(badOption);
        }


    }
}
