using System;
using UnityEngine;
using Neighbourhood.Game.Abstractions.Components;
using Neighbourhood.Game.UnityIntegration.Components;
using Zenject;

namespace Neighbourhood.Game.UnityIntegration
{
	public class BaseBehaviour : MonoBehaviour, IHasTransform
	{
		public ITransform Transform { get; private set; }

		[Inject]
		public void Initialize()
		{
			Transform = new TransformWrapper(transform);
		}
	}
}

