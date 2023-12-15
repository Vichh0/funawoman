using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVol");
        dropdown.value = PlayerPrefs.GetInt("Res");

        Debug.Log(PlayerPrefs.GetFloat("MusicVol") + ", " + PlayerPrefs.GetInt("Res"));
    }

    public void OnValueChanged(float newValue)
    {
        PlayerPrefs.SetFloat("MusicVol", newValue);
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume = newValue;
        if (GameObject.FindGameObjectWithTag("Player") || GameObject.FindGameObjectWithTag("HidingPlayer"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().volume = newValue;
            GameObject.FindGameObjectWithTag("HidingPlayer").GetComponent<AudioSource>().volume = newValue;
        } 
    }

    public void OnValueChangedDropdown(int newValue)
    {
        PlayerPrefs.SetInt("Res", newValue);

        switch (newValue)
        {
            case 0:
                Screen.SetResolution(854, 480, true);
                break;
            case 1:
                Screen.SetResolution(1280, 720, true);
                break;
            case 2:
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }
}
