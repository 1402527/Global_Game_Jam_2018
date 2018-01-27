using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HacOS.Scripts.Data {
    [CreateAssetMenuAttribute(fileName ="TaskBank", menuName ="HacOS/TaskBank", order = 2)]
	public class TaskBank : ScriptableObject, IResettable {
		public bool isSequential = true;
        public UserChoice[] Tasks;
		[System.NonSerialized] private int currentTaskIdx = 0;
        [System.NonSerialized] private List<UserChoice> usedChoices = new List<UserChoice>();

        public bool BankDepleted { get { return usedChoices.Count >= Tasks.Length; } }

        public UserChoice GetUserChoice() {
            UserChoice task = null;
            if(isSequential) {
                task = GetNextTask();
            }
            else {
                task = GetRandomTask();
            }
            usedChoices.Add(task);
            return task;
        }

        private UserChoice GetNextTask() {
			if(currentTaskIdx < Tasks.Length) {
				return Tasks[currentTaskIdx++];
			}
			return Tasks[Tasks.Length-1];
        }

        private UserChoice GetRandomTask() {
            if(BankDepleted) {
                return Tasks[currentTaskIdx];
            }
            
            currentTaskIdx = Random.Range(0, Tasks.Length);

            // Not very efficient but it's a game jam :P
            if(usedChoices.Contains(Tasks[currentTaskIdx])) {
                return GetRandomTask();
            }
			return Tasks[currentTaskIdx];
        }
        
		public void Reset() {
			currentTaskIdx = 0;
            usedChoices.Clear();
		}
    }
}
