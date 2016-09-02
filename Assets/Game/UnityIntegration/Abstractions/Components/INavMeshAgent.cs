using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration.Abstractions.Components
{

	public interface INavMeshAgent
	{
		bool IsNavigating { get; }
		void GoTowards(Vector3 point);
	}
}
