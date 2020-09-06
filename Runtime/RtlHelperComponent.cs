using System;
using UnityEngine;

namespace DrimiaInteractive.RtlHelperSystem
{
	public abstract class RtlHelperComponentNoGeneric: MonoBehaviour
	{
		[SerializeField] protected bool m_isRightToLeft = false;
        
		public bool isRightToLeftText
		{
			get => m_isRightToLeft;
			set
			{
				if (m_isRightToLeft == value)
					return;
				m_isRightToLeft = value;
				RtlChanged();
			}
		}

		protected abstract void RtlChanged();

		private void OnEnable()
		{
			RtlHelperSystemManager.Instance.RegisterRtlHelperComponent(this);
			isRightToLeftText = RtlHelperSystemManager.Instance.isRightToLeft;
		}

		private void OnDisable()
		{
			if (RtlHelperSystemManager.Instance != null)
			{
				RtlHelperSystemManager.Instance.UnregisterRtlHelperComponent(this);
			}
		}
	}
	public abstract class RtlHelperComponent<T> : RtlHelperComponentNoGeneric
    {
        [SerializeField] protected T tComponent;

		protected void Awake()
        {
        	if (tComponent == null)
        	{
				tComponent = GetComponent<T>();
        	}
        }

        public void Reset()
        {
			tComponent = GetComponent<T>();
        }
    }
}
