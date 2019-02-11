using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : MonoBehaviour
{
    float timer = 0;

    private void Awake()
    {
        timer = Time.time;
    }

    private void Update()
    {
        if (Time.time - timer > 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
