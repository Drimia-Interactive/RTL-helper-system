using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DrimiaInteractive.RtlHelperSystem.EditorUtilities
{
	[CustomEditor(typeof(TextRtlHelper), true), CanEditMultipleObjects]
	public class TextRtlHelperEditorPanel : RtlHelperComponentEditorPanel<Text>
	{
		static readonly GUIContent fixTextToggleLabel = new GUIContent("Fix Text With RTL Change", "true: fix the text automatic with the RTL change.\n" +
																								   "false: fix the text with using on the function OnTextChanged");

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
			((TextRtlHelper) tRtlHelper).fixTextWithRtlChange = fixTextWithRtlChangeProp.boolValue;
		}
	}
}