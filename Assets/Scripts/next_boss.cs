using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next_boss : MonoBehaviour
{

    void LoadLevel()
    {
        SceneManager.LoadScene("boss_room");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            LoadLevel();
        }
    }
}
