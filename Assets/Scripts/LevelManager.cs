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

    public static bool ill = false, poweredUp = false;

    static LevelManager instance = null;

    public static int BulbCollected = 3;

    public static Vector3 changePositionTo = Vector3.zero;
    public static bool hasKey = false;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        }
    }

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
            switch (SceneManager.GetActiveScene().name)
            {
                case "level_Menu":
                    if (poweredUp)
                    {
                        Debug.Log("Fucku");
                        poweredUp = false;
                        PlayerController.canDash = PlayerController.canLongDash = true; PlayerController.canStoreDash = false;
                         GameObject.FindGameObjectWithTag("Level1Door").transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else PlayerController.canDash = PlayerController.canLongDash = PlayerController.canStoreDash = false;
                    break;
                case "Level1":
                    Ill.SetColor("_EmissionColor", Color.black);
                    Lights = GameObject.FindGameObjectWithTag("Lights");
                    Lights.transform.GetChild(0).gameObject.SetActive(false);
                    PlayerController.canDash = PlayerController.canLongDash = PlayerController.canStoreDash = false;
                    break;
                case "Level2":
                    PlayerController.canDash = true; PlayerController.canLongDash = PlayerController.canStoreDash = false;
                    Ill.SetColor("_EmissionColor", new Color(0, 0.6f, 1, 1));
                    break;
                case "Level3":
                    PlayerController.canDash = PlayerController.canLongDash = true;
                    Ill.SetColor("_EmissionColor", Color.red);
                    break;
                case "ExitHUB":
                    if (poweredUp)
                    {
                        PlayerController.canDash = PlayerController.canLongDash = PlayerController.canStoreDash = true;
                    }
                    else
                    {
                        PlayerController.canDash = PlayerController.canLongDash = true;
                        PlayerController.canStoreDash = false;
                    }
                    break;
            }
        }

        if (Time.timeSinceLevelLoad < 0.1f && changePositionTo != Vector3.zero)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = changePositionTo;
            changePositionTo = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.P))
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (ill && SceneManager.GetActiveScene().name == "Level1")
        {
            ill = false;
            Ill.SetColor("_EmissionColor", new Color(0, 0.6f, 1, 1));
            Lights.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnApplicationQuit()
    {
        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2" || SceneManager.GetActiveScene().name == "Level3")
        {
            PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
        }
    }
}
