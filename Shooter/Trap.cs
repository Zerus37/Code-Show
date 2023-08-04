using UnityEngine;

public class Trap : MonoBehaviour
{
	[SerializeField] private float damage = 7f;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent<Life>(out Life victim))
		{
			victim.TakeDamage(damage);
		}
	}
}
