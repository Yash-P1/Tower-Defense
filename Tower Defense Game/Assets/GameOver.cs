using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		//sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}

	public void Menu()
	{
		SceneManager.LoadScene(menuSceneName);
		//sceneFader.FadeTo(menuSceneName);
	}

}