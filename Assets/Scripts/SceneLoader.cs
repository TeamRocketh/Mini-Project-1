using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string level;
    public bool triggered = false;

    public int fromWhere = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(level);
            if (triggered)
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
        }
    }
}
