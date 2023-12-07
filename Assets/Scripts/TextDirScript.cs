using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDirScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private objecttarget oT;
    [SerializeField] private GameObject player;

    private bool shown = false;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Recolecta todas las pruebas";

        Invoke("blank", 4);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 7, player.transform.position.z);

        if (oT.getState() && !shown)
        {
            shown = true;
            text.text = "Encuentra la salida";
            Invoke("blank", 4);
        }
    }

    private void blank()
    {
        text.text = string.Empty;
    }
}
