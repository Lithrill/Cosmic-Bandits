using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door1, door2;
    

    private void OnTriggerEnter(Collider other)
    {
        door1.SetActive(false);
        door2.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        door1.SetActive(true);
        door2.SetActive(true);
    }
   
}
