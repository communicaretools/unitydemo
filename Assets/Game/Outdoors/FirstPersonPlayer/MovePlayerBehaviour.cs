using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using Neighbourhood.Game.UnityIntegration.Implementation;
using Zenject;
using UnityEngine;

namespace Neighbourhood.Game.Outdoors.FirstPersonPlayer
{
	public interface IMovePlayerView : IHasTransform
	{
	}

	public class MovePlayerBehaviour : BaseBehaviour, IMovePlayerView
	{
		MovePlayerController controller;

		[Inject]
		public void Init(MovePlayerController controller)
		{
			this.controller = controller;
			controller.Init(this);
		}

		void Update()
		{
			controller.Update(Time.deltaTime);
		}
	}
}
