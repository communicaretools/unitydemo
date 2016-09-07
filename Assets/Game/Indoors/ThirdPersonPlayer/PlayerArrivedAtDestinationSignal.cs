using Zenject;
using UnityEngine;

namespace Neighbourhood.Game.Indoors.ThirdPersonPlayer
{
	public class PlayerArrivedAtDestinationSignal : Signal<IPlayerDestination>
	{
		public class Trigger : Signal<IPlayerDestination>.TriggerBase { }
	}
}

