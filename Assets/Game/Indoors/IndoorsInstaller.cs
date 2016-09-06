using Zenject;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;
using System;
using Neighbourhood.Game.Indoors.Visitables;

namespace Neighbourhood.Game.Indoors
{
	public class IndoorsInstaller : MonoInstaller
	{
		public IndoorSettings Settings;

		public override void InstallBindings()
		{
			PlayerInstaller.Install(Container);
			VisitablesInstaller.Install(Container, Settings.Visitable);
		}

		[Serializable]
		public class IndoorSettings
		{
			public VisitableGlobalSettings Visitable;
		}
	}
}

