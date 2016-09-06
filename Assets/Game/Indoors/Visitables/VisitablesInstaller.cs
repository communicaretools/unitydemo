using System;
using Zenject;

namespace Neighbourhood.Game.Indoors.Visitables
{
	public class VisitablesInstaller : Installer<VisitableGlobalSettings, VisitablesInstaller>
	{
		readonly VisitableGlobalSettings settings;

		public VisitablesInstaller(VisitableGlobalSettings settings)
		{
			this.settings = settings;
		}

		public override void InstallBindings()
		{
			Container.BindInstance(settings);
		}
	}
}

