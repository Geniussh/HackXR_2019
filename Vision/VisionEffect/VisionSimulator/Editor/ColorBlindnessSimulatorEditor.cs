using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace Vision.VisionEffect.ColorBlind
{
	[CustomEditor(typeof(VisionSimulator))]
	public class ColorBlindnessSimulatorEditor : Editor
	{
		private VisionSimulator Target
		{
			get
			{
				if (__Target == null) __Target = (VisionSimulator)target;
				return __Target;
			}
		}
		private VisionSimulator __Target;
	
		public override void OnInspectorGUI()
		{
			Target.BlindMode =  (VisionSimulator.ColorBlindMode)EditorGUILayout.EnumPopup("Color Blind Type:", Target.BlindMode);
			switch (Target.BlindMode)
			{
				case VisionSimulator.ColorBlindMode.Protanope:
					GUILayout.BeginVertical("box");
					GUILayout.Label("Protanope(Type I):\nRed Weakness.\n1% of males, 0.01% of females.");
					GUILayout.EndVertical();
					break;
				case VisionSimulator.ColorBlindMode.Deuteranope:
					GUILayout.BeginVertical("box");
					GUILayout.Label("Deuteranope(Type II):\nGreen Weakness.\nmost common—6% of males, 0.4% of females");
					GUILayout.EndVertical();
					break;
				default:
					break;
			}
			

			Target.BlindIntensity = EditorGUILayout.Slider("Simulate Intensity", Target.BlindIntensity, 0.0f, 1.0f);

			if(GUI.changed)
			{
				EditorUtility.SetDirty(Target);
			}
		}

		//Menu Item
		[MenuItem("GULTI/Attach Color Blindness Simulator")]
		public static void AttachCBSimulatorFromMenu()
		{
			var sel = Selection.activeGameObject;
			if (sel != null)
				sel.AddComponent<VisionSimulator>();
			else
				Debug.LogError("Select any GameObject.");
		}
	}
}