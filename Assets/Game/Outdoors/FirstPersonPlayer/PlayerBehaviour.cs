using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using Neighbourhood.Game.UnityIntegration.Implementation;

namespace Neighbourhood.Game.Outdoors.FirstPersonPlayer
{
	public interface IPlayer : IHasTransform
	{
	}

	public class PlayerBehaviour : BaseBehaviour, IPlayer
	{
	}
}
