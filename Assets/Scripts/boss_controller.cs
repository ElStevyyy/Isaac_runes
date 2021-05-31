using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_controller : MonoBehaviour
{

    public int health;
    public int current_health;
    public healthbar_controller healthbar;

    public float speed;
    private int h = 1;
    private int v = 1;


    // Start is called before the first frame update
    void Start()
    {
        current_health = health;
        healthbar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * v * Time.deltaTime, speed * h * Time.deltaTime, 0);
        if (speed < 6)
        {
            speed += 0.005f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tear")
        {
            current_health--;
            healthbar.SetHealth(current_health);

            // quand l'ennemi a plus de vie, il despawn
            if (current_health == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "murhaut")
        {
            h *= -1;
        }

        if (collision.gameObject.tag == "murbas")
        {
            h *= -1;
        }

        if (collision.gameObject.tag == "murdroite")
        {
            v *= -1;
        }

        if (collision.gameObject.tag == "murgauche")
        {
            v *= -1;
        }
    }
}
