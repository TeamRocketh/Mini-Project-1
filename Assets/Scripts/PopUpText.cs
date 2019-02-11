using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    public GameObject root;
    bool triggered = false;

    public bool bulb = false;

    private void Awake()
    {
        root.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            root.SetActive(true);
            triggered = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && triggered)
        {
            triggered = false;
            root.SetActive(false);
            if (bulb)
                gameObject.SetActive(false);
        }
    }
}
