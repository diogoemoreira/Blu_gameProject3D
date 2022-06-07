using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        } else
        {
            instance = this;
        }
    }

    public GameBaseState currentState;

    public InitialGameState InitialState = new InitialGameState();
    public GoToControlRoomState ControlRoomState = new GoToControlRoomState();
    public PowerOutGameState PowerOutState = new PowerOutGameState();
    public CheckBrothersRoomState CheckBrothersState = new CheckBrothersRoomState();
    void Start()
    {
        currentState = InitialState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(GameBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
