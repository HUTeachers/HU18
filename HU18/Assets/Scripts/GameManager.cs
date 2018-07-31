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

public class GameManager : MonoBehaviour {
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
        fire.AddListener(ShoutOnInvoke);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShoutOnInvoke()
    {
        Debug.Log("Invoked");
    }

}
