using Neighbourhood.Game.UnityIntegration.Abstractions;
using Zenject;
using UnityEngine;

namespace Neighbourhood.Game.ThirdPersonPlayer
{
	public class UpdatePlayerDestinationFromInput : ITickable
	{
		readonly IInput input;
		readonly PlayerDestinationChangedSignal.Trigger trigger;
		readonly ICoordinateUtility coordinateUtility;

		public UpdatePlayerDestinationFromInput(IInput input, ICoordinateUtility coordinateUtility, PlayerDestinationChangedSignal.Trigger trigger)
		{
			this.coordinateUtility = coordinateUtility;
			this.input = input;
			this.trigger = trigger;
		}

		#region ITickable implementation

		public void Tick()
		{
			var screenPoint = input.GetSelectedPoint();
			if (screenPoint != Vector2.zero)
			{
				var worldPoint = coordinateUtility.ScreenPointToWorldPoint(screenPoint);
				if (worldPoint != Vector3.zero)
				{
					trigger.Fire(worldPoint);
				}
			}
		}

		#endregion
	}
}

