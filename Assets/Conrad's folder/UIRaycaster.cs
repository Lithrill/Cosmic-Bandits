using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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
            if (hit.transform.tag == "DoorOveride")
            {
                //Debug.Log("DoorOveride");
                EventManager.OnDoorOverideEvent?.Invoke();
            }
            if (hit.transform.tag == "PLAY")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                EventManager.OnIncreaseLevelEvent?.Invoke();
            }
        }
        else
        {
            print("I'm looking at nothing!");
        }
    }
}
