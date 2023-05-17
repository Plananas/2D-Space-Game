using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextModify : MonoBehaviour
{
    private int value;
    public Text textElement;

    private void Awake()
    {
        //textElement = GetComponent<Text>();
        value = 0;
        UpdateTextValue();
    }

    public void Increment()
    {
        value++;
        UpdateTextValue();

        if (value == 6){
            SceneManager.LoadScene(6, LoadSceneMode.Single);
        }
    }

    private void UpdateTextValue()
    {
        textElement.text = value.ToString();
    }
}
