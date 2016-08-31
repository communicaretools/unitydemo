namespace Neighbourhood.Game.FlashMessages
{
	public class FlashMessageStore
	{
		readonly FlashMessageSettings settings;
		bool newMessage = false;
		float startTime = 0f;
		string message = null;

		public FlashMessageStore (FlashMessageSettings settings)
		{
			this.settings = settings;
		}

		public void HandleShowMessage(string message)
		{
			this.message = message;
			newMessage = true;
		}

		public string GetLatestMessage(float time)
		{
			if (newMessage)
			{
				startTime = time;
				newMessage = false;
			}
			else if (time > startTime + settings.TimeoutInSeconds && message != null)
			{
				message = null;
			}

			return message;
		}
	}
}
