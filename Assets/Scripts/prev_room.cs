using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prev_room : MonoBehaviour
{
    void LoadLevel()
    {
        SceneManager.LoadScene("room_01");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            LoadLevel();
        }
    }
}
