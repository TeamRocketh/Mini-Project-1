using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Buttons : MonoBehaviour
{
    public void LevelSelector()
    {
        SceneManager.LoadScene("2_Levels");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
