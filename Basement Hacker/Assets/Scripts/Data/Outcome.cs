using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HacOS.Scripts.Data {
    [CreateAssetMenuAttribute(fileName ="choice", menuName ="HacOS/Outcome", order = 1)]
    public class Outcome : ScriptableObject {
        [TextArea] public string text;
		[Range(-50,50)]
        public int outcomeValue;
    }
}