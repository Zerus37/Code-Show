using UnityEngine;

public class GroundCheck : MonoBehaviour
{
	[SerializeField] private Player _player;

    void LateUpdate()
    {
        _player.Grounded = Physics.Raycast(transform.position, Vector3.down, 0.2f);
    }
}
