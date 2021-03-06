﻿using System.Collections;
using System.Collections.Generic;
using HacOS.Scripts.Game;
using UnityEngine;
using System;

namespace HacOS.Scripts.UI {
	public class UIController : MonoBehaviour {
		[SerializeField] private GameController gameController;
		[SerializeField] private TransmitionController transmitionController;
		[SerializeField] private NewsController newsController;
		[SerializeField] private EndGameController endGameController;
		private bool isGameOver = false;

		// Use this for initialization
		void Start () {
			gameController.OnGameFinished += OnGameOver;
			transmitionController.onChoiceSelected += OnChoiceSelected;
			newsController.onPostRead += OnPostRead;
			endGameController.onEndGameEmailClosed += OnEndGameEmailClosed;
			isGameOver = false;
			GetIncommingTransmition();
		}

		public void GetIncommingTransmition() {
			gameController.ReadyNextMessage();

			if(!isGameOver) {
				var info = gameController.GetMessage();
				var goodChoice = gameController.GetGoodChoice();
				var badChoice = gameController.GetBadChoice();

				transmitionController.IncomingTransmition(info, goodChoice, badChoice);
			}
		}

		private void OnChoiceSelected(bool isGoodChoice) {
			gameController.SelectChoice(isGoodChoice);
			var outcomeText = gameController.GetOutcomeText();
			var outcomeSprite = gameController.GetOutcomeSprite();

            StartCoroutine(DelayResponse(1.0f, () =>
                {
                    newsController.AddNewsPost(outcomeText, outcomeSprite);
                }
            ));
		}

		private void OnPostRead() {
			StartCoroutine(DelayResponse(2.5f, () =>
                {
                    GetIncommingTransmition();
                }
            ));
		}

        private IEnumerator DelayResponse(float time, Action action)
        {
            yield return new WaitForSeconds(time);

            action();
        }

		private void OnGameOver(string title, string message, GameObject gameEndPrefab) {
			isGameOver = true;
			StartCoroutine(DelayResponse(2.0f, () =>
                {
                    endGameController.StartEndGame(title, message, gameEndPrefab);
                }
            ));
		}

		private void OnEndGameEmailClosed() {
			StartCoroutine(DelayResponse(1.5f, () =>
                {
                    endGameController.ShowEndGamePrefab();
                }
            ));
		}
	}
}