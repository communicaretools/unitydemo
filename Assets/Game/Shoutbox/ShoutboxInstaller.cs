using Zenject;

namespace Neighbourhood.Game.Shoutbox
{
	public class ShoutboxInstaller : Installer<ShoutboxInstaller>
	{
		public override void InstallBindings()
		{
			Container.BindCommand<ShowMessageCommand, string>().To<ShowMessageHandler>(x => x.Handle).AsSingle();
		}
	}
}

