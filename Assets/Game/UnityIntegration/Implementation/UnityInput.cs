using System;
using Neighbourhood.Game.UnityIntegration.Abstractions;
using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration.Implementation
{
	public class UnityInput : IInput
	{
		public float GetHorizontal()
		{
			return Input.GetAxis("Horizontal");
		}

		public float GetVertical()
		{
			return Input.GetAxis("Vertical");
		}
	}
}

