using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManaging : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("2_Levels");
    }
}
