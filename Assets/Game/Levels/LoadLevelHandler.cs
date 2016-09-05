using UnityEngine.SceneManagement;

namespace Neighbourhood.Game.Levels
{
	public class LoadLevelHandler
	{
		public void Enter(string houseName)
		{
			SceneManager.LoadScene(houseName);
		}
	}
}
