using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    int tutorial = 0;
    public void Play(string scene)
    {
        tutorial = PlayerPrefs.GetInt("tutorial");

        if(tutorial == 1)
        {
            SceneManager.LoadScene(scene);
        }
        else
        {
            SceneManager.LoadScene(scene);
        } 
    }

    public void Quit()
    {   
        Debug.Log("Has Salido del juego");
        Application.Quit();
    }
}