using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UIRaycaster : MonoBehaviour
{

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            print("I'm looking at " + hit.transform.name);
            if (hit.transform.tag == "AutomaticFireUpgrade")
            {
                EventManager.OnAutomaticFireUpgradeEvent?.Invoke();
            }
            if (hit.transform.tag == "Ammunition")
            {
                EventManager.OnAmmoEvent?.Invoke();
            }
        }
        else
        {
            print("I'm looking at nothing!");
        }
    }
}
