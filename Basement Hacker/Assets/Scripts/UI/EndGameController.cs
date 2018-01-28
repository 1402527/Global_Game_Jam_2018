using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HacOS.Scripts.UI {
	public class EndGameController : MonoBehaviour {
		[SerializeField] private EmailPopup endGameEmail;
		[SerializeField] private Transform endGamePrefabContainer;
		[SerializeField] private GameObject endGamePrefab;

		public Action onEndGameEmailClosed = delegate {};

		public void StartEndGame(string emailTitle, string emailMessage, GameObject endGamePrefab) {
			endGameEmail.SetEmailText(emailTitle, emailMessage);
			gameObject.SetActive(true);
			this.endGamePrefab = endGamePrefab;
		}

		public void CloseEmail() {
			onEndGameEmailClosed();
		}

		public void ShowEndGamePrefab() {
			var prefab = Instantiate<GameObject>(endGamePrefab, Vector3.zero, Quaternion.identity);
			prefab.transform.SetParent(endGamePrefabContainer, false);
		}
	}
}
