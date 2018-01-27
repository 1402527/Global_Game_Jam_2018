using System.Collections;
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

		public void SetPostInfo(string userName, Sprite photo, string userMessage, string newsMessage) {
			this.userName.text = userName;
			this.photo.overrideSprite = photo;
			this.userMessage.text = userMessage;
			this.newsMessage.text = newsMessage;
		}
	}
}