using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopupController : MonoBehaviour
{
    public float duration = 0.3f;

    void OnEnable()
    {
        StartCoroutine(Popup());
    }
    IEnumerator Popup()
    {
        for (float t = 0; t <= duration; t += Time.deltaTime)
        {
            float frac = t / duration;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, frac);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(duration);
         for (float t = 0; t <= duration; t += Time.deltaTime)
        {
            float frac = t / duration;
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, frac);
            yield return new WaitForEndOfFrame();
        }
        gameObject.SetActive(false);
    }
}
