using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HacOS.Scripts.Data;
using System;

namespace HacOS.Scripts.Game {
	public class GameController : MonoBehaviour {
		public GameData gameData;

		private int currentScore = 0;
		private List<UserChoice> pastChoices;
		private TaskBank currentTaskBank;
		private UserChoice currentTask;
		private Outcome currentOutcome;

		public Action<string> OnGameFinished;

		private void Start() {
			// currentTaskBank = gameData.GetNextBank();
			// if(currentTaskBank == null) {
			// 	var username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
			// 	Debug.LogErrorFormat("I'm sorry {0} but no data found", username);
			// }
		}

		public string GetMessage() {
			return currentTask.information;
		}

		public string GetGoodChoice() {
			return currentTask.goodChoice;
		}

		public string GetBadChoice() {
			return currentTask.illuminateChoice;
		}

		public string GetOutcomeText() {
			return currentOutcome.text;
		}

		public Sprite GetOutcomeSprite() {
			return null;//currentOutcome.sprite;
		}

		public void SelectChoice(bool isGoodChoice) {
			if(currentOutcome != null) {
				return;
			}

			currentOutcome = isGoodChoice ? currentTask.goodOutcome : currentTask.badOutcome;
			currentScore += currentOutcome.outcomeValue;
		}

		public void ReadyNextMessage() {
			if(currentTaskBank == null || currentTaskBank.BankDepleted) {
				if(gameData.CompletedAllBanks) {
					OnGameFinished(string.Empty);
					return;
				}
				currentTaskBank = gameData.GetNextBank();
				ReadyNextMessage();
				return;
			}
			currentTask = currentTaskBank.GetUserChoice();
		}

		public void ResetGame() {
			gameData.Reset();
		}
	}
}