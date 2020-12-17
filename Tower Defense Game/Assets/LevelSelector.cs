using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

	public SceneFader fader;

	public Button[] levelButtons;

	void Start()
	{
		int levelPlayed = PlayerPrefs.GetInt("levelPlayed", 1);

		for (int i = 0; i < levelButtons.Length; i++)
		{
			if (i + 1 > levelPlayed)
				levelButtons[i].interactable = false;
		}
	}

	public void Select(string levelName)
	{
		fader.FadeTo(levelName);
	}

}