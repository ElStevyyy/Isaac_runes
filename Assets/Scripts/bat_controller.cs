using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_controller : MonoBehaviour
{

    public Rigidbody2D Player;
    public int moveSpeed;
    public int minDistance;
    public int health;
    public GameObject player;
    private player_controller script_player;

    private void Start()
    {
        health = 10;
        script_player = player.GetComponent<player_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (script_player.isDead == false)
        {
            // déplacements
            if (Vector2.Distance(transform.position, Player.position) > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, moveSpeed * Time.deltaTime);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tear")
        {
            health--;

            // quand l'ennemi a plus de vie, il despawn
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
