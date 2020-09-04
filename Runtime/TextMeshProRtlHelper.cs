using TMPro;
using UnityEngine;

namespace DrimiaInteractive.RtlHelperSystem
{
	[RequireComponent(typeof(TMP_Text))]
	public class TextMeshProRtlHelper : RtlHelperComponent<TMP_Text>
	{
		protected override void RtlChanged()
		{
			ReverseText();
			ChangeAlignment();
		}

		private void ReverseText()
		{
			tComponent.isRightToLeftText = m_isRightToLeft;
		}

		private void ChangeAlignment()
		{
			switch (tComponent.alignment)
			{
				case TextAlignmentOptions.Right:
					tComponent.alignment = TextAlignmentOptions.Left;
					break;
				case TextAlignmentOptions.Left:
					tComponent.alignment = TextAlignmentOptions.Right;
					break;
				case TextAlignmentOptions.TopRight:
					tComponent.alignment = TextAlignmentOptions.TopLeft;
					break;
				case TextAlignmentOptions.TopLeft:
					tComponent.alignment = TextAlignmentOptions.TopRight;
					break;
				case TextAlignmentOptions.BottomRight:
					tComponent.alignment = TextAlignmentOptions.BottomLeft;
					break;
				case TextAlignmentOptions.BottomLeft:
					tComponent.alignment = TextAlignmentOptions.BottomRight;
					break;
				case TextAlignmentOptions.BaselineRight:
					tComponent.alignment = TextAlignmentOptions.BaselineLeft;
					break;
				case TextAlignmentOptions.BaselineLeft:
					tComponent.alignment = TextAlignmentOptions.BaselineRight;
					break;
				case TextAlignmentOptions.CaplineRight:
					tComponent.alignment = TextAlignmentOptions.CaplineLeft;
					break;
				case TextAlignmentOptions.CaplineLeft:
					tComponent.alignment = TextAlignmentOptions.CaplineRight;
					break;
				case TextAlignmentOptions.MidlineRight:
					tComponent.alignment = TextAlignmentOptions.MidlineLeft;
					break;
				case TextAlignmentOptions.MidlineLeft:
					tComponent.alignment = TextAlignmentOptions.MidlineRight;
					break;
			}
		}
	}
}