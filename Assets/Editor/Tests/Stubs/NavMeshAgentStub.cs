using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using UnityEngine;

namespace Neighbourhood.Editor.Tests.Stubs
{
	public class NavMeshAgentStub : INavMeshAgent
	{
		public Vector3 Destination { get; private set; }

		#region INavMeshAgent implementation

		public bool IsNavigating { get; set; }

		public void GoTowards(Vector3 point)
		{
			Destination = point;
		}

		#endregion
	}
}

