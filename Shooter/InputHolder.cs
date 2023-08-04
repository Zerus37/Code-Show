using UnityEngine;

public class InputHolder : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Camera _cam;
    [SerializeField] private float _mouseSensetivity = 1f;
    [SerializeField] private GameObject _menuPopup;

    private bool _recoilOn =  true;
    private StateMachine _stateMachine;

    private GameState _gameState;
    private MenuState _menuState;
    private bool _game = true;

	private void Start()
    {
        _recoilOn = PlayerPrefs.GetInt("recoilOn", 1) == 1;

        _gameState = new GameState(_player, _cam, _mouseSensetivity, _recoilOn);
        _menuState = new MenuState(_menuPopup);

        _stateMachine = new StateMachine();
        _stateMachine.Iitialize(_gameState);
    }

    public void SetRecoil(bool flag)
    {
        if (flag)
            PlayerPrefs.SetInt("recoilOn", 1);
        else
            PlayerPrefs.SetInt("recoilOn", 0);

        _recoilOn = PlayerPrefs.GetInt("recoilOn", 1) == 1;
        _gameState.ChangeRecoil();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
		{
            if(_game)
                _stateMachine.ChangeState(_menuState);
            else
                _stateMachine.ChangeState(_gameState);

            _game = !_game;
        }

        _stateMachine.CurrentState.Update();
    }
}
