using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipingScript : MonoBehaviour
{

    public GameObject gun;

    private bool gunIsEquiped = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && gunIsEquiped)
        {
            gun.SetActive(false);
            gunIsEquiped = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && gunIsEquiped == false)
        {
            gun.SetActive(true);
            gunIsEquiped = true;
        }
    }
}
