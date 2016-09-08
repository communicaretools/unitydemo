using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using Neighbourhood.Game.UnityIntegration.Implementation;
using Zenject;

namespace Neighbourhood.Game.Outdoors.FirstPersonPlayer
{
	public interface IMovePlayerView : IHasTransform
	{
	}

	public class MovePlayerBehaviour : BaseBehaviour, IMovePlayerView
	{
		[Inject]
		public void Init(MovePlayerController controller)
		{
			controller.Init(this);
		}
	}
}
