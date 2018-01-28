using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HacOS.Scripts.UI {

    public class FullArticle : MonoBehaviour {

        [SerializeField] private Image photo;
        [SerializeField] private TMP_Text newsMessage;

        public void SetPostInfo(Sprite photo, String newsMessage) {
            this.photo.overrideSprite = photo;
            this.newsMessage.text = newsMessage;
        }
    }
}
