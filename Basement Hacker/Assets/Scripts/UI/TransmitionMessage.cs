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

        private GameObject cachedGameObject;

        public void SetActive (bool isActive)
        {
            if(cachedGameObject == null) {
                cachedGameObject = gameObject;
            }
            cachedGameObject.SetActive(isActive);
        }

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
