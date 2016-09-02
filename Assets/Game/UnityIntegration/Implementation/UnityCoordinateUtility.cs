using Neighbourhood.Game.UnityIntegration.Abstractions;
using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration.Implementation
{
	public class UnityCoordinateUtility : ICoordinateUtility
	{
		RaycastHit hitInfo;  // declared here to avoid local allocation

		#region ICoordinateUtility implementation
		public Vector3 ScreenPointToWorldPoint(Vector2 screenCoordinate)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
			{
				return hitInfo.point;
			}

			return Vector3.zero;
		}
		#endregion
	}
}

