using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedKeyCardScript : MonoBehaviour
{
    public bool isGreenKeyCard, isRedKeyCard, isBlueKeyCard, isInSquare;
    public GameObject Keycard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGreenKeyCard && Input.GetKeyDown(KeyCode.F) && isInSquare)
        {
            GreenKeyCard();
        }
        else if (isBlueKeyCard && Input.GetKeyDown(KeyCode.F) && isInSquare)
        {
            BlueKeyCard();
        }
        else if (isRedKeyCard && Input.GetKeyDown(KeyCode.F) && isInSquare)
        {
            RedKeyCard();
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

    private void GreenKeyCard()
    {
        EventManager.OnGreenKeyCardEvent?.Invoke();
        Keycard.SetActive(false);
    }
    private void BlueKeyCard()
    {
        EventManager.OnBlueKeyCardEvent?.Invoke();
        Keycard.SetActive(false);
    }

    private void RedKeyCard()
    {
        EventManager.OnRedKeyCardEvent?.Invoke();
        Keycard.SetActive(false);
    }
}
