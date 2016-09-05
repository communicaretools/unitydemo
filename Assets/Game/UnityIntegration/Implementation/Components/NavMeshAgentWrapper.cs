using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration.Implementation.Components
{
	public class NavMeshAgentWrapper : INavMeshAgent
	{
		readonly UnityEngine.AI.NavMeshAgent wrapped;

		public NavMeshAgentWrapper(UnityEngine.AI.NavMeshAgent wrapped)
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

