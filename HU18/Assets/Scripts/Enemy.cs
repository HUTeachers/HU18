﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageAble {

    [SerializeField]
    private int Health = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int damage)
	{
		Health -= Mathf.Abs(damage);
		GameManager.damageEvent.Invoke(gameObject, damage);
		if(Health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
        GetComponent<EnemySpawnControl>().Die();
	}

	public int GetHealth()
	{
		return Health;
	}

}
