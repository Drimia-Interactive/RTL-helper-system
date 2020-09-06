using UnityEngine;

namespace DrimiaInteractive.RtlHelperSystem
{
    [RequireComponent(typeof(RectTransform))]
    public class RectTransformRtlHelper : RtlHelperComponent<RectTransform>
    {
        protected override void RtlChanged()
        {
            ChangeAlignment();
        }
        
        private void ChangeAlignment()
        {
            ChangeRectAlignment(tComponent);
        }

        protected void ChangeRectAlignment(RectTransform rect)
        {
            var pivot = rect.pivot;
            var anchorMin = rect.anchorMin;
            var anchorMax = rect.anchorMax;
            var anchoredPosition = rect.anchoredPosition;

            rect.pivot = new Vector2(1-pivot.x, pivot.y);
            rect.anchorMin = new Vector2(1-anchorMax.x, anchorMin.y);
            rect.anchorMax = new Vector2(1-anchorMin.x, anchorMax.y);
            rect.anchoredPosition = new Vector2(-anchoredPosition.x, anchoredPosition.y);
        }
    }
}
