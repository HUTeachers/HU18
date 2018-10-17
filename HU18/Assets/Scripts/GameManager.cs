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

public class HeatEvent : UnityEvent<float>
{
    public static HeatEvent operator +(HeatEvent left, UnityAction<float> right)
    {
        left.AddListener(right);
        return left;
    }

    public static HeatEvent operator -(HeatEvent left, UnityAction<float> right)
    {
        left.RemoveListener(right);
        return left;
    }
}

public class ItemPickupEvent : UnityEvent<LootItem>
{
    public static ItemPickupEvent operator +(ItemPickupEvent left, UnityAction<LootItem> right)
    {
        left.AddListener(right);
        return left;
    }

    public static ItemPickupEvent operator -(ItemPickupEvent left, UnityAction<LootItem> right)
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

    //Handles all damage dealt
	public static DamageEvent damageEvent;

    //Handles firing the weapon
    public static UnityEvent fire;

    public static HeatEvent heatChange;

    public static ItemPickupEvent itemPickupEvent;

	public static UnityEvent jumpEvent;

#if UNITY_EDITOR
	public bool DebugMode = true;
#else
	public bool DebugMode = false;
#endif

	private void Awake()
    {
        if(instance == null)
        {
            damageEvent = new DamageEvent();
            fire = new UnityEvent();
            heatChange = new HeatEvent();
            itemPickupEvent = new ItemPickupEvent();
			jumpEvent = new UnityEvent();
		}
        //Makes sure that there is only one game manager
        this.InstanceTrick(ref instance);
		
        
    }


    void ShoutOnInvoke()
    {
        Debug.Log("Invoked");
    }

}
