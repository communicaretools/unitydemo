using Zenject;
using UnityEngine;

namespace Neighbourhood.Game.Indoors.ThirdPersonPlayer
{
	public class PlayerDestinationChangedSignal : Signal<Vector3>
	{
		public class Trigger : Signal<Vector3>.TriggerBase { }
	}
}
