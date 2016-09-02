using UnityEngine;
using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using Neighbourhood.Game.UnityIntegration.Implementation.Components;
using Zenject;

namespace Neighbourhood.Game.ThirdPersonPlayer
{
	[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
	public class ThirdPersonMovementBehaviour : MonoBehaviour, IPlayerMovementBehaviour
	{
		NavMeshAgentWrapper agent;
		AnimatorWrapper animator;

		public INavMeshAgent NavMeshAgent { get { return agent; } }
		public IAnimator Animator { get { return animator; } }

		[Inject]
		public void Init(PlayerMovementController controller)
		{
			agent = new NavMeshAgentWrapper(GetComponent<NavMeshAgent>());
			animator = new AnimatorWrapper(GetComponent<Animator>());
			controller.Init(this);
		}
	}
}
