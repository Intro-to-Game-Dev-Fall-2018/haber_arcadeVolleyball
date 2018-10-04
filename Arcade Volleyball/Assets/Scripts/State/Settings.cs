using UnityEngine;
using System.Collections;

// Attach this to a game object that exists in the initial scene
public class Settings : MonoBehaviour
{
    [Tooltip("Choose which GameSettings asset to use")]
    public GameSettings _settings; 
    
    // ReSharper disable once MemberCanBePrivate.Global
    public static GameSettings s;
    // ReSharper disable once MemberCanBePrivate.Global
    public static Settings instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Settings.instance == null)
        {
            Settings.instance = this;
        }
        
        else
        {
            Debug.LogWarning("A previously awakened Settings MonoBehaviour exists!", gameObject);
        }

        if (Settings.s == null)
        {
            Settings.s = _settings;
        }
    }
}