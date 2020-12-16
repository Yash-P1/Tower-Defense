using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    
    // Update is called once per frame
    public void PauseGame()
    {
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf)
        {
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
        }
        
    }

    public void Menu(){
       Debug.Log("Menu");
    }
    public void Retry(){
        PauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
