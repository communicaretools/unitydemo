using System;
using Zenject;
using Neighbourhood.Game.Outdoors.FirstPersonPlayer;
using Neighbourhood.Game.Outdoors.Houses;

namespace Neighbourhood.Game.Outdoors
{
	public class OutdoorsInstaller : MonoInstaller
	{
		public OutdoorSettings Settings;

		public override void InstallBindings()
		{
			PlayerInstaller.Install(Container, Settings.Player);
			HouseInstaller.Install(Container);
		}

		[Serializable]
		public class OutdoorSettings
		{
			public PlayerSettings Player;
		}
	}
}

