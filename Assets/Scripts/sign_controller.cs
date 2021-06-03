using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sign_controller : MonoBehaviour
{

    public GameObject sign;
    public TMP_Text readsign;
    public bool signRed = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            readsign.text = "Press F to read the sign";

            if (Input.GetKey(KeyCode.F))
            {
                sign.SetActive(true);
                signRed = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        readsign.text = "";
        sign.SetActive(false);
    }
}
