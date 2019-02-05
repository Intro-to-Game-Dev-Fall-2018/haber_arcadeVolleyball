using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuDecorator : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private SpriteRenderer BG;
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private Camera SceneCamera;
    [SerializeField] private Graphic _1Player;
    [SerializeField] private Graphic _2Player;

    
    [Header("Skins")]
    [SerializeField] private GameSkin[] skins;

    private void Start()
    {
       SetSkin(skins[Random.Range(0,skins.Length)]);
    }
	
    private void SetSkin(GameSkin skin)
    {
//        BG.sprite = skin.BackgroundSprite;
        Title.color = skin.TitleColor;
        SceneCamera.backgroundColor = skin.BackgroundColor;
        _1Player.color = skin.P1A;
        _1Player.GetComponentInChildren<Text>().color = Color.black;
        _2Player.color = skin.P2A;
        _2Player.GetComponentInChildren<Text>().color = Color.black;

    }

    
}
