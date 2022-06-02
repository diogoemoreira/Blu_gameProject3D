using UnityEngine;

public abstract class GameBaseState
{
    public abstract void EnterState(GameStateManager gameState);

    public abstract void UpdateState(GameStateManager gameState);

}
