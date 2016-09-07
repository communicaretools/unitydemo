using System;

namespace Neighbourhood.Game.UnityIntegration
{
	public interface IController : IDisposable
	{
	}

	public interface IController<TView> : IController
	{
		void Init(TView view);
	}
}

