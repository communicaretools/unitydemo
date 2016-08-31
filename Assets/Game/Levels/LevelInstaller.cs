using Zenject;

namespace Neighbourhood.Game.Levels
{
	public class LevelInstaller : Installer<LevelInstaller>
	{
		public override void InstallBindings()
		{
			Container.BindCommand<LoadLevelCommand, string>().To<LoadLevelHandler>(handler => handler.Load);
		}
	}
}

