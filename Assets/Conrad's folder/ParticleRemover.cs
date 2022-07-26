using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRemover : MonoBehaviour
{
    Coroutine lastRoutine = null;

    // Start is called before the first frame update
    void Awake()
    {
        lastRoutine = StartCoroutine(MyParticle());
    }

    IEnumerator MyParticle()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }
}
