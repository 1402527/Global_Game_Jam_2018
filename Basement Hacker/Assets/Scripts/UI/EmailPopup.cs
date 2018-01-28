using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace HacOS.Scripts.UI {
	public class EmailPopup : MonoBehaviour {
		[SerializeField] private TMP_Text subject;
		[SerializeField] private TMP_Text message;

		private const string subjectTitle = "Subject: {0}";

		public void SetEmailText(string subject, string message) {
			var sb = new StringBuilder();
			sb.AppendFormat(subjectTitle, subject);
			this.subject.text = sb.ToString();

			this.message.text = message;
		}
	}
}
