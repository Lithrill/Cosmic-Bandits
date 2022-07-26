using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEventScript : MonoBehaviour
{
    public GameObject Enemy, door1, door2, door3, door4, door5, door6;

    private void OnTriggerEnter(Collider other)
    {
        Enemy.SetActive(true);
        door1.SetActive(true);
        door2.SetActive(true);
        door3.SetActive(true);
        door4.SetActive(true);
        door5.SetActive(false);
        door6.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Space_Door");
    }
    

    
}
