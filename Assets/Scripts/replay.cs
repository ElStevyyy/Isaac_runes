using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("room_01");
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
