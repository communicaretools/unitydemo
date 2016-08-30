using System;
using Zenject;
using Neighbourhood.Game.Abstractions;

namespace Neighbourhood.Game.UnityIntegration
{
	public class UnityIntegrationInstaller : Installer<UnityIntegrationInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<IInput>().To<UnityInput>().AsSingle();
		}
	}
}

