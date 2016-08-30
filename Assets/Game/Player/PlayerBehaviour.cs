using UnityEngine;
using System.Collections;
using Neighbourhood.Game.Abstractions.Components;
using Zenject;
using Neighbourhood.Game.UnityIntegration.Components;
using Neighbourhood.Game.UnityIntegration;

namespace Neighbourhood.Game.Player
{
	public interface IPlayer : IHasTransform, IHasRigidbody
	{
	}

	public class PlayerBehaviour : BaseBehaviour, IPlayer
	{
		public IRigidbody Rigidbody { get; private set; }

		[Inject]
		public void Init()		
		{
			Rigidbody = new RigidbodyWrapper(GetComponent<Rigidbody>());
		}
	}
}
