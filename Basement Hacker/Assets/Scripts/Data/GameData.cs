using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HacOS.Scripts.Data {
    [CreateAssetMenuAttribute(fileName ="gameData", menuName ="HacOS/GameData", order = 0)]
	public class GameData : ScriptableObject, IResettable {
		public TaskBank[] taskBanks;
		private int currentBankIdx = 0;

		public bool CompletedAllBanks { get { return currentBankIdx >= taskBanks.Length; }}

		public TaskBank GetNextBank() {
			if(currentBankIdx < taskBanks.Length) {
				return taskBanks[currentBankIdx++];
			}
			return taskBanks[currentBankIdx];
		}

		public void Reset() {
			for(int i = 0; i < taskBanks.Length; ++i) {
				taskBanks[i].Reset();
			}
			currentBankIdx = 0;
		}
	}
}