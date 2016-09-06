using System;
using Zenject;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;

namespace Neighbourhood.Game.Indoors.Visitables
{
	public class GlowWhenApproachedController : IDisposable
	{
		readonly PlayerDestinationChangedSignal destinationChanged;
		readonly PlayerArrivedAtDestinationSignal destinationReached;
		IGlowWhenApproached view;
		bool glowing;

		public GlowWhenApproachedController(PlayerDestinationChangedSignal destinationChanged, PlayerArrivedAtDestinationSignal destinationReached)
		{
			this.destinationChanged = destinationChanged;
			this.destinationReached = destinationReached;
		}

		public void InitView(IGlowWhenApproached view)
		{
			this.view = view;
			destinationChanged.Event += GlowIfApproachingMe;
			destinationReached.Event += StopGlowing;
		}

		void GlowIfApproachingMe(PlayerDestinationChangedSignal.Arguments args)
		{
			var supposedToGlow = args.Destination == view.Item;
			if (!supposedToGlow)
			{
				if (glowing)
				{
					StopGlowing();
				}
			} else
			{
				StartGlowing();
			}
		}

		void StartGlowing()
		{
			view.Glow();
			glowing = true;
		}

		void StopGlowing()
		{
			view.StopGlowing();
			glowing = false;
		}

		public void Dispose()
		{
			destinationChanged.Event -= GlowIfApproachingMe;
			destinationReached.Event -= StopGlowing;
		}
	}

}

