using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum RoomState
{
    UnTouched,
    Clear
}


public class RoomStateManager : MonoBehaviour {

    public RoomState state;
    public static EnemySpawnEvent enemySpawn;
    public static int EnemySemaphorControl;

    public static UnityEvent roomClear;

    private bool isManager = false;

    private void OnEnable()
    {
        if(GameManager.stateManager == null)
        {
            if (state != RoomState.Clear)
            {

            }
            EnemySemaphorControl = 0;
            enemySpawn = new EnemySpawnEvent();
            enemySpawn += UpdateSemaphor;

            roomClear = new UnityEvent();

            GameManager.stateManager = this;
            isManager = true;

            if(state == RoomState.Clear)
            {
                StartCoroutine(ClearInAFrame()); 
            }

        }
            
        
    }


    IEnumerator ClearInAFrame()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        roomClear.Invoke();
    }

    // Use this for initialization
    void Start () {
        
	}

    private void OnDisable()
    {
        if(isManager)
        {
            GameManager.stateManager = null;
        }
    }

    private void UpdateSemaphor(int input)
    {
        EnemySemaphorControl += input;
        if(EnemySemaphorControl == 0 )
        {
            state = RoomState.Clear;
            roomClear.Invoke();
        }
    }


}
