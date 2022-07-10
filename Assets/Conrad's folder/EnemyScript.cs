using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject soldier, uranium;
    public Transform spawnPosition;
    public string enemyTag;

    public void Start()
    {
        enemyTag = soldier.tag;
    }

    private void OnEnable()
    {
        EventManager.OnkillEnemyEvent += EnemyDeath;
    }

    private void OnDisable()
    {
        EventManager.OnkillEnemyEvent -= EnemyDeath;
    }

    private void EnemyDeath(string enemySpecifier)
    {
        if (enemyTag == enemySpecifier)
        {
            Instantiate(uranium, spawnPosition.transform.position, Quaternion.identity);
            soldier.SetActive(false);
        }
    }
}
