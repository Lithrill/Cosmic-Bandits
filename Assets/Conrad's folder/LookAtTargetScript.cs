using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTargetScript : MonoBehaviour
{
    public Transform Target;
    public bool playerClose = false;
    //public GameObject Canvas;
    //public GameObject particles;
    //public GameObject myLight;



    private void Awake()
    {
        playerClose = true;
        //particles.SetActive(true);
        //myLight.SetActive(true);
        if (playerClose)
        {
            transform.LookAt(Target);
        }

    }

    // [ ... ]

    // Update is called once per frame
    void Update()
    {
        if (playerClose)
        {
            transform.LookAt(Target);
        }

    }



    private void OnDisable()
    {
        EventManager.OnIsCloseEvent -= Close;
        EventManager.OnIsNotCloseEvent -= NotClose;
    }
    private void OnEnable()
    {
        EventManager.OnIsCloseEvent += Close;
        EventManager.OnIsNotCloseEvent += NotClose;
    }

    private void Close()
    {
        //Canvas.SetActive(true);
        playerClose = true;
        //particles.SetActive(true);
        //myLight.SetActive(true);

    }

    private void NotClose()
    {
        playerClose = false;
        //Canvas.SetActive(false);
        //particles.SetActive(false);
        //myLight.SetActive(false);

    }
}
