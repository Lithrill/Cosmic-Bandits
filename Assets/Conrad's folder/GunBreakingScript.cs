using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBreakingScript : MonoBehaviour
{
    public GameObject brokenGun, playerGun;

    private void OnTriggerEnter(Collider other)
    {
        brokenGun.SetActive(true);
        playerGun.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Gun_Drop");
        Destroy(this);
    }
}
