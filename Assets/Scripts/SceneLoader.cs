using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string level;
    public bool powerHimUp = false;

    public int fromWhere = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(level);
            if (powerHimUp)
            {
                LevelManager.poweredUp = true;
            }
            if (level == "Level_Menu")
            {
                if (fromWhere == 1)
                    LevelManager.changePositionTo = new Vector3(10, 6.28f, 17);
                else if (fromWhere == 2)
                    LevelManager.changePositionTo = new Vector3(0, 6.28f, 18);
            }
            if (level == "ExitHUB")
            {
                if (fromWhere == 1)
                    LevelManager.changePositionTo = new Vector3(-10, 6.28f, 18);
                else if (fromWhere == 2)
                    LevelManager.changePositionTo = new Vector3(10, 6.28f, 28);
            }
        }
    }
}
