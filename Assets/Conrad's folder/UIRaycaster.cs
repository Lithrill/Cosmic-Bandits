using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UIRaycaster : MonoBehaviour
{
    public GameObject level1, level2, player, gun;
    public Transform level2SpawnPosition;

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

        if (Input.GetKeyDown(KeyCode.F) && Physics.Raycast(ray, out hit))
        {
            print("I'm looking at " + hit.transform.name);
            //if (hit.transform.tag == "AutomaticFireUpgrade")
            //{
            //    EventManager.OnAutomaticFireUpgradeEvent?.Invoke();
            //}
            //if (hit.transform.tag == "Ammunition")
            //{
            //    EventManager.OnAmmoEvent?.Invoke();
            //}
            if (hit.transform.tag == "DoorOveride")
            {
                //Debug.Log("DoorOveride");
                EventManager.OnDoorOverideEvent?.Invoke();
                FindObjectOfType<AudioManager>().Play("Space_Button");
            }
            if (hit.transform.tag == "NextLevel")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                FindObjectOfType<AudioManager>().Play("Space_Button");
            }
            if (hit.transform.tag == "Ending")
            {
                EventManager.OnpurchaseEndingEvent?.Invoke();
                FindObjectOfType<AudioManager>().Play("Space_Button");
            }

        }
        else if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "PLAY")
            {
                FindObjectOfType<AudioManager>().Play("Space_Button");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                EventManager.OnIncreaseLevelEvent?.Invoke();
            }
            if (hit.transform.tag == "MainMenu")
            {
                FindObjectOfType<AudioManager>().Play("Space_Button");
                Time.timeScale = 1f;
                SceneManager.LoadScene("Title Screen");
                Time.timeScale = 1f;
            }
        }
        else
        {
            print("I'm looking at nothing!");
        }
    }
}
