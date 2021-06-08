using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_controller : MonoBehaviour
{
    public int moveSpeed;
    public int minDistance;
    public int health;
    private GameObject joueur;
    private player_controller script_player;
    public AudioClip bat_hit;
    public SpriteRenderer spriterenderer;
    public Sprite hitSprite;
    public Sprite moveSprite;

    private void Start()
    {
        joueur = GameObject.Find("Joueur");
        script_player = joueur.GetComponent<player_controller>();
    }

    void Update()
    {
        if (script_player.isDead == false)
        {
            // déplacements
            if (Vector2.Distance(transform.position, joueur.transform.position) > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, joueur.transform.position, moveSpeed * Time.deltaTime);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tear")
        {
            spriterenderer.sprite = hitSprite;
            health--;
            AudioSource.PlayClipAtPoint(bat_hit, transform.position, 0.2f);
            StartCoroutine(Bathit());

            // quand l'ennemi a plus de vie, il despawn
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator Bathit()
    {
        yield return new WaitForSeconds(0.1f);
        spriterenderer.sprite = moveSprite;
    }
}
