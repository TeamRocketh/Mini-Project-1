using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoleManager : MonoBehaviour
{
    public Text NotAvailable;

    public GameObject FireBoi;

    public static bool RedAvailable, BlueAvailable, OrangeAvailable;

    public static int Pole1, Pole2, Pole3;

    public static bool Won = false;

    private void Start()
    {
        FireBoi.SetActive(false);
        NotAvailable.gameObject.SetActive(false);

        if (LevelManager.hasRed == 1 && LevelManager.hasBlue == 1 && LevelManager.hasOrange == 1)
        {
            RedAvailable = BlueAvailable = OrangeAvailable = true;
            Pole1 = Pole2 = Pole3 = 0;
        }
        else if (LevelManager.hasBlue == 0)
        {
            NotAvailable.gameObject.SetActive(true);
            NotAvailable.GetComponent<Text>().text = "Blue Bulb not collected yet.\n[Space to quit]";
        }
        else if (LevelManager.hasRed == 0)
        {
            NotAvailable.gameObject.SetActive(true);
            NotAvailable.GetComponent<Text>().text = "Red Bulb not collected yet.\n[Space to quit]";
        }
        else if (LevelManager.hasOrange == 0)
        {
            NotAvailable.gameObject.SetActive(true);
            NotAvailable.GetComponent<Text>().text = "Orange Bulb not collected yet.\n[Space to quit]";
        }
    }

    private void Update()
    {
        if ((Pole1 == 2) && (Pole2 == 3) && (Pole3 == 1))
        {
            Won = true;
            FireBoi.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (NotAvailable.gameObject.activeInHierarchy)
                NotAvailable.gameObject.SetActive(false);
        }
    }
}