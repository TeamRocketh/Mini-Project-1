using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleManager : MonoBehaviour
{
    public GameObject FireBoi;

    public static bool RedAvailable, BlueAvailable, OrangeAvailable;

    public static int Pole1, Pole2, Pole3;

    public static bool Won = false;

    private void Start()
    {
        FireBoi.SetActive(false);

        if (LevelManager.BulbCollected >= 3)
        {
            RedAvailable = BlueAvailable = OrangeAvailable = true;
            Pole1 = Pole2 = Pole3 = 0;
        }
    }

    private void Update()
    {
        if ((Pole1 == 2) && (Pole2 == 3) && (Pole3 == 1))
        {
            Won = true;
            FireBoi.SetActive(true);
        }
    }
}