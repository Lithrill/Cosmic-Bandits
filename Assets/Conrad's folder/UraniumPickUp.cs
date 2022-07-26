using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UraniumPickUp : MonoBehaviour
{

    public GameObject uranium;
    public GameObject uIuraniumcounter;
    public TMP_Text uraniumCounter;
    public int uraniumNumberCounter;
    public GameObject upgradeCanvas;
    public GameObject ammoCanvas;
    public GameObject automaticFireObj;
    public GameObject purcahseCanvas1, purchaseCanvas2, textBasedCanvas;
    public GameObject gameWinCanvas, player, Mycamera;

    public bool level2 = false;
    Coroutine ammoRoutine = null;

    Coroutine lastRoutine = null;

    Coroutine uraniumShower = null;

    private void Start()
    {
        uraniumCounter.GetComponent<TMP_Text>().color = Color.green;
        if (level2)
        {
            uraniumNumberCounter++;
            uraniumNumberCounter++;
            uraniumNumberCounter++;
            uraniumNumberCounter++;
            uraniumNumberCounter++;
            uraniumNumberCounter++;
            uraniumCounter.text = "Uranium" + ":" + uraniumNumberCounter.ToString("00");
        }
    }

    private void UraniumCoroutine()
    {
        //Debug.Log("coroutinestarted");
        lastRoutine = StartCoroutine(UIupdater());
    }

    IEnumerator UIupdater()
    {
        
        //uranium.SetActive(false);
        uIuraniumcounter.SetActive(true);
        uraniumNumberCounter++;
        uraniumCounter.text = "Uranium" + ":" + uraniumNumberCounter.ToString("00");
        yield return new WaitForSeconds(5);
        //uIuraniumcounter.SetActive(false);
        

        StopCoroutine(lastRoutine);
    }

    private void OnEnable()
    {
        EventManager.OnUraniumPickUpEvent += UraniumCoroutine;
        EventManager.OnAutomaticFireUpgradeEvent += AutomaticFireUpgradeCost;
        EventManager.OnAmmoEvent += BuyAmmo;
        EventManager.OnpurchaseEndingEvent += BuyEnding;
    }

    private void OnDisable()
    {
        EventManager.OnUraniumPickUpEvent -= UraniumCoroutine;
        EventManager.OnAutomaticFireUpgradeEvent -= AutomaticFireUpgradeCost;
        EventManager.OnAmmoEvent -= BuyAmmo;
        EventManager.OnpurchaseEndingEvent -= BuyEnding;
    }

    public void AutomaticFireUpgradeCost()
    {
        if (uraniumNumberCounter >= 3)
        {
            uraniumNumberCounter -= 3;
            uraniumCounter.text = "Uranium" + ": " + uraniumNumberCounter.ToString("00");

            purcahseCanvas1.SetActive(false);
            purchaseCanvas2.SetActive(false);
            textBasedCanvas.SetActive(true);
            automaticFireObj.SetActive(true);
            //uraniumShower = StartCoroutine(ShowingUranium());
            upgradeCanvas.SetActive(false);
        }
    }

    public void BuyAmmo()
    {
        if (uraniumNumberCounter >= 1)
        {
            uraniumNumberCounter -= 1;
            uraniumCounter.text = "Uranium" + ":" + uraniumNumberCounter.ToString("00");

            ammoRoutine = StartCoroutine(AmmoRoutine());
            uraniumShower = StartCoroutine(ShowingUranium());
        }
    }

    public void BuyEnding()
    {
        if (uraniumNumberCounter >= 6)
        {
            uraniumNumberCounter -= 6;
            uraniumCounter.text = "Uranium" + ":" + uraniumNumberCounter.ToString("00");

            gameWinCanvas.SetActive(true);
            player.SetActive(false);
            Mycamera.SetActive(true);
            
        }
    }

    IEnumerator AmmoRoutine()
    {
        ammoCanvas.SetActive(false);
        yield return new WaitForSeconds(1);
        ammoCanvas.SetActive(true);
        StopCoroutine(AmmoRoutine());
    }

    IEnumerator ShowingUranium()
    {
        uIuraniumcounter.SetActive(true);
        uraniumCounter.text = "Uranium" + ":" + uraniumNumberCounter.ToString("00");
        yield return new WaitForSeconds(5);
        //uIuraniumcounter.SetActive(false);

        StopCoroutine(ShowingUranium());
    }
}
