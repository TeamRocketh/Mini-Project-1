using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBreak : MonoBehaviour
{
    public GameObject explode;

    Rigidbody boxRb;
    public int BoxHP = 1;
    public Vector3 boxSpawnLocation;
    Vector3 moveDir;

    void Start()
    {
        boxRb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PlayerController.isLongDashing)
        {
            BoxHP--;
            moveDir = other.GetComponent<PlayerController>().dir;
            if (BoxHP < 1)
            {
                FindObjectOfType<SoundManager>().SFX.PlayOneShot(SoundManager.instance.soundList[6]);
                Instantiate(explode, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }
    }
}
