using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration.Implementation.Components
{
	public class NavMeshAgentWrapper : INavMeshAgent
	{
		readonly NavMeshAgent wrapped;

		public NavMeshAgentWrapper(NavMeshAgent wrapped)
		{
			this.wrapped = wrapped;
		}

		#region INavMeshAgent implementation

		public void GoTowards(Vector3 point)
		{
			wrapped.destination = point;
		}

		public bool IsNavigating { get { return wrapped.hasPath; } }

		#endregion
	}
}

