using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGm : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            if(!FindObjectOfType<SoundManager>().main.isPlaying)
                FindObjectOfType<SoundManager>().main.Play();
        }
    }
}
