using System;
using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration.Abstractions.Components
{
	public interface IRigidbody
	{
		Vector3 Velocity { get; set; }
		void ApplyForce(Vector3 force);
	}
}
