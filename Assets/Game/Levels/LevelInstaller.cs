using Zenject;

namespace Neighbourhood.Game.Levels
{
	public class LevelInstaller : Installer<LevelInstaller>
	{
		public override void InstallBindings()
		{
			Container.BindCommand<EnterHouseCommand, string>().To<LoadLevelHandler>(handler => handler.Enter);
		}
	}
}

