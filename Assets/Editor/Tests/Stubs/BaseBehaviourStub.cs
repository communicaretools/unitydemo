using Neighbourhood.Game.UnityIntegration.Abstractions.Components;

namespace Neighbourhood.Editor.Tests.Stubs
{
	public class BaseBehaviourStub
		: IHasTransform,
		  IHasRigidbody,
		  IHasAnimator,
		  IHasNavMeshAgent
	{
		public TransformStub Transform { get; private set; }
		public RigidbodyStub Rigidbody { get; private set; }
		public AnimatorStub Animator { get; private set; }
		public NavMeshAgentStub NavMeshAgent { get; private set; }

		public BaseBehaviourStub()
		{
			Transform = new TransformStub();
			Rigidbody = new RigidbodyStub();
			Animator = new AnimatorStub();
			NavMeshAgent = new NavMeshAgentStub();
		}

		#region IHasTransform implementation
		ITransform IHasTransform.Transform { get { return Transform; } }
		#endregion

		#region IHasRigidbody implementation
		IRigidbody IHasRigidbody.Rigidbody { get { return Rigidbody; } }
		#endregion

		#region IHasAnimator implementation
		IAnimator IHasAnimator.Animator { get { return Animator; } }
		#endregion

		#region IHasNavMeshAgent implementation
		INavMeshAgent IHasNavMeshAgent.NavMeshAgent { get { return NavMeshAgent; } }
		#endregion
		
	}
	
}
