using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

	public bool DebugMode = true;

    //Instance trick
    private void Awake()
    {
		this.InstanceTrick(ref instance);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
