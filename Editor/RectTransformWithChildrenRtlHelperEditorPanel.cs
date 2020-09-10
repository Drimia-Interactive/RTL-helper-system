using UnityEngine;
using UnityEditor;

namespace DrimiaInteractive.RtlHelperSystem.EditorUtilities
{
    [CustomEditor(typeof(RectTransformWithChildrenRtlHelper), true), CanEditMultipleObjects]
    public class RectTransformWithChildrenRtlHelperEditorPanel : RectTransformRtlHelperEditorPanel
    {
        static readonly GUIContent includeSelfToggleLabel = new GUIContent("Include Self", "if to include this RectTransform or just change the children");

        protected SerializedProperty includeSelfProp;

        protected override void OnEnable()
        {
            base.OnEnable();
            includeSelfProp = serializedObject.FindProperty("includeSelf");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            includeSelfProp.boolValue = EditorGUILayout.Toggle(includeSelfToggleLabel, includeSelfProp.boolValue);
            ((RectTransformWithChildrenRtlHelper) tRtlHelper).includeSelf = includeSelfProp.boolValue;
        }
    }
}
