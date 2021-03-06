﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HacOS.Scripts.UI {
	public class NewsPost : MonoBehaviour {
		[SerializeField] private TMP_Text userName;
		[SerializeField] private Image photo;
		[SerializeField] private TMP_Text userMessage;
		[SerializeField] private TMP_Text newsMessage;
        [SerializeField] private Action<string, Sprite> onArticleClicked;

        public void SetPostInfo(string userName, Sprite photo, string userMessage, string newsMessage, Action<string, Sprite> onArticleClicked) {
			this.userName.text = userName;
			this.photo.sprite = photo;
			this.userMessage.text = userMessage;
			this.newsMessage.text = newsMessage;
            this.onArticleClicked = onArticleClicked;

        }

        public void ArticleClicked()
        {
            onArticleClicked(newsMessage.text, photo.overrideSprite);
        }
	}
}