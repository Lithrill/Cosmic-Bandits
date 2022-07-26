using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticFireChanger : MonoBehaviour
{
    public bool isAutomatic = false;
    public GameObject bulletLeft, bulletRight, bulletRightTwo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isAutomatic)
        {
            bulletLeft.SetActive(false);
            bulletRight.SetActive(true);
            bulletRightTwo.SetActive(true);
            EventManager.OnSingleFireEvent?.Invoke();
            isAutomatic = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isAutomatic == false)
        {
            bulletLeft.SetActive(true);
            bulletRight.SetActive(false);
            bulletRightTwo.SetActive(false);
            EventManager.OnAutomaticGunEvent?.Invoke();
            isAutomatic = true;
        }
    }
}
