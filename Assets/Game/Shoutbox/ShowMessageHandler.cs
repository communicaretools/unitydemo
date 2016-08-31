using System;
using UnityEngine;

namespace Neighbourhood.Game.Shoutbox
{
	public class ShowMessageHandler
	{
		public void Handle(string message)
		{
			Debug.Log("Message: " + message);
		}
	}
}

