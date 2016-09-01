using Neighbourhood.Game.UnityIntegration.Abstractions;

namespace Neighbourhood.Editor.Tests.Stubs
{
	public class InputStub : IInput
	{
		public float Horizontal { get; set; }
		public float Vertical { get; set; }

		#region IInput implementation

		public float GetHorizontal()
		{
			return Horizontal;
		}

		public float GetVertical()
		{
			return Vertical;
		}

		#endregion
	}
}

