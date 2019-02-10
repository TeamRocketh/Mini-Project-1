﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructableWallOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            gameObject.SetActive(false);
    }
}
