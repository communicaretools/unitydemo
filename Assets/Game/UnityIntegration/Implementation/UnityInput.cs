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

		public Vector2 GetSelectedPoint()
		{
			if (Input.touchCount > 0)
			{
				return Input.GetTouch(0).position;
			}
			else if (Input.mousePresent && Input.GetMouseButtonDown(0))
			{
				return Input.mousePosition;
			}
			return Vector2.zero;
		}
	}
}

