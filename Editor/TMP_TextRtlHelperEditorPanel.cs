using TMPro;
using UnityEditor;

namespace DrimiaInteractive.RtlHelperSystem.EditorUtilities
{
	[CustomEditor(typeof(TextMeshProRtlHelper), true), CanEditMultipleObjects]
	public class TMP_TextRtlHelperEditorPanel : RtlHelperComponentEditorPanel<TMP_Text>
	{
	}
}