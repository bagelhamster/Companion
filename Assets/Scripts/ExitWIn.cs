using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWIn : MonoBehaviour
{
    public GameObject Win;

    void Start()
    {
        Win.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {

            Win.gameObject.SetActive(true);
            Time.timeScale = 0;

        }
    }


}