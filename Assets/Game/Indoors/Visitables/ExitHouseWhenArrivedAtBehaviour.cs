using Neighbourhood.Game.UnityIntegration.Implementation;
using Neighbourhood.Game.UnityIntegration;
using Zenject;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;
using Neighbourhood.Game.Levels;

namespace Neighbourhood.Game.Indoors.Visitables
{
	public interface IExitHouseView
	{
	}

	public class ExitHouseWhenArrivedAtBehaviour : BaseBehaviour<ExitHouseOnArrivalController, IExitHouseView>, IExitHouseView
	{
	}

	public class ExitHouseOnArrivalController : Controller<IExitHouseView>
	{
		[Inject] PlayerArrivedAtDestinationSignal PlayerArrived { get; set; }
		[Inject] ExitHouseCommand Exit { get; set; }

		public override void Init(IExitHouseView view)
		{
			base.Init(view);
			SubscribeToSignal(PlayerArrived,
				(IPlayerDestination dest) =>
				{
					Exit.Execute();
				});
		}
	}
}

