using UnityEngine;
using UnityEditor;

namespace DrimiaInteractive.RtlHelperSystem.EditorUtilities
{
    [CustomEditor(typeof(RectTransformWithChildrenRtlHelper), true), CanEditMultipleObjects]
    public class RectTransformWithChildrenRtlHelperEditorPanel : RectTransformRtlHelperEditorPanel
    {
    }
}
