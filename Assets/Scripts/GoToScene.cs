using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneMainMenu(){

        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
