using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunc : MonoBehaviour {

    public void Reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        GameObject.Find("MenuCanvas").SetActive(false);
    }
    
}
