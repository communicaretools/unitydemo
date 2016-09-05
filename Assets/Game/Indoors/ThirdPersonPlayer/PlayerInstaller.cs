using System;
using Zenject;

namespace Neighbourhood.Game.Indoors.ThirdPersonPlayer
{
	public class PlayerInstaller : Installer<PlayerInstaller>
	{
		public override void InstallBindings()
		{
			Container.BindSignal<PlayerDestinationChangedSignal>();
			Container.BindTrigger<PlayerDestinationChangedSignal.Trigger>();
			Container.BindSignal<PlayerArrivedAtDestinationSignal>();
			Container.BindTrigger<PlayerArrivedAtDestinationSignal.Trigger>();

			Container.BindAllInterfacesAndSelf<UpdatePlayerDestinationFromInput>().To<UpdatePlayerDestinationFromInput>().AsSingle().NonLazy();
			Container.BindAllInterfacesAndSelf<PlayerMovementController>().To<PlayerMovementController>().AsSingle();
		}
	}
}

