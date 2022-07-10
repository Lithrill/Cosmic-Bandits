using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOverideEvent : MonoBehaviour
{
    public GameObject doorReactivated1, doorReactivated2;
    private void OnEnable()
    {
        EventManager.OnDoorOverideEvent += SpecialDoor;
    }
    private void OnDisable()
    {
        EventManager.OnDoorOverideEvent -= SpecialDoor;
    }

    public void SpecialDoor()
    {
        Debug.Log("DoorIsActivated");
        doorReactivated1.SetActive(true);
        doorReactivated2.SetActive(true);
    }
}
