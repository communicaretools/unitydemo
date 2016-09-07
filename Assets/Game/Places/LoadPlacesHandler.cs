using UnityEngine.SceneManagement;
using UnityEngine;

namespace Neighbourhood.Game.Places
{
	public class LoadPlacesHandler
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
