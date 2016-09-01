using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration.Implementation.Components
{
	public class TransformWrapper : ITransform
	{
		readonly Transform wrapped;

		public TransformWrapper (Transform wrapped)
		{
			this.wrapped = wrapped;
		}

		#region ITransform implementation

		public Vector3 Position {
			get { return wrapped.position; }
			set { wrapped.position = value; }
		}

		public Vector3 Forward {
			get { return wrapped.forward; }
		}

		public void Rotate(float x, float y, float z)
		{
			wrapped.Rotate(x, y, z);
		}

		#endregion
	}
}

