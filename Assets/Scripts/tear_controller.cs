using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tear_controller : MonoBehaviour
{

    public float lifeTime;
    public Vector3 velocity;
    public Vector3 playerVelocity;
    private float reduceVelo = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathTearDelay());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 actualVelocity = new Vector3(velocity.x + playerVelocity.x / reduceVelo, velocity.y + playerVelocity.y / reduceVelo, 0);
        this.GetComponent<Rigidbody2D>().velocity = actualVelocity;
    }

    IEnumerator DeathTearDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bat")
        {
            Destroy(gameObject);
        }
    }
}
