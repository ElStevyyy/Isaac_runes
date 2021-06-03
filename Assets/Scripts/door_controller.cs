using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_controller : MonoBehaviour
{
    public GameObject doorclosed;
    private GameObject sign;
    private GameObject barrage;
    private sign_controller panneau;
 

    private void Start()
    {
        sign = GameObject.FindGameObjectWithTag("sign");
        panneau = sign.GetComponent<sign_controller>();
        barrage = GameObject.FindGameObjectWithTag("barrage");
    }

    // Update is called once per frame
    void Update()
    {
        if (panneau.signRed)
        {
            doorclosed.SetActive(false);
            barrage.SetActive(false);
        }
    }
}
