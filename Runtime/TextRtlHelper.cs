using System;
using UnityEngine;
using UnityEngine.UI;

namespace DrimiaInteractive.RtlHelperSystem
{
	[RequireComponent(typeof(Text))]
	public class TextRtlHelper : MonoBehaviour
	{
		[SerializeField] private Text textComponent;

		[SerializeField] protected bool m_isRightToLeft = false;

		public bool isRightToLeftText
		{
			get { return m_isRightToLeft; }
			set
			{
				if (m_isRightToLeft == value)
					return;
				m_isRightToLeft = value;
				ReverseText();
				ChangeAlignment();
			}
		}

		private void ReverseText()
		{
			textComponent.text = Reverse(textComponent.text);
		}

		private static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

		private void ChangeAlignment()
		{
			switch (textComponent.alignment)
			{
				case TextAnchor.UpperLeft:
					textComponent.alignment = TextAnchor.UpperRight;
					break;
				case TextAnchor.UpperRight:
					textComponent.alignment = TextAnchor.UpperLeft;
					break;
				case TextAnchor.MiddleLeft:
					textComponent.alignment = TextAnchor.MiddleRight;
					break;
				case TextAnchor.MiddleRight:
					textComponent.alignment = TextAnchor.MiddleLeft;
					break;
				case TextAnchor.LowerLeft:
					textComponent.alignment = TextAnchor.LowerRight;
					break;
				case TextAnchor.LowerRight:
					textComponent.alignment = TextAnchor.LowerLeft;
					break;
			}
		}


		protected void Awake()
		{
			if (textComponent == null)
			{
				textComponent = GetComponent<Text>();
			}
		}

		public void Reset()
		{
			textComponent = GetComponent<Text>();
		}
	}
}