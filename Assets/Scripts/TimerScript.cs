using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    private float DetectionTimer;
    private float LastDetectionTimer;

    public float DetectionThreshold;

    public TextMeshProUGUI tm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DetectionTimer > DetectionThreshold)
        {
            SceneManager.LoadScene(4);
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

        tm.text = DetectionTimer.ToString("0.00");
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
