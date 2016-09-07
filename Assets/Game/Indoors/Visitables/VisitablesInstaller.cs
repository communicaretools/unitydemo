using System;
using Zenject;
using Neighbourhood.Game.UnityIntegration;

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
			Container.Bind<GlowWhenApproachedController>().ToSelf().AsTransient();
			Container.Bind(x => x.AllClasses().DerivingFrom<IController>().InNamespace(GetType().Namespace));
		}
	}
}

