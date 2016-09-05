using Zenject;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;

namespace Neighbourhood.Game.Indoors
{
	public class IndoorsInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			PlayerInstaller.Install(Container);
		}
	}
}

