using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct EnemyBehavior {
	public Func<IEnumerator> action;
	public int chance;

    public EnemyBehavior(Func<IEnumerator> inputaction, int inputchance)
    {
        chance = inputchance;
        action = inputaction;
    }

	private static EnemyBehavior createBlank()
	{
		EnemyBehavior enemyBehavior = new EnemyBehavior
		{
			action = null,
			chance = 0
		};

		return enemyBehavior;
	}
	public static EnemyBehavior Blank
	{
		get { return createBlank(); }
	}
    
}

