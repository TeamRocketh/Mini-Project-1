using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject Lights;
    public Material Ill;

    public bool lit = false;

    public Image text;
    public Button exit;

    public static bool ill = false;
    bool quitting = false, quitting2 = false;

    private void Start()
    {
        text.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        Ill.color = new Color(0, 0, 0, 1);
        if (!lit)
        {
            Ill.SetColor("_EmissionColor", Color.black);
            Lights.SetActive(false);
        }
        else
        {
            //Ill.SetColor("_EmissionColor", new Color(0, 1, 0.8f, 1));
            Ill.SetColor("_EmissionColor", new Color(0, 0.76f, 1, 1));
            Lights.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if (SceneManager.GetActiveScene().buildIndex == 0)
                ill = false;
        }
        if (ill)
        {
            Ill.color = new Color(0, 1, 0.6f, 1);
            Ill.SetColor("_EmissionColor", new Color(0, 1, 0.8f, 1));
            Lights.SetActive(true);
        }
        if (quitting && quitting2)
            Application.Quit();
    }

    private void OnApplicationQuit()
    {
        if (!quitting)
        {
            Application.CancelQuit();
            text.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
            quitting = true;
        }
    }

    public void ExitButton()
    {
        quitting2 = true;
    }
}
