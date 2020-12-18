using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class navigation : MonoBehaviour
{
    //public SceneFader sceneFader;
    // Start is called before the first frame update
    public void Back()
    {
        //sceneFader.FadeTo("MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
}
