using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleScript : MonoBehaviour
{
    bool inside = false;

    public int PoleNumber = 0;

    private void Start()
    {
        transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.black;
        transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Light>().color = Color.black;
        transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && (LevelManager.hasRed == 1 && LevelManager.hasBlue == 1 && LevelManager.hasOrange == 1))
            inside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            inside = false;
    }

    private void Update()
    {
        if (inside)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && PoleManager.RedAvailable)
            {
                switch (PoleNumber)
                {
                    case 1:
                        if (PoleManager.Pole1 == 0)
                        {
                            PoleManager.Pole1 = 1;
                            PoleManager.RedAvailable = false; transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.red;
                            transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Light>().color = Color.red;
                            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                        }
                        break;
                    case 2:
                        if (PoleManager.Pole2 == 0)
                        {
                            PoleManager.Pole2 = 1;
                            PoleManager.RedAvailable = false; transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.red;
                            transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Light>().color = Color.red;
                            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                        }
                        break;
                    case 3:
                        if (PoleManager.Pole3 == 0)
                        {
                            PoleManager.Pole3 = 1;
                            PoleManager.RedAvailable = false; transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.red;
                            transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Light>().color = Color.red;
                            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                        }
                        break;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && PoleManager.BlueAvailable)
            {
                switch (PoleNumber)
                {
                    case 1:
                        if (PoleManager.Pole1 == 0)
                        {
                            PoleManager.Pole1 = 2;
                            PoleManager.BlueAvailable = false; transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(0, 0.6f, 1, 1);
                            transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Light>().color = new Color(0, 0.6f, 1, 1);
                            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0.6f, 1, 1));
                        }
                        break;
                    case 2:
                        if (PoleManager.Pole2 == 0)
                        {
                            PoleManager.Pole2 = 2;
                            PoleManager.BlueAvailable = false; transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(0, 0.6f, 1, 1);
                            transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Light>().color = new Color(0, 0.6f, 1, 1);
                            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0.6f, 1, 1));
                        }
                        break;
                    case 3:
                        if (PoleManager.Pole3 == 0)
                        {
                            PoleManager.Pole3 = 2;
                            PoleManager.BlueAvailable = false; transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(0, 0.6f, 1, 1);
                            transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Light>().color = new Color(0, 0.6f, 1, 1);
                            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0.6f, 1, 1));
                        }
                        break;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && PoleManager.OrangeAvailable)
            {
                switch (PoleNumber)
                {
                    case 1:
                        if (PoleManager.Pole1 == 0)
                        {
                            PoleManager.Pole1 = 3;
                            PoleManager.OrangeAvailable = false; transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.3f, 0);
                            transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Light>().color = new Color(1, 0.3f, 0);
                            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(1, 0.3f, 0));
                        }
                        break;
                    case 2:
                        if (PoleManager.Pole2 == 0)
                        {
                            PoleManager.Pole2 = 3;
                            PoleManager.OrangeAvailable = false; transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.3f, 0);
                            transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Light>().color = new Color(1, 0.3f, 0);
                            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(1, 0.3f, 0));
                        }
                        break;
                    case 3:
                        if (PoleManager.Pole3 == 0)
                        {
                            PoleManager.Pole3 = 3;
                            PoleManager.OrangeAvailable = false; transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.3f, 0);
                            transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Light>().color = new Color(1, 0.3f, 0);
                            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(1, 0.3f, 0));
                        }
                        break;
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.black;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Light>().color = Color.black;
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);

                switch (PoleNumber)
                {
                    case 1:
                        if (PoleManager.Pole1 == 1)
                            PoleManager.RedAvailable = true;
                        else if (PoleManager.Pole1 == 2)
                            PoleManager.BlueAvailable = true;
                        else if (PoleManager.Pole1 == 3)
                            PoleManager.OrangeAvailable = true;
                        PoleManager.Pole1 = 0;
                        break;
                    case 2:
                        if (PoleManager.Pole2 == 1)
                            PoleManager.RedAvailable = true;
                        else if (PoleManager.Pole2 == 2)
                            PoleManager.BlueAvailable = true;
                        else if (PoleManager.Pole2 == 3)
                            PoleManager.OrangeAvailable = true;
                        PoleManager.Pole2 = 0;
                        break;
                    case 3:
                        if (PoleManager.Pole3 == 1)
                            PoleManager.RedAvailable = true;
                        else if (PoleManager.Pole3 == 2)
                            PoleManager.BlueAvailable = true;
                        else if (PoleManager.Pole3 == 3)
                            PoleManager.OrangeAvailable = true;
                        PoleManager.Pole3 = 0;
                        break;
                }
            }
        }
    }
}
