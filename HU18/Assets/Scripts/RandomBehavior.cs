using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class RandomBehavior : MonoBehaviour {

    [SerializeField]
	private GameObject bulletPrefab;

	private Rigidbody2D rigidbody2d;

    private Transform playerRef;

	List<EnemyBehavior> Actions;

	IEnumerator behavior;

    [SerializeField]
    private bool AddMoveBehavior = true;

    [SerializeField]
    private bool AddShootBehavior = true;

	public bool AddRealMoveBehavior = true;


	// Use this for initialization
	void Start () {

        playerRef = GameObject.FindGameObjectWithTag("Player").transform;

		Actions = new List<EnemyBehavior>();

        if(AddMoveBehavior)
        {
            EnemyBehavior moveBehavior = new EnemyBehavior(new Func<IEnumerator>(MoveToPlace), 20);
            Actions.Add(moveBehavior);
        }

        if (AddShootBehavior)
        {
            EnemyBehavior shootBehavior = new EnemyBehavior(new Func<IEnumerator>(Shoot), 20);
            Actions.Add(shootBehavior);
        }

		if(AddRealMoveBehavior)
		{
			EnemyBehavior realMoveBehavior = new EnemyBehavior(new Func<IEnumerator>(RigidMovement), 20);
			Actions.Add(realMoveBehavior);
			rigidbody2d = GetComponent<Rigidbody2D>();
		}

		StartCoroutine(BehaveTimer());
	}

	IEnumerator BehaveTimer()
	{
		while(true)
		{
			behavior = SelectBehavior().action.Invoke();
			StartCoroutine(behavior);
			yield return new WaitForSeconds(1f);
			StopCoroutine(behavior);
		}
	}

	EnemyBehavior SelectBehavior()
	{
		EnemyBehavior returnBehavior = EnemyBehavior.Blank;
		int summarize = Actions.Sum(x => x.chance);
		int seed = UnityEngine.Random.Range(0, summarize);
		foreach (EnemyBehavior item in Actions)
		{
			seed -= item.chance;
			if(seed <= 0)
			{
				returnBehavior = item;
				break;
			}
		}

		return returnBehavior;
	}

	IEnumerator DebugMessage()
	{
		Debug.Log("Hey!");
		yield return new WaitForSeconds(0.5f);
		StopCoroutine(behavior);

	}

    IEnumerator Shoot()
    {

		if (Vector2.Distance(playerRef.position, transform.position) > 10f)
		{
			yield return new WaitForEndOfFrame();
			
		}
		else
		{
			Vector3 playerDirection = playerRef.position - transform.position;
			GameObject temp = Instantiate(bulletPrefab, transform.position + playerDirection.normalized + Tools.RandomizeVector(0.1f), Quaternion.identity);
			temp.GetComponent<Rigidbody2D>().AddForce(playerDirection.normalized, ForceMode2D.Impulse);
			yield return new WaitForSeconds(0.5f);
			StopCoroutine(behavior);
		}

    }

	IEnumerator RigidMovement()
	{
		
		Vector2 destination = new Vector2(transform.position.x, transform.position.y) + UnityEngine.Random.insideUnitCircle;
		float timestamp = Time.timeSinceLevelLoad;
		while (Vector2.Distance(destination, transform.position) > 0.2f && timestamp < Time.timeSinceLevelLoad +1f)
		{
			yield return new WaitForEndOfFrame();
			rigidbody2d.AddForce(destination, ForceMode2D.Force);
		}
		rigidbody2d.velocity = Vector2.zero;
		StopCoroutine(behavior);
	}
	IEnumerator MoveToPlace()
	{
		Vector2 destination = new Vector2(transform.position.x, transform.position.y) + UnityEngine.Random.insideUnitCircle;
		while (Vector2.Distance(destination, transform.position) > 0.2f)
		{
			yield return new WaitForEndOfFrame();
			transform.position = Vector2.MoveTowards(transform.position, destination, 0.1f);
		}
		StopCoroutine(behavior);
	}
}

	

