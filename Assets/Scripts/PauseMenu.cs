using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class PauseMenu : MonoBehaviour
{
    private bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject reticle;
    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Escape))
     {
        if(GameIsPaused){
            Resume();
            reticle.SetActive(true);
        }
        else{
            Pause();
            reticle.SetActive(true);
        }

     }   
    }
    public void ReturnToMenu ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }



    void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    void Pause(){
        //Activate the pause menu and freeze the game.
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
