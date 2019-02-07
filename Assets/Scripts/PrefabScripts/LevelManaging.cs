using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManaging : MonoBehaviour
{
    public GameObject Player;

    public static Vector3 respawnLocation;

    private void OnEnable()
    {
        Instantiate(Player, Vector3.zero, Quaternion.identity);
        respawnLocation = Player.transform.position;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("2_Levels");
    }
}
