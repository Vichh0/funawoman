using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private float DetectionThreshold;

    [SerializeField] private TextMeshProUGUI tm;

    private float DetectionTimer;
    private float LastDetectionTimer;

    // Update is called once per frame
    void Update()
    {
        if (DetectionTimer > DetectionThreshold)
        {
            SceneManager.LoadScene("DefeatScene");
        }

        if (LastDetectionTimer == DetectionTimer)
        {

            if (DetectionTimer > 0)
            {
                DetectionTimer -= Time.deltaTime / 2;
            }
            else
            {
                DetectionTimer = 0;
            }
        }

        LastDetectionTimer = DetectionTimer;

        tm.text = (DetectionTimer * 100).ToString("0") + "%";
    }

    public void addTimer(float t)
    {
        DetectionTimer += t;
    }

    public float getTimer()
    {
        return DetectionTimer;
    }
}
