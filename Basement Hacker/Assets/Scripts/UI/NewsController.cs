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
        [SerializeField] private FullArticle fullArticle;
        private List<NewsPost> allPosts = new List<NewsPost>();
		public Action onPostRead = delegate {};
		bool recievedPostWhileClosed = false;
		string playerName = string.Empty;

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

			if(string.IsNullOrEmpty(playerName)) {
				playerName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
				var splitnames = playerName.Split('\\');
				playerName = splitnames[splitnames.Length-1];
			}
			
			var sb = new System.Text.StringBuilder();
			sb.Append("Woah! @");
			sb.Append(playerName);
			sb.Append(", do you believe this");
			newsPost.SetPostInfo("Joe", postImage, sb.ToString(), newsMessage, OpenFullArticle);
			allPosts.Add(newsPost);
		}

        public void NewsTabOpened()
        {
            newsNotificationIcon.SetActive(false);
			// just incase we left this open lets close it
			fullArticle.gameObject.SetActive(false);
			
			if(recievedPostWhileClosed) {
				recievedPostWhileClosed = false;
				onPostRead();
			}
        }

        public void OpenFullArticle(string news, Sprite photo)
        {
            fullArticle.gameObject.SetActive(true);
            fullArticle.SetArticleInfo(news, photo);
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