using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerExitScript : MonoBehaviour
{
    [SerializeField] private string exitScene;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("LastPlayedScene", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Exit")
        {
            SceneManager.LoadScene(exitScene);
        }
    }
}
