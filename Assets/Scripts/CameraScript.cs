using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrpt : MonoBehaviour
{
    [SerializeField] private float top;
    [SerializeField] private float bottom;
    [SerializeField] private float left;
    [SerializeField] private float right;

    [SerializeField] private GameObject player;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = player.transform.position;

        if (position.x <= right && position.x >= left)
        {
            transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
        }
        if (position.y <= top && position.y >= bottom)
        {
            transform.position = new Vector3(transform.position.x, position.y, transform.position.z);
        }
    }
}
