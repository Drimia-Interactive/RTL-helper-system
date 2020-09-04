using UnityEditor;
using UnityEngine;

namespace DrimiaInteractive.RtlHelperSystem.EditorUtilities
{
	[CustomEditor(typeof(TextRtlHelper), true), CanEditMultipleObjects]
	public class TextRtlHelperEditorPanel : Editor
	{
		static readonly GUIContent k_RtlToggleLabel = new GUIContent("Enable RTL", "Reverses text direction and Alignment.");
		static readonly GUIContent k_ref = new GUIContent("Text reference", "Just the reference to see that is works");
        
		protected bool m_HavePropertiesChanged;
        
		protected SerializedProperty m_IsRightToLeftProp;
		protected SerializedProperty textComponent;

		private TextRtlHelper textMeshProRtlHelper;
        
		protected virtual void OnEnable()
		{
			textComponent = serializedObject.FindProperty("textComponent");
			m_IsRightToLeftProp = serializedObject.FindProperty("m_isRightToLeft");

			textMeshProRtlHelper = (TextRtlHelper)target;
		}
        
		public override void OnInspectorGUI()
		{
			serializedObject.Update();
            
			m_IsRightToLeftProp.boolValue = EditorGUILayout.Toggle(k_RtlToggleLabel, m_IsRightToLeftProp.boolValue);
			textMeshProRtlHelper.isRightToLeftText = m_IsRightToLeftProp.boolValue;

			EditorGUILayout.ObjectField(textComponent, k_ref);

			EditorGUILayout.Space();

			if (m_HavePropertiesChanged)
			{
				m_HavePropertiesChanged = false;
				EditorUtility.SetDirty(target);
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}