using UnityEngine;
using UnityEngine.Events;

public class DamageEvent : UnityEvent<GameObject, float> { }

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
