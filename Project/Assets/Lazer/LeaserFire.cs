using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaserFire : MonoBehaviour
{
    [SerializeField] GameObject Leaser;
    [SerializeField] float Seconds;
    private void OnEnable()
    {
        StartCoroutine(Dis());
    }

    IEnumerator Dis()
    {
        yield return new WaitForSeconds(Seconds);
        Leaser.SetActive(false);
        StartCoroutine(Enable());

    }

    IEnumerator Enable()
    {
        yield return new WaitForSeconds(Seconds);
        Leaser.SetActive(true);
        StartCoroutine(Dis());
    }

}
