using UnityEngine;
using UnityEngine.SceneManagement;

namespace Neighbourhood.Game.Levels
{
	public class LoadLevelHandler
	{
		public void Load(string name)
		{
			SceneManager.LoadScene(name);
		}
	}
}
