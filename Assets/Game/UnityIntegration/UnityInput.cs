using System;
using Neighbourhood.Game.Abstractions;
using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration
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

