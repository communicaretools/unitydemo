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

			Container.Bind<InputState>().AsSingle();
			Container.Bind<TouchInput>().ToSelf().FromGameObject().AsSingle().NonLazy();
			Container.Bind<ITickable>().To<KeyboardInput>().AsSingle();  // must be bound before PlayerMoveHandler
			Container.Bind<MovePlayerController>().ToSelf().AsTransient();
		}

		void BindSettings()
		{
			// these two lines are equivalent
			Container.Bind<PlayerSettings.Movement>().ToSelf().FromInstance(settings.MovementSettings);
			Container.BindInstance(settings.TouchInputSettings);
		}
	}
}

