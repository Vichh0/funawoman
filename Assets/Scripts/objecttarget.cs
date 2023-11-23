using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class objecttarget : MonoBehaviour
{
    private int max;
    private int actual;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Collider2D salida;

    //Obtiene el numero total de coleccionables del nivel
     public void setmax()
    {
        max++;
    }

    //Obtiene el numero de coleccionables recogidos
    public void addactual()
    {
        actual++;
    }

    // Update is called once per frame
    void Update()
    {
        //Envia los datos al UI
        textMeshPro.text = actual.ToString() + "/" + max.ToString();

        //Si los coleccionables recogidos son iguales a los totales, se activa la colision de la salida
        if(actual == max)
        {
            salida.enabled = true;
        }
    }
}
