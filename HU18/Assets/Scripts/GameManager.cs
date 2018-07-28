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
	public bool DebugMode = true;

    

    //Instance trick
    private void Awake()
    {
		this.InstanceTrick(ref instance);
		damageEvent = new DamageEvent();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
