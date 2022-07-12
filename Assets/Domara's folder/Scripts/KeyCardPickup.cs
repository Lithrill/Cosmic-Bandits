using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardPickup : MonoBehaviour
{
    public GameObject keyCard;
    public GameObject pickUpText;
    public bool isInSquare = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isInSquare)
        {
            keyCard.SetActive(false);
            //pickUpText.SetActive(false);
            EventManager.OnLevelOneKeyCardEvent?.Invoke();
            Destroy(this);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isInSquare = true;
        //pickUpText.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        isInSquare = false;
        //pickUpText.SetActive(false);
    }
}
