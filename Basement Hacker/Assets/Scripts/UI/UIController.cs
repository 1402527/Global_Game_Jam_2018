﻿using System.Collections;
using System.Collections.Generic;
using HacOS.Scripts.Game;
using UnityEngine;

namespace HacOS.Scripts.UI {
	public class UIController : MonoBehaviour {
		[SerializeField] private GameController gameController;
		[SerializeField] private TransmitionController transmitionController;

		// Use this for initialization
		void Start () {
			gameController.OnGameFinished += OnGameOver;
			transmitionController.onChoiceSelected += OnChoiceSelected;
		}

		private void OnChoiceSelected(bool isGoodChoice) {
			gameController.SelectChoice(isGoodChoice);
			
		}


		private void OnGameOver(string reason) {

		}
	}
}