using System;
using UnityEngine;
using Zenject;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;

namespace Neighbourhood.Game.Indoors.Visitables
{
	[RequireComponent(typeof(VisitableItemBehaviour))]
	public class UntestableGlowWhenApproachedBehaviour : MonoBehaviour, IDisposable
	{
		bool glowing = false;
		Material originalMaterial;
		new Renderer renderer;
		IVisitableItem me;

		[Inject] PlayerDestinationChangedSignal DestinationChanged { get; set; }
		[Inject] PlayerArrivedAtDestinationSignal DestinationReached { get; set; }
		[Inject] VisitableGlobalSettings Settings { get; set; }

		[Inject]
		public void Init()
		{
			renderer = GetComponent<Renderer>();
			originalMaterial = renderer.material;
			me = GetComponent<IVisitableItem>();
			DestinationChanged.Event += GlowIfApproachingMe;
			DestinationReached.Event += StopGlowing;
		}

		void GlowIfApproachingMe(PlayerDestinationChangedSignal.Arguments args)
		{
			var supposedToGlow = args.Destination == me;
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
			Debug.Log("Start glowing: " + me.Name);
			renderer.material = Settings.GlowMaterial;
			glowing = true;
		}

		void StopGlowing()
		{
			Debug.Log("Stop glowing: " + me.Name);
			glowing = false;
			renderer.material = originalMaterial;
		}

		#region IDisposable implementation

		public void Dispose()
		{
			DestinationChanged.Event -= GlowIfApproachingMe;
			DestinationReached.Event -= StopGlowing;
		}

		#endregion
	}
}

