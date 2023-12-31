using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraScript : MonoBehaviour
{
    [SerializeField] private int maxUp;
    [SerializeField] private int maxDown;

    private int act = 0;

    [SerializeField] private GameObject cono;
    [SerializeField] private float rot;
    [SerializeField] private bool leftFirst;

    // Start is called before the first frame update
    void Start()
    {
        if (leftFirst)
        {
            rot *= -1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(maxDown == 0 && maxUp == 0)
        {

        }
        else
        {
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
}
