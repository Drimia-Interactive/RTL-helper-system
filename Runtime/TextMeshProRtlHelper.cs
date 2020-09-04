using TMPro;
using UnityEngine;

namespace DrimiaInteractive.RtlHelperSystem
{
	[RequireComponent(typeof(TMP_Text))]
	public class TextMeshProRtlHelper : MonoBehaviour
	{
		[SerializeField] private TMP_Text textComponent;

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
			textComponent.isRightToLeftText = m_isRightToLeft;
		}

		private void ChangeAlignment()
		{
			switch (textComponent.alignment)
			{
				case TextAlignmentOptions.Right:
					textComponent.alignment = TextAlignmentOptions.Left;
					break;
				case TextAlignmentOptions.Left:
					textComponent.alignment = TextAlignmentOptions.Right;
					break;
				case TextAlignmentOptions.TopRight:
					textComponent.alignment = TextAlignmentOptions.TopLeft;
					break;
				case TextAlignmentOptions.TopLeft:
					textComponent.alignment = TextAlignmentOptions.TopRight;
					break;
				case TextAlignmentOptions.BottomRight:
					textComponent.alignment = TextAlignmentOptions.BottomLeft;
					break;
				case TextAlignmentOptions.BottomLeft:
					textComponent.alignment = TextAlignmentOptions.BottomRight;
					break;
				case TextAlignmentOptions.BaselineRight:
					textComponent.alignment = TextAlignmentOptions.BaselineLeft;
					break;
				case TextAlignmentOptions.BaselineLeft:
					textComponent.alignment = TextAlignmentOptions.BaselineRight;
					break;
				case TextAlignmentOptions.CaplineRight:
					textComponent.alignment = TextAlignmentOptions.CaplineLeft;
					break;
				case TextAlignmentOptions.CaplineLeft:
					textComponent.alignment = TextAlignmentOptions.CaplineRight;
					break;
				case TextAlignmentOptions.MidlineRight:
					textComponent.alignment = TextAlignmentOptions.MidlineLeft;
					break;
				case TextAlignmentOptions.MidlineLeft:
					textComponent.alignment = TextAlignmentOptions.MidlineRight;
					break;
			}
		}


		protected void Awake()
		{
			if (textComponent == null)
			{
				textComponent = GetComponent<TMP_Text>();
			}
		}

		protected void Reset()
		{
			textComponent = GetComponent<TMP_Text>();
		}
	}
}