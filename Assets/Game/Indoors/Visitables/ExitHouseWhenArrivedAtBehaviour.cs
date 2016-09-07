using Neighbourhood.Game.UnityIntegration.Implementation;
using Neighbourhood.Game.UnityIntegration;
using Zenject;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;
using Neighbourhood.Game.Places;
using UnityEngine;

namespace Neighbourhood.Game.Indoors.Visitables
{
	public interface IExitHouseView
	{
		IVisitableItem Item { get; }
	}

	[RequireComponent(typeof(VisitableItemBehaviour))]
	public class ExitHouseWhenArrivedAtBehaviour : BaseBehaviour<ExitHouseOnArrivalController, IExitHouseView>, IExitHouseView
	{
		public IVisitableItem Item { get { return GetComponent<VisitableItemBehaviour>(); } }
	}

	public class ExitHouseOnArrivalController : Controller<IExitHouseView>
	{
		[Inject] public PlayerArrivedAtDestinationSignal PlayerArrived { get; set; }
		[Inject] public ExitHouseCommand Exit { get; set; }

		public override void Init(IExitHouseView view)
		{
			base.Init(view);
			SubscribeToSignal(PlayerArrived,
				(IPlayerDestination dest) => {
					if (dest == View.Item)
					{
						Exit.Execute();
					}
				});
		}
	}
}

