using Zenject;
using UnityEngine;
using System.Linq;
using System;

namespace Neighbourhood.Game.Inventory
{
	public class InventoryRenderer : MonoBehaviour
	{
		Inventory inventory;
		Settings positioning;

		[Inject]
		public void Init(Inventory inventory, Settings settings)
		{
			this.inventory = inventory;
			this.positioning = settings;
		}

		void OnGUI()
		{
			var bounds = new Rect(positioning.LeftPadding, Screen.height - positioning.BottomPadding, positioning.Width, positioning.Height);
			GUI.Label(bounds, FormatInventory());
		}

		string FormatInventory()
		{
			return inventory.Items.Any()
				? string.Format("Inventory: {0}", string.Join(", ", inventory.Items.Select(i => i.Name).ToArray()))
				: "Inventory: None";
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

