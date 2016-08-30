using System;
using UnityEngine;
using Neighbourhood.Game.Abstractions.Components;

namespace Neighbourhood.Game.UnityIntegration.Components
{
	public class RigidbodyWrapper : IRigidbody
	{
		private readonly Rigidbody wrapped;

		public Vector3 Velocity
		{
			get { return wrapped.velocity; }
			set { wrapped.velocity = value; }
		}

		public RigidbodyWrapper(Rigidbody wrapped)
		{
			this.wrapped = wrapped;
		}

		public void ApplyForce(Vector3 force)
		{
			wrapped.AddForce(force);
		}
	}
}

