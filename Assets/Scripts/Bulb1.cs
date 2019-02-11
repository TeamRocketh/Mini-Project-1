using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb1 : MonoBehaviour
{
    public Material Ill;
    public int number = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LevelManager.BulbCollected++;
            switch (number)
            {
                case 1:
                    PlayerController.canDash = true;
                    LevelManager.ill = true;
                    gameObject.SetActive(false);
                    break;
                case 2:
                    PlayerController.canLongDash = true;
                    Ill.SetColor("_EmissionColor", new Color(1, 0, 0, 1));
                    GameObject temp = GameObject.FindGameObjectWithTag("Lights").transform.GetChild(0).gameObject;
                    foreach (Transform tr in temp.transform)
                    {
                        tr.GetComponent<Light>().color = Color.red;
                    }
                    gameObject.SetActive(false);
                    break;
                case 3:
                    Ill.SetColor("_EmissionColor", new Color(1, 0.3f, 0));
                    PlayerController.canStoreDash = true;
                    PlayerController.dashHasCooldown = true;
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}
