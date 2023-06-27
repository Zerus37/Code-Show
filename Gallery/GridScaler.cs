using UnityEngine;
using UnityEngine.UI;

public class GridScaler : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup grid;

    void Start()
    {
        float width = grid.GetComponent<RectTransform>().rect.width;
        grid.cellSize = new Vector2(width * 0.45f, width/2);
        grid.spacing = new Vector2(width * 0.05f, 0f);
        Destroy(this);
    }
}
