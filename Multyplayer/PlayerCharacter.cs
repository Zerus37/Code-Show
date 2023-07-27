using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	[SerializeField] private float speed = 2f;
	
	public void Move(Vector3 direction)
	{
		transform.position += direction * Time.deltaTime * speed;
	}
	
	public void GetMoveInfo(out Vector3 position)
	{
		position = transform.position;
	}
}
