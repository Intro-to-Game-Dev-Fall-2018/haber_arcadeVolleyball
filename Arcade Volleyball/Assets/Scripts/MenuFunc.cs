using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunc : MonoBehaviour
{

    private GameManager _gm;

    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Reset()
    {
        Time.timeScale = 1;
        _gm.ResetGame();
        CloseMenu();
    }

    public void Continue()
    {
        Time.timeScale = 1;
        CloseMenu();
    }

    private static void CloseMenu()
    {
        GameObject.Find("pauseMenu").SetActive(false);
    }
}
