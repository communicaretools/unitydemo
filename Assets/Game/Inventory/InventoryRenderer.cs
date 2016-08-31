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
			GUI.Label(bounds, FormatInventory());
		}

		string FormatInventory()
		{
			return !inventory.Items.Any()
				? "Inventory: None"
				: string.Format("Inventory: {0}", string.Join(", ", inventory.Items.Select(i => i.Name).ToArray()));
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

