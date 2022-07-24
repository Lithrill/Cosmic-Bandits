using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    public GameObject Player;
    public Transform teleportLocation1, teleportLocation2;
    public bool isTeleporter1Active, isTeleporter2Active;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter()
    {
        if (isTeleporter1Active && teleportLocation1)
        {
            Player.transform.position = teleportLocation2.transform.position;
        }
        else if (isTeleporter2Active && teleportLocation2)
        {
            Player.transform.position = teleportLocation1.transform.position;
        }
    }
}
