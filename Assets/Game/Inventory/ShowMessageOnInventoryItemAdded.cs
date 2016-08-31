using System;
using Zenject;
using Neighbourhood.Game.FlashMessages;

namespace Neighbourhood.Game.Inventory
{
	public class ShowMessageOnInventoryItemAdded : IInitializable, IDisposable
	{
		readonly InventoryItemAddedSignal signal;
		readonly ShowMessageCommand showMessage;

		public ShowMessageOnInventoryItemAdded(InventoryItemAddedSignal signal, ShowMessageCommand showMessage)
		{
			this.showMessage = showMessage;
			this.signal = signal;
		}

		void ShowMessage(Item item)
		{
			showMessage.Execute("You picked up the " + item.Name);
		}
			
		public void Initialize()
		{
			signal.Event += ShowMessage;
		}

		public void Dispose()
		{
			signal.Event -= ShowMessage;
		}
	}
}

