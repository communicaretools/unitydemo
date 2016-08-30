using System;
using Zenject;

namespace Neighbourhood.Game.UnityIntegration
{
	public class UnityIntegrationInstaller : Installer<UnityIntegrationInstaller>
	{
		public override void InstallBindings()
		{
			Container.BindAllInterfaces<UnityInput>().AsSingle();
		}
	}
}

