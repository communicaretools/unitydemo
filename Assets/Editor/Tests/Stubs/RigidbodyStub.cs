using System;
using Neighbourhood.Game.Abstractions.Components;
using UnityEngine;

namespace Neighbourhood.Editor.Tests.Stubs
{
	public class RigidbodyStub : IRigidbody
	{
		public Vector3 NetForceApplied { get; private set; }

		#region IRigidbody implementation

		public void ApplyForce(UnityEngine.Vector3 force)
		{
			NetForceApplied += force;
		}

		public UnityEngine.Vector3 Velocity {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion
	}
}
