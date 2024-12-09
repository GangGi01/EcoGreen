using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum State
    {
        Idle,
        Aggressive,
        Defensive,
        ResourceGathering
    }

    // 난이도 0 : 쉬움, 1 : 보통, 2 : 어려움
    private State state;
    private int difficulty = 0;
    private int resource = 0;


    private void Start()
    {
        state = State.Idle;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Idle:
                break;

            case State.Aggressive:
                break;

            case State.Defensive:
                break;

            case State.ResourceGathering:
                break;

        }
    }

    private void ChangeState(State newState)
    {
        state = newState;
    }

    private void IdleState()
    {

    }

    private void AggressiveState()
    {

    }

    private void DefensiveState()
    {

    }

    private void ResourceGatheringState()
    {
    
    }

}
