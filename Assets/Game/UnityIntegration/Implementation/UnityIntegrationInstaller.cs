using System;
using Zenject;
using Neighbourhood.Game.UnityIntegration.Abstractions;

namespace Neighbourhood.Game.UnityIntegration.Implementation
{
	public class UnityIntegrationInstaller : Installer<UnityIntegrationInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<IInput>().To<UnityInput>().AsSingle();
			Container.Bind<ICoordinateUtility>().To<UnityCoordinateUtility>().AsSingle();
		}
	}
}

