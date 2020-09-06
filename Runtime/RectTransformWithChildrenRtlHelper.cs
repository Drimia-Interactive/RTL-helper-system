using UnityEngine;

namespace DrimiaInteractive.RtlHelperSystem
{
    public class RectTransformWithChildrenRtlHelper : RectTransformRtlHelper
    {
        protected override void RtlChanged()
        {
            base.RtlChanged();
            ChangeAlignmentForChildren();
        }

        private void ChangeAlignmentForChildren()
        {
            var allChildrenRectTransforms = GetComponentsInChildren<RectTransform>();
            foreach (var childRectTransform in allChildrenRectTransforms)
            {
                if (childRectTransform == tComponent)
                {
                    continue;
                }
                ChangeRectAlignment(childRectTransform);
            }
        }
    }
}
