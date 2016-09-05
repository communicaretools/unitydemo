using System;
using Zenject;

namespace Neighbourhood.Game.Outdoors.FirstPersonPlayer
{
	public class PlayerInstaller : Installer<PlayerSettings, PlayerInstaller>
	{
		readonly PlayerSettings settings;

		public PlayerInstaller(PlayerSettings settings)
		{
			this.settings = settings;
		}

		public override void InstallBindings()
		{
			BindSettings();

			Container.Bind<IPlayer>().To<PlayerBehaviour>().FromMethod(x => settings.Player);
			Container.Bind<InputState>().AsSingle();
			Container.Bind<ITickable>().To<KeyboardInput>().AsSingle();  // must be bound before PlayerMoveHandler
			Container.Bind<ITickable>().To<PlayerMoveHandler>().AsSingle();
		}

		void BindSettings()
		{
			Container.Bind<PlayerSettings.Movement>().ToSelf().FromInstance(settings.MovementSettings);
		}
	}
}

