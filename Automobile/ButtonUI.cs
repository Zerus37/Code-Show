using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private UnityEvent<bool> triggerFunc;

	public void OnPointerDown(PointerEventData eventData)
    {
        triggerFunc.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        triggerFunc.Invoke(false);
    }
}