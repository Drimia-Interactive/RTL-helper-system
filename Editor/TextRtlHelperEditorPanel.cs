using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.UI;
#if PACKAGE_UnityLocalization
using UnityEditor.Localization;
using UnityEngine.Localization.Components;
#endif

namespace DrimiaInteractive.RtlHelperSystem.EditorUtilities
{
	[CustomEditor(typeof(TextRtlHelper), true), CanEditMultipleObjects]
	public class TextRtlHelperEditorPanel : RtlHelperComponentEditorPanel<Text>
	{
		static readonly GUIContent fixTextToggleLabel = new GUIContent("Fix Text With RTL Change", "true: fix the text automatic with the RTL change.\n" +
																								   "false: fix the text with using on the function OnTextChanged");

		protected SerializedProperty fixTextWithRtlChangeProp;

		protected override void OnEnable()
		{
			base.OnEnable();
			fixTextWithRtlChangeProp = serializedObject.FindProperty("fixTextWithRtlChange");
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			fixTextWithRtlChangeProp.boolValue = EditorGUILayout.Toggle(fixTextToggleLabel, fixTextWithRtlChangeProp.boolValue);
			((TextRtlHelper) tRtlHelper).fixTextWithRtlChange = fixTextWithRtlChangeProp.boolValue;
		}
		
		[MenuItem("CONTEXT/Text/RtlHelper")]
		static void RtlHelpUIText(MenuCommand command)
		{
			var target = command.context as Text;
			SetupForRtlHelper(target);
		}
		
		public static MonoBehaviour SetupForRtlHelper(Text target)
		{
			var comp = Undo.AddComponent(target.gameObject, typeof(TextRtlHelper)) as TextRtlHelper;
			
#if PACKAGE_UnityLocalization
			var localizeStringEvent = comp.GetComponent<LocalizeStringEvent>();
			if (localizeStringEvent != null)
			{
				UnityEventTools.AddPersistentListener(localizeStringEvent.OnUpdateString, comp.OnTextChanged);
			}
#endif

			return comp;
		}
		
		
		
#if PACKAGE_UnityLocalization
		[MenuItem("CONTEXT/Text/Localize and RtlHelper")]
		static void RtlHelpAndLocalizeUIText(MenuCommand command)
		{
			var target = command.context as Text;
			SetupForRtlHelperAndLocalize(target);
		}
		
		public static MonoBehaviour SetupForRtlHelperAndLocalize(Text target)
		{
			
			SetupForLocalization(target);
			var comp = SetupForRtlHelper(target);
			return comp;
		}
		
		/// <summary>
		/// this function calls the function SetupForLocalization of the class LocalizeComponent_UGUI from the Unity's localization package
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public static MonoBehaviour SetupForLocalization(Text target)
		{
			Assembly assembly = Assembly.GetAssembly(typeof(LocalizationEditorSettings));
			BindingFlags bf = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;//BindingFlags.Instance |  BindingFlags.NonPublic;
			Type t = assembly.GetType("UnityEditor.Localization.Plugins.UGUI.LocalizeComponent_UGUI");
			
			CallingConventions callConvention = CallingConventions.Any;
			Type[] types = new Type[]{typeof(Text)};
			ParameterModifier[] modifiers = new ParameterModifier[0];
			
			MethodInfo mi = t.GetMethod("SetupForLocalization", bf, null, callConvention, types, modifiers);
			
			object[] parameters = new object[]{target};
			var mono = mi.Invoke(null, parameters);
			return (MonoBehaviour) mono;

		}
#endif
	}
}