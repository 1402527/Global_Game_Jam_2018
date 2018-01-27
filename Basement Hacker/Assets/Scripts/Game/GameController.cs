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

		public Action<string> OnGameFinished;

		private void Start() {
			currentTaskBank = gameData.GetNextBank();
			if(currentTaskBank == null) {
				var username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
				Debug.LogErrorFormat("I'm sorry {0} but no data found", username);
			}
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

		public string SelectChoice(bool isGoodChoice) {
			var outcome = isGoodChoice ? currentTask.badOutcome : currentTask.badOutcome;
			currentScore += outcome.outcomeValue;
			return outcome.text;
		}

		public void ReadyNextMessage() {
			if(currentTaskBank.BankDepleted) {
				if(gameData.CompletedAllBanks) {
					OnGameFinished(string.Empty);
					return;
				}
				currentTaskBank = gameData.GetNextBank();
				ReadyNextMessage();
			}
			currentTask = currentTaskBank.GetUserChoice();
		}

		public void ResetGame() {
			gameData.Reset();
		}
	}
}