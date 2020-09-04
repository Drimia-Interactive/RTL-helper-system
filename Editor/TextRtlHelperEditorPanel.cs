using UnityEditor;
using UnityEngine.UI;

namespace DrimiaInteractive.RtlHelperSystem.EditorUtilities
{
	[CustomEditor(typeof(TextRtlHelper), true), CanEditMultipleObjects]
	public class TextRtlHelperEditorPanel : RtlHelperComponentEditorPanel<Text>
	{
	}
}