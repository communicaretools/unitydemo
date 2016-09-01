using UnityEngine;
using System.Collections;
using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using Zenject;
using Neighbourhood.Game.UnityIntegration.Implementation.Components;
using Neighbourhood.Game.UnityIntegration.Implementation;

namespace Neighbourhood.Game.Player
{
	public interface IPlayer : IHasTransform
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
