using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorForKeyCard : MonoBehaviour
{
    public GameObject specialEffects, Canvas;
    public Transform player;
    private void OnTriggerEnter(Collider other)
    {
        specialEffects.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        specialEffects.SetActive(false);
    }
    private void Update()
    {
        Canvas.transform.LookAt(player);
    }
}
