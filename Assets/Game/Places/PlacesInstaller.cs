using Zenject;

namespace Neighbourhood.Game.Places
{
	public class PlacesInstaller : Installer<PlacesInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<LoadPlacesHandler>().ToSelf().AsSingle();
			Container.BindCommand<EnterHouseCommand, string>().To<LoadPlacesHandler>(handler => handler.Enter);
			Container.BindCommand<ExitHouseCommand>().To<LoadPlacesHandler>(handler => handler.Exit);
		}
	}
}

