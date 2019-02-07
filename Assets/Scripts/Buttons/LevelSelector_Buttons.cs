using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelector_Buttons : MonoBehaviour
{
    public Text PopUp;

    public void LoadLevel()
    {
        if (EventSystem.current.currentSelectedGameObject.name != "...")
            SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name);
        else
        {
            if (!PopUp.IsActive())
                PopUp.gameObject.SetActive(true);
        }
    }
}
