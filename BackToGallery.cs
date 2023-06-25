using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackToGallery : MonoBehaviour, IBeginDragHandler, IDragHandler
{
	public void ChangeScene()
	{
		SceneManager.UnloadSceneAsync("PicView");
		ObjectDeactivator.instance.SetActivePool(true);
	}

#if UNITY_ANDROID
	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			ChangeScene();
		}
	}
#endif

#if UNITY_IPHONE
	[SerializeField] private float swipeDistanceNeed = 1f;
	[SerializeField] private float swipeDistance = 0f;
	
	public void OnBeginDrag(PointerEventData eventData)
	{
		swipeDistance = 0f;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
		{
			if (eventData.delta.x > 0)
			{
				swipeDistance += eventData.delta.x;

				if (swipeDistance >= swipeDistanceNeed)
				{
					ChangeScene();
				}
			}
		}
	}
#else
	public void OnBeginDrag(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}
#endif
}
