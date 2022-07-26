using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRoomDoorScript : MonoBehaviour
{
    public bool isGreenActive, isBlueActive, isRedActive, isStartActive = true;
    public GameObject greenDoor1, greenDoor2, blueDoor1, blueDoor2, redDoor1, redDoor2, Player, endDoor1, endDoor2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isStartActive)
            {
                blueDoor1.SetActive(false);
                blueDoor2.SetActive(false);
            }
            else if (isBlueActive)
            {
                blueDoor1.SetActive(false);
                blueDoor2.SetActive(false);
                greenDoor1.SetActive(false);
                greenDoor2.SetActive(false);

            }
            else if (isGreenActive)
            {
                blueDoor1.SetActive(false);
                blueDoor2.SetActive(false);
                greenDoor1.SetActive(false);
                greenDoor2.SetActive(false);
                redDoor1.SetActive(false);
                redDoor2.SetActive(false);
            }
            else if (isRedActive)
            {
                blueDoor1.SetActive(false);
                blueDoor2.SetActive(false);
                greenDoor1.SetActive(false);
                greenDoor2.SetActive(false);
                redDoor1.SetActive(false);
                redDoor2.SetActive(false);
                endDoor1.SetActive(false);
                endDoor2.SetActive(false);
            }
            
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isStartActive)
            {
                blueDoor1.SetActive(true);
                blueDoor2.SetActive(true);
            }
            else if (isBlueActive)
            {
                blueDoor1.SetActive(true);
                blueDoor2.SetActive(true);
                greenDoor1.SetActive(true);
                greenDoor2.SetActive(true);
            }
            else if (isGreenActive)
            {
                blueDoor1.SetActive(true);
                blueDoor2.SetActive(true);
                greenDoor1.SetActive(true);
                greenDoor2.SetActive(true);
                redDoor1.SetActive(true);
                redDoor2.SetActive(true);
            }
            else if (isRedActive)
            {
                blueDoor1.SetActive(true);
                blueDoor2.SetActive(true);
                greenDoor1.SetActive(true);
                greenDoor2.SetActive(true);
                redDoor1.SetActive(true);
                redDoor2.SetActive(true);
                endDoor1.SetActive(true);
                endDoor2.SetActive(true);
            }
        }

    }
    public void OnEnable()
    {
        EventManager.OnGreenKeyCardEvent += GreenKeyCard;
        EventManager.OnRedKeyCardEvent += RedKeyCard;
        EventManager.OnBlueKeyCardEvent += BlueKeyCard;
    }
    public void OnDisable()
    {
        EventManager.OnGreenKeyCardEvent -= GreenKeyCard;
        EventManager.OnRedKeyCardEvent -= RedKeyCard;
        EventManager.OnBlueKeyCardEvent -= BlueKeyCard;
    }
    public void GreenKeyCard()
    { 
        isGreenActive = true;
        isBlueActive = false;
    }
    public void BlueKeyCard()
    {
        isBlueActive = true;
        isStartActive = false;
    }
    public void RedKeyCard()
    {
        isRedActive = true;
        isGreenActive = false;
    }

}
