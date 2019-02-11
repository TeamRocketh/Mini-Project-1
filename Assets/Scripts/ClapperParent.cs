using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClapperParent : MonoBehaviour
{
    public List<GameObject> Clappers;

    int currentUnit = 0;
    float timer = 0;

    private void Start()
    {
        Clappers[currentUnit++].GetComponent<Animator>().SetBool("Start", true);
        timer = Time.time;
    }

    private void Update()
    {
        if (Time.time - timer > 2 && currentUnit < Clappers.Count)
        {
            timer = Time.time;
            Clappers[currentUnit++].GetComponent<Animator>().SetBool("Start", true);
        }
    }
}
