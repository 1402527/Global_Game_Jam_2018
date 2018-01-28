using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HacOS.Scripts.Data {
	[CreateAssetMenuAttribute(fileName ="gameEnd", menuName ="HacOS/GameEndData", order = 3)]
	public class GameEndData : ScriptableObject {
		public string title;
		[TextArea] public string text;
		public GameObject gameOverPrefab;
	}
}
