using Neighbourhood.Game.UnityIntegration.Abstractions;
using UnityEngine;

namespace Neighbourhood.Editor.Tests.Stubs
{
	public class InputStub : IInput
	{
		public float Horizontal { get; set; }
		public float Vertical { get; set; }
		public Vector2 SelectedPoint { get;set; }

		#region IInput implementation
		public float GetHorizontal()
		{
			return Horizontal;
		}

		public float GetVertical()
		{
			return Vertical;
		}

		public Vector2 GetSelectedPoint()
		{
			return SelectedPoint;
		}
		#endregion
	}
}

