using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject RGVKA;
    float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LevelManager.hasKey = true;
            timer = Time.time;
            transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }
    }

    private void Update()
    {
        if (LevelManager.hasKey && Time.time - timer > 0.5f)
        {
            timer = Time.time;
            Instantiate(RGVKA, new Vector3(Random.Range(-12f, 12f), 6.28f, Random.Range(2, 18)), Quaternion.identity);
        }
    }
}
