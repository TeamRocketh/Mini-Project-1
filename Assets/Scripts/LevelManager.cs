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

    public static bool From2 = false;

    static LevelManager instance = null;

    public static Vector3 changePositionTo = Vector3.zero;
    public static int hasRed = 0, hasBlue = 0, hasOrange = 0;
    public static bool hasKey = false;

    int Cheats = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Started");
        Ill.color = new Color(0, 0, 0, 1);

        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                hasRed = hasBlue = hasOrange = 0;
                break;
            case "Level2":
                hasRed = hasOrange = 0;
                hasBlue = 1;
                break;
            case "Level3":
                hasRed = hasBlue = 1;
                hasOrange = 0;
                break;
            case "Credits":
                hasRed = hasBlue = hasOrange = 0;
                break;
            case "ExitCredits":
                hasRed = hasBlue = hasOrange = 1;
                break;
        }
        /*
        if (SceneManager.GetActiveScene().name == "Level_Menu" && !poweredUp)
        {
            PlayerPrefs.DeleteAll();
        }*/

        if (PlayerPrefs.HasKey("level") && SceneManager.GetActiveScene().buildIndex != PlayerPrefs.GetInt("level") && Time.time < 1 && instance == this)
        {
            hasRed = PlayerPrefs.GetInt("Red");
            hasBlue = PlayerPrefs.GetInt("Blue");
            hasOrange = PlayerPrefs.GetInt("Orange");
            SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        }
    }

    void Update()
    {
        Debug.Log(hasBlue + " " + hasRed + " " + hasOrange);

        if (From2 && SceneManager.GetActiveScene().name == "Level_Menu" && GameObject.FindGameObjectWithTag("Door1").GetComponent<BoxCollider>().enabled == false)
        {
            GameObject.FindGameObjectWithTag("Door1").GetComponent<BoxCollider>().enabled = true;
            GameObject.FindGameObjectWithTag("Mesh1").GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Mesh2").GetComponent<MeshRenderer>().enabled = true;
            GameObject[] temp;
            temp = GameObject.FindGameObjectsWithTag("LevelDoorLight");
            foreach (GameObject g in temp)
                g.GetComponent<Light>().enabled = false;
        }

        if (Time.timeSinceLevelLoad < Time.deltaTime * 2)
        {
            if (!FindObjectOfType<SoundManager>().main.isPlaying && SceneManager.GetActiveScene().name != "Level_Menu" && SceneManager.GetActiveScene().name != "Credits" && !poweredUp)
                FindObjectOfType<SoundManager>().main.Play();

            switch (SceneManager.GetActiveScene().name)
            {
                case "level_Menu":
                    if (poweredUp)
                    {
                        poweredUp = false;
                        PlayerController.canDash = PlayerController.canLongDash = true; PlayerController.canStoreDash = false;
                        GameObject.FindGameObjectWithTag("Level1Door").transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else
                    {
                        PlayerController.canDash = PlayerController.canLongDash = PlayerController.canStoreDash = false;
                    }
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

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if (SceneManager.GetActiveScene().name == "Level1")
                ill = false;
            if (SceneManager.GetActiveScene().name == "ExitCredits")
            {
                PlayerPrefs.DeleteAll();
                Application.Quit();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name != "Credits")
                Application.Quit();
            else
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

        if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (Input.GetKey(KeyCode.K) && Cheats == 0)
            {
                Cheats++;
            }
            if (Input.GetKey(KeyCode.A) && Cheats == 1)
            {
                Cheats++;
            }
            if (Input.GetKey(KeyCode.Y) && Cheats == 2)
            {
                Cheats++;
            }
            if (Input.GetKey(KeyCode.J) && Cheats == 3)
            {
                Cheats++;
            }
            if (Input.GetKey(KeyCode.A) && Cheats == 4)
            {
                Cheats++;
            }
            if (Input.GetKey(KeyCode.Y) && Cheats == 5)
            {
                Cheats++;
            }

            if (Cheats == 6)
            {
                Cheats = 0;
                GameObject.FindGameObjectWithTag("Player").transform.localPosition = new Vector3(-40, 20, 17);
                Camera.main.transform.localPosition = new Vector3(0, 150, 0);
            }
        }
    }

    private void OnApplicationQuit()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "Level1":
                PlayerPrefs.SetInt("Red", 0);
                PlayerPrefs.SetInt("Blue", 0);
                PlayerPrefs.SetInt("Orange", 0);
                PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
                break;
            case "Level2":
                PlayerPrefs.SetInt("Red", 0);
                PlayerPrefs.SetInt("Blue", 1);
                PlayerPrefs.SetInt("Orange", 0);
                PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
                break;
            case "Level3":
                PlayerPrefs.SetInt("Red", 1);
                PlayerPrefs.SetInt("Blue", 1);
                PlayerPrefs.SetInt("Orange", 0);
                PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
                break;
            case "Credits":
                PlayerPrefs.DeleteAll();
                break;
            case "ExitCredits":
                PlayerPrefs.DeleteAll();
                break;
            case "ExitHUB":
                PlayerPrefs.SetInt("Red", 1);
                PlayerPrefs.SetInt("Blue", 1);
                PlayerPrefs.SetInt("Orange", 0);
                PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
                break;
            case "Level_Menu": //Have to add condition whether he exits while powered up or not but not sure how the flow of scripts work here so eff it. Lets call it a hack.
                PlayerPrefs.SetInt("Red", 1);
                PlayerPrefs.SetInt("Blue", 1);
                PlayerPrefs.SetInt("Orange", 0);
                break;
        }
    }
}
