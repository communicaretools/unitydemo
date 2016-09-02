using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration.Abstractions
{
	/// <summary>
	/// Utility to convert coordinates between differenct spaces
	/// </summary>
	public interface ICoordinateUtility
	{
		/// <summary>
		/// Converts a screen coordinate to a 3D world point
		/// through raycasting from the main camera
		/// </summary>
		Vector3 ScreenPointToWorldPoint(Vector2 screenCoordinate);
	}
}

