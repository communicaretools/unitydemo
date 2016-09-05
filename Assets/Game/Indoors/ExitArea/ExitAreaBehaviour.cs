using UnityEngine;
using Neighbourhood.Game.Levels;
using Zenject;

namespace Neighbourhood.Game.Indoors.ExitArea
{
	[RequireComponent(typeof(Collider))]
	public class ExitAreaBehaviour : MonoBehaviour
	{
		ExitHouseCommand exit;

		[Inject]
		public void Init(ExitHouseCommand exit)
		{
			this.exit = exit;
		}

		void OnCollisionEnter(Collision collision)
		{
			Debug.Log("Detected collision with exit area");
			exit.Execute();
		}
	}
}

