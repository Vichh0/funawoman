using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraScript : MonoBehaviour
{
    [SerializeField] private int maxUp;
    [SerializeField] private int maxDown;

    private int act = 0;

    [SerializeField] private GameObject cono;
    private float rot;

    // Start is called before the first frame update
    void Start()
    {
        rot = 30;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(rot + ", " + act);

        if(rot > 0)
        {
            cono.transform.RotateAround(transform.position, Vector3.forward, rot * Time.deltaTime);
            act++;

            if (act > maxUp)
            {
                rot = Mathf.Abs(rot) * -1;
            }
        }

        if(rot < 0)
        {
            cono.transform.RotateAround(transform.position, Vector3.forward, rot * Time.deltaTime);
            act--;
    
            if (act < maxDown)
            {
                rot = Mathf.Abs(rot);
            }
        }      
    }
}
