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
            switch (number)
            {
                case 1:
                    LevelManager.hasBlue = 1;
                    LevelManager.hasRed = 0;
                    LevelManager.hasOrange = 0;
                    PlayerController.canDash = true;
                    LevelManager.ill = true;
                    gameObject.SetActive(false);
                    other.transform.GetChild(1).GetComponent<Light>().range = 8;
                    break;
                case 2:
                    LevelManager.hasBlue = 1;
                    LevelManager.hasRed = 1;
                    LevelManager.hasOrange = 0;
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
                    LevelManager.hasBlue = 1;
                    LevelManager.hasRed = 1;
                    LevelManager.hasOrange = 1;
                    Ill.SetColor("_EmissionColor", new Color(1, 0.3f, 0));
                    PlayerController.canStoreDash = true;
                    PlayerController.dashHasCooldown = true;
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}
