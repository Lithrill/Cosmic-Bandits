using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollecter : MonoBehaviour
{
    public TMP_Text goldCount, diamondCount, emeraldCount, moneyCount;
    
    [SerializeField]
    private int goldScore = 0, diamondScore = 0, emeraldScore = 0, moneyScore = 0;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Gold(Clone)"))
        {
            goldScore += 1;
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        if (other.name.Equals("Diamond(Clone)"))
        {
            diamondScore += 1;
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        if (other.name.Equals("Emerald(Clone)"))
        {
            emeraldScore += 1;
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        if (other.name.Equals("Sell Gold"))
        {
            if (goldScore <= 0)
            {
                goldScore = 0;
                moneyScore += 0;
            }
            else if (goldScore >= 1)
            {
                goldScore -= 1;
                moneyScore += 5;
            }
        }
        if (other.name.Equals("Sell Diamonds"))
        {
            if (diamondScore <= 0)
            {
                diamondScore = 0;
                moneyScore += 0;
            }
            else if (diamondScore >= 1)
            {
                diamondScore -= 1;
                moneyScore += 10;
            }
        }
        if (other.name.Equals("Sell Emeralds"))
        {
            if (emeraldScore <= 0)
            {
                emeraldScore = 0;
                moneyScore += 0;
            }
            else if (emeraldScore >= 1)
            {
                emeraldScore -= 1;
                moneyScore += 20;
            }
        }
        goldCount.text = goldScore.ToString();
        diamondCount.text = diamondScore.ToString();
        emeraldCount.text = emeraldScore.ToString();
        moneyCount.text = moneyScore.ToString();
    }
}

