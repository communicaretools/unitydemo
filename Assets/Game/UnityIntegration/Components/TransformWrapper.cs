using System;
using Neighbourhood.Game.Abstractions.Components;
using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration.Components
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

		#endregion
	}
}

