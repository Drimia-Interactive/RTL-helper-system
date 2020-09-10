using System;
using ArabicSupport;
using UnityEngine;
using UnityEngine.UI;

namespace DrimiaInteractive.RtlHelperSystem
{
	[RequireComponent(typeof(Text))]
	public class TextRtlHelper : RtlHelperComponent<Text>
	{
		public virtual string text
		{
			get => tComponent.text;
			set
			{
				if (isRightToLeftText)
				{
					FixText(value);
				}
				else
				{
					tComponent.text = value;
				}
			}
		}

		public bool fixTextWithRtlChange = false;
		protected override void RtlChanged()
		{
			if (isRightToLeftText && fixTextWithRtlChange)
			{
				FixText(tComponent.text);
			}

			ChangeAlignment();
		}

		public void OnTextChanged(string newText)
		{
			if (fixTextWithRtlChange)
			{
				return;
			}
			FixText(newText);
		}
		
		private void FixText(string text)
		{
			tComponent.text = RtlHelperSystemManager.Instance.GetFixedString(text);
		}

		private static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

		private void ChangeAlignment()
		{
			switch (tComponent.alignment)
			{
				case TextAnchor.UpperLeft:
					tComponent.alignment = TextAnchor.UpperRight;
					break;
				case TextAnchor.UpperRight:
					tComponent.alignment = TextAnchor.UpperLeft;
					break;
				case TextAnchor.MiddleLeft:
					tComponent.alignment = TextAnchor.MiddleRight;
					break;
				case TextAnchor.MiddleRight:
					tComponent.alignment = TextAnchor.MiddleLeft;
					break;
				case TextAnchor.LowerLeft:
					tComponent.alignment = TextAnchor.LowerRight;
					break;
				case TextAnchor.LowerRight:
					tComponent.alignment = TextAnchor.LowerLeft;
					break;
			}
		}
	}
}