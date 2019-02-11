using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleManager : MonoBehaviour
{
    public static bool RedAvailable, BlueAvailable, OrangeAvailable;

    public static int Pole1, Pole2, Pole3;

    private void Start()
    {
        if (LevelManager.BulbCollected >= 3)
        {
            RedAvailable = BlueAvailable = OrangeAvailable = true;
            Pole1 = Pole2 = Pole3 = 0;
        }
    }

    private void Update()
    {
        if ((Pole1 == 3) && (Pole2 == 1) && (Pole3 == 2))
        {
            Debug.Log("WinWin");
        }
    }
}