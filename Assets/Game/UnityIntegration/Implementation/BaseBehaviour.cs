using System;
using UnityEngine;
using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using Neighbourhood.Game.UnityIntegration.Implementation.Components;
using Zenject;

namespace Neighbourhood.Game.UnityIntegration.Implementation
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

