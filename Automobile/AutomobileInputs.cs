using UnityEngine;

public class AutomobileInputs : MonoBehaviour
{
    [SerializeField] private AutomobileEngine auto;

    private bool upInput = false;
	private bool downInput = false;
	private bool leftInput = false;
	private bool rightInput = false;

    public bool UpInput{ set => upInput = value;}
    public bool DownInput{set => downInput = value;}
    public bool LeftInput{set => leftInput = value;}
    public bool RightInput{set => rightInput = value;}

    private Vector2 moveVector = new Vector2(0f,0f);

	void Update()
    {
#if UNITY_EDITOR
		auto.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
#else
        moveVector = Vector2.zero;
        if (upInput)
            moveVector.y += 1f;
        if (downInput)
            moveVector.y -= 1f;
        if (leftInput)
            moveVector.x -= 1f;
        if (rightInput)
            moveVector.x += 1f;

        auto.Move(moveVector);
#endif
    }
}
