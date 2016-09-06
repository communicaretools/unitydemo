using Zenject;
using UnityEngine;

namespace Neighbourhood.Game.Indoors.ThirdPersonPlayer
{
	public class PlayerDestinationChangedSignal : Signal<PlayerDestinationChangedSignal.Arguments>
	{
		public class Trigger : Signal<PlayerDestinationChangedSignal.Arguments>.TriggerBase { }

		public class Arguments
		{
			public object Sender { get; set; }
			public Vector3 Destination { get; set; }
		}
	}
}
