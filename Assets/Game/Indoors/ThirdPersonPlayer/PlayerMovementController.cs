using System;
using Zenject;
using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using UnityEngine;

namespace Neighbourhood.Game.Indoors.ThirdPersonPlayer
{
	public interface IPlayerMovementBehaviour : IHasAnimator, IHasNavMeshAgent { }

	public class PlayerMovementController : IInitializable, IDisposable, ITickable
	{
		enum NavigationState {Idle, Starting, Walking}
		readonly PlayerDestinationChangedSignal onNewDestination;
		readonly PlayerArrivedAtDestinationSignal.Trigger arrivalTrigger;
		INavMeshAgent navigator;
		IAnimator animator;
		NavigationState navigating;

		public PlayerMovementController(PlayerDestinationChangedSignal onNewDestination, PlayerArrivedAtDestinationSignal.Trigger arrivalTrigger)
		{
			this.onNewDestination = onNewDestination;
			this.arrivalTrigger = arrivalTrigger;
		}

		public void Init(IPlayerMovementBehaviour behaviour)
		{
			navigator = behaviour.NavMeshAgent;
			animator = behaviour.Animator;
		}

		void GoTowards(PlayerDestinationChangedSignal.Arguments @event)
		{
			navigator.GoTowards(@event.Destination);
			animator.SetBool("Walking", true);
			navigating = NavigationState.Starting;
		}

		void Stop()
		{
			animator.SetBool("Walking", false);
			arrivalTrigger.Fire();
			navigating = NavigationState.Idle;
		}

		public void Tick()
		{
			if (navigating == NavigationState.Walking && !navigator.IsNavigating)
			{
				Stop();
			}
			if (navigator.IsNavigating)
			{
				navigating = NavigationState.Walking;
			}
		}

		void IInitializable.Initialize()
		{
			onNewDestination.Event += GoTowards;
		}

		void IDisposable.Dispose()
		{
			onNewDestination.Event -= GoTowards;
		}
	}
}

