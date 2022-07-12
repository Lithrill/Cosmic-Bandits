using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardToDoor : MonoBehaviour
{
    public bool keyCardPickedUp = false;
    public bool isInSquare = false;
    public GameObject door;

    public void Update()
    {
        if (keyCardPickedUp && isInSquare)
        {
            door.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isInSquare = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isInSquare = false;
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
