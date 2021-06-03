using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_controller2 : MonoBehaviour
{

    public GameObject doorclosed2;
    public GameObject bossdoorclosed;
    private GameObject barrage2;
    private GameObject barrage3;
    private GameObject[] nbBat;

    // Start is called before the first frame update
    void Start()
    {
        barrage2 = GameObject.FindGameObjectWithTag("barrage2");
        barrage3 = GameObject.FindGameObjectWithTag("barrage3");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] nbBat = GameObject.FindGameObjectsWithTag("bat");

        if (nbBat.Length == 0)
        {
            doorclosed2.SetActive(false);
            bossdoorclosed.SetActive(false);
            barrage2.SetActive(false);
            barrage3.SetActive(false);
        }
    }
}
