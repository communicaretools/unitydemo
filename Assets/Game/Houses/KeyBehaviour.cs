using UnityEngine;
using Zenject;
using Neighbourhood.Game.Inventory;
using System;

namespace Neighbourhood.Game.Houses
{
	[RequireComponent(typeof(Collider))]
	public class KeyBehaviour : MonoBehaviour
	{
		Inventory.Inventory inventory;
		public Settings KeyInfo;

		[Inject]
		public void Init(Inventory.Inventory inventory)
		{
			this.inventory = inventory;
		}

		void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.CompareTag("MainCamera"))
			{
				inventory.Add(new Item(KeyInfo.Name, KeyInfo.Data));
				Destroy(this.gameObject);
			}
		}

		[Serializable]
		public class Settings
		{
			public string Name;
			public Key Data;
		}
	}

}
