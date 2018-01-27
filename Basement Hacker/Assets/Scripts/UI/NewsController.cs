using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HacOS.Scripts.UI {
	public class NewsController : MonoBehaviour {

		[SerializeField] private NewsPost newsPostPrefab;
		[SerializeField] private Transform newsPostContainer;
		[SerializeField] private ScrollRect scrollView;
        [SerializeField] private GameObject newsNotificationIcon;
        [SerializeField] private AudioSource notificationSound;
        private List<NewsPost> allPosts = new List<NewsPost>();
		public Action onPostRead = delegate {};
		bool recievedPostWhileClosed = false;

		public void AddNewsPost(string newsMessage, Sprite postImage) {
			scrollView.normalizedPosition = Vector2.one;
           
            if (transform.GetSiblingIndex() == 0)
            {
                newsNotificationIcon.SetActive(true);
				recievedPostWhileClosed = true;
            }
			else {
				onPostRead();
			}

            if (notificationSound != null)
            {
                notificationSound.Play();
            }

            var newsPost = Instantiate<NewsPost>(newsPostPrefab, Vector3.zero, Quaternion.identity);
			var postTransform = newsPost.transform;
			postTransform.SetParent(newsPostContainer, false);
            postTransform.transform.SetAsFirstSibling();

			var playerName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
			var sb = new System.Text.StringBuilder();
			sb.Append("Woah! @");
			sb.Append(playerName);
			sb.Append(", do you believe this");
			newsPost.SetPostInfo("Joe", postImage, sb.ToString(), newsMessage);
			allPosts.Add(newsPost);
		}

        public void NewsTabOpened()
        {
            newsNotificationIcon.SetActive(false);
			
			if(recievedPostWhileClosed) {
				recievedPostWhileClosed = false;
				onPostRead();
			}
        }

#if UNITY_EDITOR
		public bool doPost = false;
		void Update() {
			if(doPost) {
				doPost = false;
				AddNewsPost("Test message", null);
			}
		}
#endif
	}
}