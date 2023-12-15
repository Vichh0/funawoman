using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject options;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(controls.activeSelf == false && options.activeSelf == false)
            {
                Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
            }

            if(menu.activeSelf == true )
            {
                menu.SetActive(false);
            }
            else
            {

                if(controls.activeSelf == true)
                {
                    controls.SetActive(false);
                    menu.SetActive(true);
                }
                else
                {
                    menu.SetActive(true);
                }

                if (options.activeSelf == true)
                {
                    options.SetActive(false);
                    menu.SetActive(true);
                }
                else
                {
                    menu.SetActive(true);
                }
            }
        }
    }

    public void unPause()
    {
        menu.SetActive(false);
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
    }

    public void backToMenu()
    {
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
        SceneManager.LoadScene("TitleScene");
    }
}
