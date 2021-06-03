using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_controller : MonoBehaviour
{
    void KillOnAnimation()
    {
        Destroy(this.gameObject);
    }
}
