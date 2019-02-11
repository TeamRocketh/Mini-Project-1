using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClapperParent : MonoBehaviour
{
    List<GameObject> Clappers;

    int currentUnit = 0;
    float timer = 0;

    private void Start()
    {
        Clappers = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Clappers.Add(transform.GetChild(i).gameObject);
        }
        Clappers[currentUnit++].GetComponent<Animator>().SetBool("Start", true);
        timer = Time.time;
    }

    private void Update()
    {
        if ((Time.time - timer > 2) && (currentUnit < 3))
        {
            timer = Time.time;
            Clappers[currentUnit++].GetComponent<Animator>().SetBool("Start", true);
        }

        if ((Time.time - timer > 1) && (currentUnit < 7) && (currentUnit > 2))
        {
            timer = Time.time;
            Clappers[currentUnit++].GetComponent<Animator>().SetBool("Start", true);
        }

        if ((Time.time - timer > 0.5f) && (currentUnit < 14) && (currentUnit > 6))
        {
            timer = Time.time;
            Clappers[currentUnit++].GetComponent<Animator>().SetBool("Start", true);
        }
    }
}
