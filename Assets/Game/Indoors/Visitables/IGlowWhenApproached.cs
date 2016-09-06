using System;
using Zenject;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;

namespace Neighbourhood.Game.Indoors.Visitables
{
	public interface IGlowWhenApproached
	{
		IVisitableItem Item { get; }
		void Glow();
		void StopGlowing();
	}

}
