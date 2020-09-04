using System;
using UnityEngine;
using UnityEngine.UI;

namespace DrimiaInteractive.RtlHelperSystem
{
	[RequireComponent(typeof(Text))]
	public class TextRtlHelper : RtlHelperComponent<Text>
	{
		protected override void RtlChanged()
		{
			ReverseText();
			ChangeAlignment();
		}

		private void ReverseText()
		{
			tComponent.text = Reverse(tComponent.text);
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