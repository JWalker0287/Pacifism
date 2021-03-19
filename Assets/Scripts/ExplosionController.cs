using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(Explode());
    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
