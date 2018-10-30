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
        if (instance == null)
            instance = this;
        if (s == null)
            s = _settings;
    }
}