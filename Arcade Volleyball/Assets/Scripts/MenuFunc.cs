using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunc : MonoBehaviour
{

    private GameManager _gm;
    private GameObject _menu;

    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _menu = GameObject.Find("pauseMenu");
    }

    public void Reset()
    {
        
        _gm.ResetGame();
        CloseMenu();
    }

    public void Continue()
    {
        CloseMenu();
    }

    private void CloseMenu()
    {
        Time.timeScale = 1;
       _menu.SetActive(false);
    }
}
