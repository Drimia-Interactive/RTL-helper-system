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
            var pivot = tComponent.pivot;
            var anchorMin = tComponent.anchorMin;
            var anchorMax = tComponent.anchorMax;
            var anchoredPosition = tComponent.anchoredPosition;

            tComponent.pivot = new Vector2(1-pivot.x, pivot.y);
            tComponent.anchorMin = new Vector2(1-anchorMin.x, anchorMin.y);
            tComponent.anchorMax = new Vector2(1-anchorMax.x, anchorMax.y);
            tComponent.anchoredPosition = new Vector2(1-anchoredPosition.x, anchoredPosition.y);
        }
    }
}
