using TMPro;
using UnityEditor;
using UnityEngine;

namespace DrimiaInteractive.RtlHelperSystem.EditorUtilities
{
	[CustomEditor(typeof(TextMeshProRtlHelper), true), CanEditMultipleObjects]
	public class TMP_TextRtlHelperEditorPanel : RtlHelperComponentEditorPanel<TMP_Text>
	{
		static readonly GUIContent fixTextToggleLabel = new GUIContent("Fix Text With RTL Change", "true: fix the text automatic with the RTL change.\n" +
																								   "false: fix the text with using on the function OnTextChanged");

		static readonly GUIContent fixTypeLabel = new GUIContent("Fix with regular TMP or with the Arabic Letters Support");
		protected SerializedProperty fixTextWithRtlChangeProp;

		protected override void OnEnable()
		{
			base.OnEnable();
			fixTextWithRtlChangeProp = serializedObject.FindProperty("fixTextWithRtlChange");
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			fixTextWithRtlChangeProp.boolValue = EditorGUILayout.Toggle(fixTextToggleLabel, fixTextWithRtlChangeProp.boolValue);
			((TextMeshProRtlHelper) tRtlHelper).fixTextWithRtlChange = fixTextWithRtlChangeProp.boolValue;
			((TextMeshProRtlHelper) tRtlHelper).fixType = (TextMeshProRtlHelper.FixType) EditorGUILayout.EnumPopup(fixTypeLabel, ((TextMeshProRtlHelper) tRtlHelper).fixType);
		}
	}
}