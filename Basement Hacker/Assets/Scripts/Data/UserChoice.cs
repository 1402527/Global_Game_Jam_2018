using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HacOS.Scripts.Data {
    [CreateAssetMenuAttribute(fileName ="choice", menuName ="HacOS/Task", order = 0)]
    public class UserChoice : ScriptableObject {
        public string information;
        public string goodChoice;
        public string illuminateChoice;
        public Outcome goodOutcome;
        public Outcome badOutcome;
    }
}