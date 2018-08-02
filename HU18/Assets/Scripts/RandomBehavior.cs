using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class RandomBehavior : MonoBehaviour {

    [SerializeField]
	private GameObject bulletPrefab;

    private Transform playerRef;

	List<EnemyBehavior> Actions;

	IEnumerator behavior;

    [SerializeField]
    private bool AddMoveBehavior = true;

    [SerializeField]
    private bool AddShootBehavior = true;


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
        Vector3 playerDirection = playerRef.position - transform.position;
        GameObject temp = Instantiate(bulletPrefab, transform.position + playerDirection.normalized + Tools.RandomizeVector(0.1f), Quaternion.identity);
        temp.GetComponent<Rigidbody2D>().AddForce(playerDirection.normalized, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        StopCoroutine(behavior);
    }

	IEnumerator MoveToPlace()
	{
		Vector2 destination = new Vector2(transform.position.x, transform.position.y) + UnityEngine.Random.insideUnitCircle;
		while(Vector2.Distance(destination, transform.position) > 0.2f)
		{
			yield return new WaitForEndOfFrame();
			transform.position = Vector2.MoveTowards(transform.position, destination, 0.1f);
		}
		StopCoroutine(behavior);
	}

}
