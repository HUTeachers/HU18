using UnityEngine;
using UnityEngine.Events;

public class DamageEvent : UnityEvent<GameObject, float> {

    public static DamageEvent operator +(DamageEvent left, UnityAction<GameObject,float> right)
    {
        left.AddListener(right);
        return left;
    }

    public static DamageEvent operator -(DamageEvent left, UnityAction<GameObject, float> right)
    {
        left.RemoveListener(right);
        return left;
    }

}

public class EnemySpawnEvent : UnityEvent<int>
{

    public static EnemySpawnEvent operator +(EnemySpawnEvent left, UnityAction<int> right)
    {
        left.AddListener(right);
        return left;
    }

    public static EnemySpawnEvent operator -(EnemySpawnEvent left, UnityAction<int> right)
    {
        left.RemoveListener(right);
        return left;
    }

}

public class GameManager : MonoBehaviour {

    /// <summary>
    /// Handles current room and state
    /// </summary>
    public static RoomStateManager stateManager;

    public static GameManager instance;
	public static DamageEvent damageEvent;
    public static UnityEvent fire;
    public bool DebugMode = true;

    

    //Instance trick
    private void Awake()
    {
        if(instance == null)
        {
            damageEvent = new DamageEvent();
            fire = new UnityEvent();
        }
		this.InstanceTrick(ref instance);
		
        
    }
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShoutOnInvoke()
    {
        Debug.Log("Invoked");
    }

}
