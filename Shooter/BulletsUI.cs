using UnityEngine;
using UnityEngine.UI;

public class BulletsUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _bar;

    void Start()
    {
        _player.OnBulletChange.AddListener(BulletUpdate);
    }

    private void BulletUpdate(int count)
	{
        _bar.value = count;
    }
}
