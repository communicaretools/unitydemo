using System;
using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration.Abstractions.Components
{
	public interface IHasTransform
	{
		ITransform Transform { get; }
	}
}

