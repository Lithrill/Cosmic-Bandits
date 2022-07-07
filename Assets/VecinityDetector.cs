using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VecinityDetector : MonoBehaviour
{
    public GameObject upgradeCanvas, ammoCanvas;
    public GameObject upgradeParticles, ammoParticles, ammoLights, upgradeLights;
    private bool isClose = false;
    


    private void Update()
    {


    }
    private void Close()
    {

        Debug.Log("close called");
        upgradeCanvas.SetActive(true);
        ammoCanvas.SetActive(true);
        isClose = true;
        ammoParticles.SetActive(true);
        upgradeParticles.SetActive(true);
        upgradeLights.SetActive(true);
        ammoLights.SetActive(true);

    }

    private void far()
    {
        
        Debug.Log("far called");
        isClose = false;
        ammoCanvas.SetActive(false);
        upgradeCanvas.SetActive(false);
        ammoParticles.SetActive(false);
        upgradeParticles.SetActive(false);
        upgradeLights.SetActive(false);
        ammoLights.SetActive(false);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("close");
            Close();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            far();
        }

    }

}
