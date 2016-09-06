using UnityEngine;
using Zenject;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;

namespace Neighbourhood.Game.Indoors.Visitables
{
	[RequireComponent(typeof(Collider), typeof(VisitableItemBehaviour))]
	public class NavigateHereOnClickBehaviour : MonoBehaviour
	{
		[Inject] PlayerDestinationChangedSignal.Trigger ScheduleNavigation { get; set; }

		void OnMouseUpAsButton()
		{
			ScheduleNavigation.Fire(new PlayerDestinationChangedSignal.Arguments
				{
					Destination = GetComponent<VisitableItemBehaviour>(),
					Coordinate = transform.position
				});
		}
	}
}
