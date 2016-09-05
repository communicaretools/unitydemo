using UnityEngine;
using System.Collections;
using Zenject;

namespace Neighbourhood.Game.FlashMessages
{
	public class FlashMessageRenderer : MonoBehaviour
	{
		FlashMessageStore messageStore;

		[Inject]
		void Init(FlashMessageStore store)
		{
			messageStore = store;
		}

		void OnGUI()
		{
			var message = messageStore.GetLatestMessage(Time.realtimeSinceStartup);
			if (message == null)
			{
				return;
			}

			var width = Screen.width / 2f;
			var height = Screen.height / 4f;
			var boxBounds = new Rect(width / 2f, height / 2f, width, height);
			GUI.Box(boxBounds, "Message:");
			GUI.Label(new Rect(boxBounds.x + 30f, boxBounds.y + 70f, width - 30f, height - 70f), message);
		}
	}
}
