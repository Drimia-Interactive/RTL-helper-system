using UnityEngine;

namespace DrimiaInteractive.RtlHelperSystem
{
    public class RectTransformWithChildrenRtlHelper : RectTransformRtlHelper
    {
        public bool includeSelf;
        protected override void RtlChanged()
        {
            if (includeSelf)
            {
                base.RtlChanged();
            }

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
