using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject door, col;

    private void Start()
    {
        door.SetActive(false);
        col.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !door.activeInHierarchy)
        {
            door.SetActive(true);
            col.SetActive(false);
        }
    }
}
