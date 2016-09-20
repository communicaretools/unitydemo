using System;
using UnityEngine;
using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using Neighbourhood.Game.UnityIntegration.Implementation.Components;
using Zenject;

namespace Neighbourhood.Game.UnityIntegration.Implementation
{
	public abstract class BaseBehaviour : MonoBehaviour, IHasTransform
	{
		public ITransform Transform { get; private set; }

		[Inject]
		public void Initialize()
		{
			Transform = new TransformWrapper(transform);
		}
	}

	public interface IView {}

	public abstract class BaseBehaviour<TController, TView> : BaseBehaviour
		where TController : IController<TView>
		where TView : class
	{
		protected TController Controller { get; private set; }

		[Inject]
		public void InitController(TController controller)
		{ 
			Controller = controller;
			controller.Init(this as TView);
		}

		void OnDestroy()
		{
			if (Controller != null)
			{
				Controller.Dispose();
			}
		}
	}
}

