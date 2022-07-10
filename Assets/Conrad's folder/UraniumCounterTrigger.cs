using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UraniumCounterTrigger : MonoBehaviour
{
    public GameObject uranium;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Eventtrigger");
        EventManager.OnUraniumPickUpEvent?.Invoke();

        Destroy(uranium);
    }
}
