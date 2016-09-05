using UnityEngine.SceneManagement;
using UnityEngine;

namespace Neighbourhood.Game.Levels
{
	public class LoadLevelHandler
	{
		public void Enter(string houseName)
		{
			Debug.Log("Entering house named " + houseName);
			SceneManager.LoadScene(houseName);
		}

		public void Exit()
		{
			Debug.Log("Going back to the overview");
			SceneManager.LoadScene("Overview");
		}
	}
}
