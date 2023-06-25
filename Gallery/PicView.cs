using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PicView : MonoBehaviour
{
    public static Sprite currentSprite;
    [SerializeField] private Image img;

    void Awake()
    {
        img.sprite = currentSprite;
    }
}
