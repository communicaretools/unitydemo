using Zenject;

namespace Neighbourhood.Game.Levels
{
	public class LevelInstaller : Installer<LevelInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<LoadLevelHandler>().ToSelf().AsSingle();
			Container.BindCommand<EnterHouseCommand, string>().To<LoadLevelHandler>(handler => handler.Enter);
			Container.BindCommand<ExitHouseCommand>().To<LoadLevelHandler>(handler => handler.Exit);
		}
	}
}

