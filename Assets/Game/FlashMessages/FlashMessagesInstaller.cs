using Zenject;

namespace Neighbourhood.Game.FlashMessages
{
	public class FlashMessagesInstaller : Installer<FlashMessageSettings, FlashMessagesInstaller>
	{
		readonly FlashMessageSettings settings;

		public FlashMessagesInstaller(FlashMessageSettings settings)
		{
			this.settings = settings;
		}

		public override void InstallBindings()
		{
			Container.Bind<FlashMessageSettings>().ToSelf().FromInstance(settings);
			Container.Bind<FlashMessageStore>().ToSelf().AsSingle();
			Container.BindCommand<ShowMessageCommand, string>().To<FlashMessageStore>(x => x.HandleShowMessage).AsSingle();
		}
	}
}

