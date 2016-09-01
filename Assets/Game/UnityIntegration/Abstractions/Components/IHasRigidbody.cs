using System;
using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration.Abstractions.Components
{

	public interface IHasRigidbody
	{
		IRigidbody Rigidbody { get; }
	}
	
}
