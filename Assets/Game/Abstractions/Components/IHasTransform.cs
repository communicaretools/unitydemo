using System;
using UnityEngine;

namespace Neighbourhood.Game.Abstractions.Components
{
	public interface IHasTransform
	{
		ITransform Transform { get; }
	}
}

