using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HacOS.Scripts.UI {
	public class TransmitionController : MonoBehaviour {
		[SerializeField] private AudioSource notificationSound;
		[SerializeField] private GameObject notificationIcon;
        [SerializeField] private TransmitionMessage transmitionMessage;

		public Action<bool> onChoiceSelected = delegate {};

		public void IncomingTransmition(string info, string goodOption, string badOption) {
			if(notificationSound != null) {
				notificationSound.Play();
			}

			notificationIcon.SetActive(true);
            transmitionMessage.SetActive(true);

            transmitionMessage.SetMessage(info);
            transmitionMessage.SetGoodOption(goodOption);
            transmitionMessage.SetBadOption(badOption);
		}

		public void SelectChoice(bool isGoodChoice) {
			onChoiceSelected(isGoodChoice);
		}
	}
}