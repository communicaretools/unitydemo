using System;
using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration.Abstractions
{
	/// <summary>
	/// Abstraction over Unity's input; describes the state
	/// of the input controls at the current point in time
	/// </summary>
	public interface IInput
	{
		/// <summary>
		/// Get left/right input magnitude
		/// </summary>
		float GetHorizontal();
		/// <summary>
		/// Get up/down input magnitude
		/// </summary>
		float GetVertical();
		/// <summary>
		/// Get the point currently clicked or touched,
		/// or Vector2.zero in case of no touch/click
		/// </summary>
		Vector2 GetSelectedPoint();
	}
}
