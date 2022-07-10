using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOverideCode : MonoBehaviour
{
    public GameObject doorOverideText;

    public void DoorOveride()
    {
        Debug.Log("DoorOverideClicked");
        doorOverideText.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.OnDoorOverideEvent += DoorOveride;
    }

    private void OnDisable()
    {
        EventManager.OnDoorOverideEvent -= DoorOveride;
    }


}
