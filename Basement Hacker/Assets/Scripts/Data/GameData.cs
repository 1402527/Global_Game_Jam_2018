using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HacOS.Scripts.Data {
    [CreateAssetMenuAttribute(fileName ="gameData", menuName ="HacOS/GameData", order = 0)]
	public class GameData : ScriptableObject {
		public TaskBank[] taskBanks;
	}
}