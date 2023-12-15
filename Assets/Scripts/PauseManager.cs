using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject controlsImage;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void controlsClick()
    {
        if(controlsImage.activeSelf)
        {
            controlsImage.SetActive(false);
            menu.SetActive(true);
        }
        else
        {
            controlsImage.SetActive(true);
            menu.SetActive(false);
        }
    }
    public void optionsClick()
    {
        if (options.activeSelf)
        {
            options.SetActive(false);
            menu.SetActive(true);
        }
        else
        {
            options.SetActive(true);
            menu.SetActive(false);
        }
    }
}
