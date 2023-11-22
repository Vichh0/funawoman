using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunaScript : MonoBehaviour
{
    [SerializeField] private SceneManagement SceneManagement;
    [SerializeField] private string TargetScene;

    private float funacount = 0;

    public void button1()
    {
        funacount++;

        if (funacount == 3)
        {
            SceneManagement.SceneLoader(TargetScene);
        }
    }
}
