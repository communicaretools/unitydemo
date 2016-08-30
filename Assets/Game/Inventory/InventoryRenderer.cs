using Zenject;
using UnityEngine;
using System.Linq;
using System;

namespace Neighbourhood.Game.Inventory
{
	public class InventoryRenderer : MonoBehaviour
	{
		Inventory inventory;
		public Settings Positioning;

		[Inject]
		public void Init(Inventory inventory)
		{
			this.inventory = inventory;
		}

		void OnGUI()
		{
			var bounds = new Rect(Positioning.LeftPadding, Screen.height - Positioning.BottomPadding, Positioning.Width, Positioning.Height);
			GUI.Label(bounds, string.Format("Inventory: {0} items", inventory.Items.Count()));
		}

		[Serializable]
		public class Settings
		{
			public float LeftPadding;
			public float BottomPadding;
			public float Width;
			public float Height;
		}
	}
}

