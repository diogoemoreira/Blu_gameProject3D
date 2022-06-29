using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameStateChangeEvent : UnityEvent<GameBaseState> {}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public GameStateChangeEvent GSChangeEvent;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        } else
        {
            instance = this;
        }

        GSChangeEvent = new GameStateChangeEvent();
    }

    public GameBaseState currentState;

    public InitialGameState InitialState = new InitialGameState();
    public GoToControlRoomState ControlRoomState = new GoToControlRoomState();
    public PowerOutGameState PowerOutState = new PowerOutGameState();
    public CheckBrothersRoomState CheckBrothersState = new CheckBrothersRoomState();
    public SearchFamilyState SearchFamState = new SearchFamilyState();
    public CheckMainDoorState CheckMainDoorState = new CheckMainDoorState();
    public FindDoorManualState DoorManualState = new FindDoorManualState();
    public EnterMachineRoomState MachineRoomState = new EnterMachineRoomState();
    public TurnOffPowerState TurnOffPowerState = new TurnOffPowerState();
    public PickUpSuitState PickUpSuitState = new PickUpSuitState();
    void Start()
    {
        currentState = InitialState;

        currentState.EnterState(this);
        GSChangeEvent.Invoke(currentState);
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
        GSChangeEvent.Invoke(currentState);
    }
}
