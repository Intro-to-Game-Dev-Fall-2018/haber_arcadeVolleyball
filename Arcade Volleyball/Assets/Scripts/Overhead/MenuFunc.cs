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
        Continue();
    }

    public void Continue()
    {
        _gm.unPause();
        _menu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Menu")) Continue();
    }
    

}
