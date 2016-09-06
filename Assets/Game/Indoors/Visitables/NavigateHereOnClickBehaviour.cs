using UnityEngine;
using Zenject;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;

namespace Neighbourhood.Game.Indoors.Visitables
{
	[RequireComponent(typeof(Collider))]
	public class NavigateHereOnClickBehaviour : MonoBehaviour
	{
		[Inject] PlayerDestinationChangedSignal.Trigger ScheduleNavigation { get; set; }

		void OnMouseUpAsButton()
		{
			ScheduleNavigation.Fire(new PlayerDestinationChangedSignal.Arguments {Sender = gameObject, Destination = transform.position});
		}
	}
}
