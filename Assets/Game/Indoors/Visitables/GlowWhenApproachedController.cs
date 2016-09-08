using System;
using Zenject;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;

namespace Neighbourhood.Game.Indoors.Visitables
{
	public class GlowWhenApproachedController : IDisposable
	{
		[Inject] public PlayerDestinationChangedSignal DestinationChanged { get; set; }
		[Inject] public PlayerArrivedAtDestinationSignal DestinationReached { get; set; }

		IGlowWhenApproached view;
		bool glowing;

		public void InitView(IGlowWhenApproached view)
		{
			this.view = view;
			DestinationChanged.Event += GlowIfApproachingMe;
			DestinationReached.Event += StopGlowing;
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

		void StopGlowing(IPlayerDestination destination = null)
		{
			view.StopGlowing();
			glowing = false;
		}

		public void Dispose()
		{
			if (DestinationChanged != null) { DestinationChanged.Event -= GlowIfApproachingMe; }
			if (DestinationReached != null) { DestinationReached.Event -= StopGlowing; }
			DestinationChanged = null;
			DestinationReached = null;
		}
	}

}

