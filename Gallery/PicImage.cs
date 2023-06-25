using UnityEngine;
using UnityEngine.UI;

public class PicImage : MonoBehaviour
{
	public static ProgressPopUp progressPopUp;

	[SerializeField] private Image img;
	[SerializeField] private ParticleSystem particle;
	private Sprite sprite;
	private bool ready = false;

	public void SetImg(Sprite _sprite)
	{
		Destroy(particle);
		sprite = _sprite;
		img.sprite = sprite;
		img.enabled = true;
		ready = true;
	}

	public void ShowImg()
	{
		if (ready)
		{
			PicView.currentSprite = sprite;
			progressPopUp.gameObject.SetActive(true);
		}
	}
}
