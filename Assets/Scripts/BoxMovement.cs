using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    Rigidbody boxRb;
    public int BoxHP=2;
    public Vector3 boxSpawnLocation;
    bool isMoving;
    bool triggered = false;
    GameObject temp = null;
    public float speed;
    Vector3 moveDir;

    public bool LastBox = false;
    public GameObject trigger;

    public Sprite Fine, Broke;
    public GameObject semiexplosion;
    public GameObject explosion;

    void Start()
    {
        boxSpawnLocation = transform.position;
        boxRb = GetComponent<Rigidbody>();
        isMoving = false;
    }
    
    void Update()
    {
        if (boxRb.velocity.x == 0 && boxRb.velocity.z == 0)
        {
            isMoving = false;
        }
        if (boxRb.velocity == Vector3.zero)
        {
            boxRb.isKinematic = true;
        }
        if(isMoving)
        {
            boxRb.velocity =  moveDir * speed;
        }
        if (boxRb.velocity.y < 0)
            boxRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        else boxRb.constraints = RigidbodyConstraints.FreezeRotation;
        if (triggered && temp != null)
        {
            if (PlayerController.isDashing && LastBox)
            {
                if (!trigger.GetComponent<OpenDoor>().cond)
                {
                    BoxHP--;

                    if (BoxHP == 1)
                    {
                        GameObject temp = transform.GetChild(0).gameObject;
                        foreach (Transform tr in temp.transform)
                        {
                            tr.GetComponent<SpriteRenderer>().sprite = Broke;
                        }
                    }
                    
                    moveDir = temp.GetComponent<PlayerController>().dir;
                    boxRb.isKinematic = false;
                    boxRb.velocity = moveDir * speed;
                    isMoving = true;
                    Instantiate(semiexplosion, transform.position, Quaternion.identity);

                    if (BoxHP == 0)
                    {
                        Instantiate(explosion, transform.position, Quaternion.identity);
                        transform.position = boxSpawnLocation + new Vector3(0, 1.5f, 0);
                        boxRb.velocity = new Vector3(0, -0.1f, 0);
                        BoxHP = 2;
                        GameObject temp = transform.GetChild(0).gameObject;
                        foreach (Transform tr in temp.transform)
                        {
                            tr.GetComponent<SpriteRenderer>().sprite = Fine;
                        }
                    }
                    triggered = false;
                }
            }
            else if (PlayerController.isDashing)
            {
                BoxHP--;

                if (BoxHP == 1)
                {
                    FindObjectOfType<SoundManager>().SFX.PlayOneShot(SoundManager.instance.soundList[1]);
                    GameObject temp = transform.GetChild(0).gameObject;
                    foreach (Transform tr in temp.transform)
                    {
                        tr.GetComponent<SpriteRenderer>().sprite = Broke;
                    }
                }

                moveDir = temp.GetComponent<PlayerController>().dir;
                boxRb.isKinematic = false;
                boxRb.velocity = moveDir * speed;
                isMoving = true;
                Instantiate(semiexplosion, transform.position, Quaternion.identity);

                if (BoxHP == 0)
                {
                    FindObjectOfType<SoundManager>().SFX.PlayOneShot(SoundManager.instance.soundList[4]);
                    Instantiate(explosion, transform.position, Quaternion.identity);
                    transform.position = boxSpawnLocation + new Vector3(0, 1.5f, 0);
                    boxRb.velocity = new Vector3(0, -0.1f, 0);
                    BoxHP = 2;
                    GameObject temp = transform.GetChild(0).gameObject;
                    foreach (Transform tr in temp.transform)
                    {
                        tr.GetComponent<SpriteRenderer>().sprite = Fine;
                    }
                }
                triggered = false;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            triggered = true;
            temp = col.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggered = false;
            temp = null;
        }
    }
}
