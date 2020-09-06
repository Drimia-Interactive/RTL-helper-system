using System.Collections.Generic;
using UnityEngine;

namespace DrimiaInteractive.RtlHelperSystem
{
	public class RtlHelperSystemManager : MonoBehaviour
	{
		private static RtlHelperSystemManager instance = null;

		public static RtlHelperSystemManager Instance
		{
			get
			{
				if (applicationIsQuitting)
				{
					return null;
				}
				if (instance == null)
				{
					instance = FindObjectOfType<RtlHelperSystemManager>();
					// fallback, might not be necessary.
					if (instance == null)
						instance = new GameObject(typeof(RtlHelperSystemManager).Name).AddComponent<RtlHelperSystemManager>();
					DontDestroyOnLoad(instance.gameObject);
				}

				return instance;
			}
		}
		
		private static bool applicationIsQuitting = false;
		public void OnDestroy()
		{
			applicationIsQuitting = true;
		}

		private bool m_isRightToLeft = false;

		public bool isRightToLeft
		{
			get { return m_isRightToLeft; }
			set
			{
				if (m_isRightToLeft == value)
					return;
				m_isRightToLeft = value;
				ChangeRtlState();
			}
		}

		public List<RtlHelperComponentNoGeneric> allRtlHelperComponents = new List<RtlHelperComponentNoGeneric>();

		public void RegisterRtlHelperComponent(RtlHelperComponentNoGeneric component)
		{
			allRtlHelperComponents.Add(component);
		}

		public void UnregisterRtlHelperComponent(RtlHelperComponentNoGeneric component)
		{
			allRtlHelperComponents.Remove(component);
		}

		private void ChangeRtlState()
		{
			foreach (RtlHelperComponentNoGeneric rtlHelperComponent in allRtlHelperComponents)
			{
				rtlHelperComponent.isRightToLeftText = m_isRightToLeft;
			}
		}
	}
}