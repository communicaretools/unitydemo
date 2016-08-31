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
			var height = Screen.height / 2f;
			GUI.Box(new Rect(width - width/2f, height - height/2f, width, height), "Message:");
			GUI.Label(new Rect(0, 0, width, height), message);
		}
	}
}
