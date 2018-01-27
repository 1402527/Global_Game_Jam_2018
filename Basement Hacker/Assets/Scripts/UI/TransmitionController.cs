using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HacOS.Scripts.UI {
	public class TransmitionController : MonoBehaviour {
		[SerializeField] private AudioSource notificationSound;
		[SerializeField] private GameObject notificationIcon;
		[SerializeField] private GameObject notificationMessage;

		public Action<bool> onChoiceSelected = delegate {};

		public void IncomingTransmition(string info, string goodOption, string badOption) {
			if(notificationSound != null) {
				notificationSound.Play();
			}

			notificationIcon.SetActive(true);
			notificationMessage.SetActive(true);
            
			//notificationMessage.SetMessage(info)
			//notificationMessage.SetGoodOption(goodOption)
			//notificationMessage.SetBadOption(badOption)
		}

		public void SelectChoice(bool isGoodChoice) {
			onChoiceSelected(isGoodChoice);
		}
	}
}