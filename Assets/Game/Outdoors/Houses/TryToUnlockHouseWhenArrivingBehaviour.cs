using UnityEngine;
using System.Collections;
using Zenject;

namespace Neighbourhood.Game.Outdoors.Houses
{
	[RequireComponent(typeof(Collider))]
	public class TryToUnlockHouseWhenArrivingBehaviour : MonoBehaviour
	{
		TryToUnlockHouseWhenArrivingController controller;
		public HouseData House;

		[Inject]
		public void Init(TryToUnlockHouseWhenArrivingController controller)
		{
			this.controller = controller;
			controller.Initialize(this.House);
		}
		
		void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.CompareTag("MainCamera"))
			{
				controller.PlayerArrived();
			}
		}
	}
}
