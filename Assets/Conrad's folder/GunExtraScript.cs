using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunExtraScript : MonoBehaviour
{
    public GameObject aDSCanvas, ammoCanvas, gun;
    public Transform transformPosition1, transformPosition2;
    public bool aDS = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && aDS == false)
        {
            //ammoCanvas.SetActive(false);
            aDSCanvas.SetActive(true);
            gun.transform.position = transformPosition1.transform.position;
            aDS = true;
        }
        else if(Input.GetMouseButtonDown(1) && aDS)
        {
            //ammoCanvas.SetActive(true);
            aDSCanvas.SetActive(false);
            gun.transform.position = transformPosition2.transform.position;
            aDS = false;
        }


    }
}
