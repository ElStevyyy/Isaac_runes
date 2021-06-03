using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class player_controller : MonoBehaviour
{
    // TODO: wasd = move / fleches = tir
    // TODO: hitbox pour déplacement != hitbox touché

    public float moveHorizontal;
    public float moveVertical;
    public float shootHorizontal;
    public float shootVertical;
    public float speed;
    public Rigidbody2D player;
    private Vector2 deplacement;
    public GameObject tearPrefab;
    public float tearSpeed;
    private float lastFire;
    public float fireDelay;
    private int coeurs;
    public TMP_Text diemessage;
    public bool isDead = false;
    private bool hittable = true;
    public Animator animator;

    private void Start()
    {
        coeurs = 5;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            moveHorizontal = Input.GetAxis("Horizontal") * speed;
            moveVertical = Input.GetAxis("Vertical") * speed;

            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Time.time > lastFire + fireDelay)
            {
                Shoot();
                lastFire = Time.time;
            }

            deplacement = new Vector2(moveHorizontal, moveVertical);
            player.velocity = deplacement * speed;

            if (!hittable)
            {
                
            }
        }
    }

    private IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }

    void Shoot()
    {
        GameObject tear = Instantiate(tearPrefab, transform.position, transform.rotation) as GameObject;
        tear.GetComponent<tear_controller>().playerVelocity = player.velocity;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            tear.GetComponent<tear_controller>().velocity = new Vector3(0, tearSpeed, 0);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            tear.GetComponent<tear_controller>().velocity = new Vector3(0, -1 * tearSpeed, 0);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            tear.GetComponent<tear_controller>().velocity = new Vector3(-1 * tearSpeed, 0, 0);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            tear.GetComponent<tear_controller>().velocity = new Vector3(tearSpeed, 0, 0);
        }
    }

    void Hit()
    {
        if (hittable == true)
        {
            GameObject coeur = GameObject.Find("heart" + coeurs);
            coeurs--;
            coeur.SetActive(false);
            hittable = false;
            animator.SetTrigger("Hitted");

            if (coeurs == 0)
            {
                // mort du joueur --> menu
                diemessage.text = "YOU DIED";
                // retour au menu
                isDead = true;

                StartCoroutine(GoToMenu());
            }
        }
    }

    void InvincibilityFrameOff()
    {
        hittable = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bat")
        {
            Hit();
        }

        if (collision.gameObject.tag == "boss")
        {
            Hit();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bomb")
        {
            Hit();
        }
    }
}
