using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Donwloader : MonoBehaviour
{
    [SerializeField] private string baseAddress = "http://data.ikppbb.com/test-task-unity-data/pics/";
    [SerializeField] private string format = ".jpg";

    [SerializeField] private PicImage imagePrefab;
    [SerializeField] private Transform imageContainer;

    [SerializeField] private int maxNumber;

    private int innerCounter = 1;

	void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
		if (innerCounter > maxNumber)
		{
            return;
		}

        StartCoroutine(LoadImage(Instantiate(imagePrefab, imageContainer), innerCounter));
        innerCounter += 1;
    }

    IEnumerator LoadImage(PicImage image, int imgNum)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(baseAddress + imgNum.ToString() + format);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(baseAddress + imgNum.ToString() + format);
            Debug.Log(www.error);
            Destroy(image.gameObject);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            image.SetImg(Sprite.Create((Texture2D)myTexture, new Rect(0, 0, myTexture.width, myTexture.height), Vector2.one / 2));
        }
    }

    public void OnScroll(Vector2 scrollValue)
	{
		if (scrollValue.y < 0)
        {
            Spawn();
            Spawn();
		}
	}
}
