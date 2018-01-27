using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HacOS.Scripts.Data {
    [CreateAssetMenuAttribute(fileName ="TaskBank", menuName ="HacOS/TaskBank", order = 2)]
	public class TaskBank : ScriptableObject {
		public bool isSequential = true;
        public UserChoice[] Tasks;
    }
}
