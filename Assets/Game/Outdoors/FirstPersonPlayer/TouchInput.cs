using System;
using UnityEngine;
using Zenject;

namespace Neighbourhood.Game.Outdoors.FirstPersonPlayer
{
	public class TouchInput : MonoBehaviour
	{
		[Inject] public InputState InputState { get; set; }
		[Inject] public PlayerSettings.TouchInputDimensions Settings { get; set; }

		bool useTouch = false;

		void OnGUI()
		{
			if (Settings == null)
			{
				return;
			}

			var width = 3 * Settings.ButtonSize + 4 * Settings.Spacing;
			var height = 2 * Settings.ButtonSize + 2 * Settings.Spacing;
			var left = Screen.width - width;
			var top = Screen.height - height;

			GUI.Box(new Rect(left, top - 3 * Settings.Spacing, width, height + 3 * Settings.Spacing), "Move!");
			useTouch = GUI.Toggle(new Rect(left + Settings.Spacing, top - 2 * Settings.Spacing, width - Settings.Spacing, 2*Settings.Spacing), useTouch, "Use touch");
			InputState.Source = useTouch ? InputSource.Touch : InputSource.Input;

			if (!useTouch)
			{
				return;  // won't render keys until enabled
			}

			InputState.Direction = MovementDirection.Still;
			if (GUI.RepeatButton(new Rect(left + Settings.ButtonSize + Settings.Spacing*2, top + Settings.Spacing, Settings.ButtonSize, Settings.ButtonSize), "▲"))
			{
				InputState.Direction = MovementDirection.Forward;
			}
			if (GUI.RepeatButton(new Rect(left + Settings.ButtonSize + Settings.Spacing*2, top + height/2 + Settings.Spacing, Settings.ButtonSize, Settings.ButtonSize), "▼"))
			{
				InputState.Direction = MovementDirection.Backward;
			}

			InputState.Rotation = RotationDirection.None;
			if (GUI.RepeatButton(new Rect(left + Settings.Spacing,  top + height/2 + Settings.Spacing, Settings.ButtonSize, Settings.ButtonSize), "◀"))
			{
				InputState.Rotation = RotationDirection.Left;
			}
			if (GUI.RepeatButton(new Rect(left + Settings.ButtonSize*2 + Settings.Spacing*3, top + height/2 + Settings.Spacing, Settings.ButtonSize, Settings.ButtonSize), "▶"))
			{
				InputState.Rotation = RotationDirection.Right;
			}
		}
	}
}

