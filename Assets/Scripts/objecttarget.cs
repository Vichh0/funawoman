using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class objecttarget : MonoBehaviour
{
    private int max;
    private int actual;
    public TextMeshProUGUI textMeshPro;
    public Collider2D salida;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = actual.ToString() + "/" + max.ToString();
        if(actual == max)
        {
            salida.enabled = true;
        }
    }
     public void setmax()
    {
        max++;
    }
    public void addactual()
    {
        actual++;
    }
}
