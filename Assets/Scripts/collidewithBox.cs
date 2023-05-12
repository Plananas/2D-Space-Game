using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collidewithBox : MonoBehaviour
{
    [SerializeField] private string SecondLevel;
    [SerializeField] private GameObject uiElement;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Sprite"))
        {
            uiElement.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(SecondLevel);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sprite"))
        {
            uiElement.SetActive(false);
        }
    }

}