using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_controller : MonoBehaviour
{
    public AudioClip bomb_sound;

    private void Start()
    {
        StartCoroutine(BombSound());
    }

    private IEnumerator BombSound()
    {
        yield return new WaitForSeconds(4.5f);
        AudioSource.PlayClipAtPoint(bomb_sound, transform.position, 0.5f);
    }

    void KillOnAnimation()
    {
        Destroy(this.gameObject);
    }
}
