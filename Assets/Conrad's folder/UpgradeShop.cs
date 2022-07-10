using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShop : MonoBehaviour
{
    
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        EventManager.OnAutomaticFireUpgradeEvent += UpgradeToAutomaticGun;
    }

    private void OnDisable()
    {
        EventManager.OnAutomaticFireUpgradeEvent -= UpgradeToAutomaticGun;
    }

    public void UpgradeToAutomaticGun()
    { 
    
    }


}
