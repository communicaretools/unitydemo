using UnityEngine;
using System.Collections;
using Zenject;

namespace Neighbourhood.Game.Houses
{
	[RequireComponent(typeof(Collider))]
	public class HouseBehaviour : MonoBehaviour
	{
		HouseController controller;
		public HouseData House;

		[Inject]
		public void Init(HouseController controller)
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
