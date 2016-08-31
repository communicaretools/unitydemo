using Zenject;

namespace Neighbourhood.Game.FlashMessages
{
	public class FlashMessagesInstaller : Installer<FlashMessagesInstaller>
	{
		public override void InstallBindings()
		{
			Container.BindCommand<ShowMessageCommand, string>().To<ShowMessageHandler>(x => x.Handle).AsSingle();
		}
	}
}

