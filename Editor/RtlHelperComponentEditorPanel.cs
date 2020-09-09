using UnityEditor;
using UnityEngine;

namespace DrimiaInteractive.RtlHelperSystem.EditorUtilities
{
    public abstract class RtlHelperComponentEditorPanel<T> : Editor
    {
        static readonly GUIContent k_RtlToggleLabel = new GUIContent("Enable RTL", "Reverses text direction and Alignment.");
        static readonly GUIContent k_ref = new GUIContent("reference", "Just the reference to see that is works");
        
        protected bool m_HavePropertiesChanged;
        
        protected SerializedProperty m_IsRightToLeftProp;
        protected SerializedProperty tComponent;

        protected RtlHelperComponent<T> tRtlHelper;
        
        protected virtual void OnEnable()
        {
            tComponent = serializedObject.FindProperty("tComponent");
            m_IsRightToLeftProp = serializedObject.FindProperty("m_isRightToLeft");

            tRtlHelper = (RtlHelperComponent<T>)target;
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            m_IsRightToLeftProp.boolValue = EditorGUILayout.Toggle(k_RtlToggleLabel, m_IsRightToLeftProp.boolValue);
            tRtlHelper.isRightToLeftText = m_IsRightToLeftProp.boolValue;

            EditorGUILayout.ObjectField(tComponent, k_ref);

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
