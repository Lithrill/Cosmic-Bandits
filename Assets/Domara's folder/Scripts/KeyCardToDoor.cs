using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardToDoor : MonoBehaviour
{
    public bool keyCardPickedUp = false;
    public bool isInSquare = false;
    public bool doorActive = false;
    public GameObject door;

    public void Update()
    {
        if (keyCardPickedUp && isInSquare)
        {
            door.SetActive(false);
            doorActive = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isInSquare = true;
        if (doorActive)
        {
            door.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Space_Door");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isInSquare = false;
        if (doorActive)
        {
            door.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Space_Door");
        }
    }
    public void keyCardIsPickedUp()
    {
        keyCardPickedUp = true;
    }
    public void OnEnable()
    {
        EventManager.OnLevelOneKeyCardEvent += keyCardIsPickedUp;
    }
    public void OnDisable()
    {
        EventManager.OnLevelOneKeyCardEvent -= keyCardIsPickedUp;
    }
}
