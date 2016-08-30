using System;
using UnityEngine;

namespace Neighbourhood.Game.Abstractions.Components
{

	public interface IHasRigidbody
	{
		IRigidbody Rigidbody { get; }
	}
	
}
