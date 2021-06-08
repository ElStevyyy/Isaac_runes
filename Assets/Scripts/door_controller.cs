using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_controller : MonoBehaviour
{
    public GameObject doorclosed;
    private GameObject sign;
    private GameObject barrage;
    private sign_controller panneau;
    public AudioClip door_open;

    private player_controller script_player;
    private GameObject joueur;


    private void Start()
    {
        sign = GameObject.FindGameObjectWithTag("sign");
        panneau = sign.GetComponent<sign_controller>();
        barrage = GameObject.FindGameObjectWithTag("barrage");

        joueur = GameObject.Find("Joueur");
        script_player = joueur.GetComponent<player_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (panneau.signRed)
        {
            doorclosed.SetActive(false);
            AudioSource.PlayClipAtPoint(door_open, joueur.transform.position, 1);
            barrage.SetActive(false);
        }
    }
}
