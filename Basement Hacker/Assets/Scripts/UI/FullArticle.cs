using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HacOS.Scripts.UI {

    public class FullArticle : MonoBehaviour {

        [SerializeField] private Image photo;
        [SerializeField] private TMP_Text newsMessage;
        [SerializeField] private delegate void onArticleClicked();
        [SerializeField] private static onArticleClicked articleClicked;

        

        public void SetArticleInfo(String news, Sprite photo ) {
            this.photo.overrideSprite = photo;
            this.newsMessage.text = news;
        }
    }
}
