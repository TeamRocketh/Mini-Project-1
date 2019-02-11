using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GameObject Lights;
    public Material Ill;

    public bool lit = false;

    Image text;
    Button exit;

    public static bool ill = false, poweredUp = false;
    bool quitting = false, quitting2 = false;

    static LevelManager instance = null;

    public static int BulbCollected = 3;

    public static Vector3 changePositionTo = Vector3.zero;
    public static bool hasKey = false;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        Ill.color = new Color(0, 0, 0, 1);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad < Time.deltaTime * 2)
        {
            text = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).GetComponent<Image>();
            exit = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1).GetComponent<Button>();
            text.gameObject.SetActive(false);
            exit.gameObject.SetActive(false);

            switch (SceneManager.GetActiveScene().name)
            {
                case "level_Menu":
                    if (poweredUp)
                    {
                        poweredUp = false;
                        PlayerController.canDash = PlayerController.canLongDash = true;
                        GameObject.FindGameObjectWithTag("Level1Door").transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else PlayerController.canDash = PlayerController.canLongDash = false;
                    break;
                case "Level1":
                    Ill.SetColor("_EmissionColor", Color.black);
                    Lights = GameObject.FindGameObjectWithTag("Lights");
                    Lights.transform.GetChild(0).gameObject.SetActive(false);
                    PlayerController.canDash = PlayerController.canLongDash = false;
                    break;
                case "Level2":
                    PlayerController.canDash = true; PlayerController.canLongDash = false;
                    //Ill.SetColor("_EmissionColor", new Color(0, 1, 0.8f, 1));
                    Ill.SetColor("_EmissionColor", new Color(0, 0.6f, 1, 1));
                    break;
                case "Level3":
                    PlayerController.canDash = PlayerController.canLongDash = true;
                    //Ill.SetColor("_EmissionColor", new Color(0, 1, 0.8f, 1));
                    Ill.SetColor("_EmissionColor", Color.red);
                    break;
                case "ExitHUB":
                    PlayerController.canDash = PlayerController.canLongDash = true;
                    break;
            }
        }

        if (Time.timeSinceLevelLoad < 0.1f && changePositionTo != Vector3.zero)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = changePositionTo;
            changePositionTo = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if (SceneManager.GetActiveScene().name == "Level1")
                ill = false;
            if (SceneManager.GetActiveScene().name == "Credits")
            {
                SceneManager.LoadScene("Level_Menu");
                changePositionTo = new Vector3(-10, 6.28f, -6);
            }
        }
        if (ill && SceneManager.GetActiveScene().name == "Level1")
        {
            ill = false;
            Ill.SetColor("_EmissionColor", new Color(0, 0.6f, 1, 1));
            Lights.transform.GetChild(0).gameObject.SetActive(true);
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
