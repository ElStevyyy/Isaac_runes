using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    phase1, phase2, summon
}

public class boss_controller : MonoBehaviour
{

    public int health;
    public int current_health;
    public healthbar_controller healthbar;

    public float speed;
    private int h = 1;
    private int v = 1;

    public SpriteRenderer spriterenderer;
    public Sprite standSprite;
    public Sprite moveSprite;
    public Sprite shieldSprite;

    public GameObject bat;
    public GameObject bomb;

    private States state;

    private bool hittable = true;

    void Start()
    {
        current_health = health;
        healthbar.SetMaxHealth(health);
        StartCoroutine(PopAds());
        state = States.phase1;
    }

    void Update()
    {
        switch (state)
        {
            case States.phase1:
                phase1();
                break;
            case States.phase2:
                break;
            case States.summon:
                break;
            default:
                break;
        }
    }

    void phase1()
    {
        transform.position += new Vector3(speed * v * Time.deltaTime, speed * h * Time.deltaTime, 0);

        if (speed < 4)
        {
            speed += 0.005f;
        }
    }


    private IEnumerator PopAds()
    {
        yield return new WaitForSeconds(5f);
        state = States.summon;

        spriterenderer.sprite = standSprite;
        yield return new WaitForSeconds(0.3f);
        Sprite sprite = moveSprite;
        hittable = true;

        switch (Random.Range(1, 5))
        {
            case 1:
                Rune_Berkano();
                break;
            case 2:
                Rune_Jera();
                break;
            case 3:
                Rune_Dagaz();
                sprite = shieldSprite;
                break;
            case 4:
                Rune_Hagalaz();
                break;
            default:
                break;
        }

        yield return new WaitForSeconds(0.3f);

        spriterenderer.sprite = sprite;
        state = States.phase1;

        StartCoroutine(PopAds());
    }

    private void Rune_Berkano()
    {
        Debug.Log("BERKANOOOOO");
        Instantiate(bat, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
        Instantiate(bat, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
    }

    private void Rune_Hagalaz()
    {
        Debug.Log("HAGALAZZZZZ");
        Instantiate(bomb, new Vector3(Random.Range(-7, 8), Random.Range(-4, 5), 0), new Quaternion(0, 0, 0, 0));
        Instantiate(bomb, new Vector3(Random.Range(-7, 8), Random.Range(-4, 5), 0), new Quaternion(0, 0, 0, 0));
        Instantiate(bomb, new Vector3(Random.Range(-7, 8), Random.Range(-4, 5), 0), new Quaternion(0, 0, 0, 0));
    }

    private void Rune_Jera()
    {
        Debug.Log("JERAAAAAAA");
        GameObject[] nbBat = GameObject.FindGameObjectsWithTag("bat");
        if (nbBat.Length <= 0)
        {
            Instantiate(bat, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
        }
        else
        {
            for (int i = 0; i < nbBat.Length; i++)
            {
                if (nbBat.Length < 10)
                {
                    switch (Random.Range(1, 5))
                    {
                        case 1:
                            Instantiate(bat, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
                            break;
                        case 2:
                            Instantiate(bat, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
                            break;
                        case 3:
                            Instantiate(bat, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Quaternion(0, 0, 0, 0));
                            break;
                        case 4:
                            Instantiate(bat, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), new Quaternion(0, 0, 0, 0));
                            break;
                    }
                }
            }
        }
    }

    private void Rune_Dagaz()
    {
        Debug.Log("DAGAAAAAAZ");
        hittable = false;
        spriterenderer.sprite = shieldSprite;
    }

    void Hit()
    {
        if (hittable)
        {
            current_health--;
            healthbar.SetHealth(current_health);

            if (current_health == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tear")
        {
            Hit();
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
