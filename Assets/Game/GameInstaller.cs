using System;
using Zenject;
using Neighbourhood.Game.Player;
using Neighbourhood.Game.UnityIntegration;

namespace Neighbourhood.Game
{
	public class GameInstaller : MonoInstaller
	{
		public GameSettings Settings;

		public override void InstallBindings()
		{
			PlayerInstaller.Install(Container, Settings.Player);
			UnityIntegrationInstaller.Install(Container);
		}

		[Serializable]
		public class GameSettings
		{
			public PlayerSettings Player;
		}
	}
}

