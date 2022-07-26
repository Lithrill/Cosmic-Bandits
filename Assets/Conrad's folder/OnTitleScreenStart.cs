using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTitleScreenStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("ProjectorSoundWorking");
        FindObjectOfType<AudioManager>().Play("Space_Station_Ambience");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
