using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveFalse : MonoBehaviour
{
    float ActiveTime = -5;

    private void OnEnable()
    {
        ActiveTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - ActiveTime > 2)
        {
            GetComponent<Animator>().SetBool("FadeOut", true);
            StartCoroutine("Delay");
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
