using UnityEngine;
using UnityEditor;

namespace DrimiaInteractive.RtlHelperSystem.EditorUtilities
{
    [CustomEditor(typeof(RectTransformRtlHelper), true), CanEditMultipleObjects]
    public class RectTransformRtlHelperEditorPanel : RtlHelperComponentEditorPanel<RectTransform>
    {
    }
}
