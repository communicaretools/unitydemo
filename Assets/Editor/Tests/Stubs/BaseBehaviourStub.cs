using Neighbourhood.Game.UnityIntegration.Abstractions.Components;

namespace Neighbourhood.Editor.Tests.Stubs
{
	public class BaseBehaviourStub : IHasTransform, IHasRigidbody
	{
		public TransformStub Transform { get; private set; }
		public RigidbodyStub Rigidbody { get; private set; }

		public BaseBehaviourStub()
		{
			Transform = new TransformStub();
			Rigidbody = new RigidbodyStub();
		}

		#region IHasTransform implementation
		ITransform IHasTransform.Transform { get { return Transform; } }
		#endregion

		#region IHasRigidbody implementation

		IRigidbody IHasRigidbody.Rigidbody { get { return Rigidbody; } }

		#endregion
		
	}
	
}
