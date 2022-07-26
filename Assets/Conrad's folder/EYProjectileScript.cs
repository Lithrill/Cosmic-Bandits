using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EYProjectileScript : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public Transform gameoverposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Instantiate(gameOverCanvas, gameoverposition.transform.position, Quaternion.identity);
            Time.timeScale = 0f;
        }
    }
}
