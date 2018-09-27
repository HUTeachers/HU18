using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventEnum
{
	Fire,
	Damage,
	ItemPickUp,
	Jump
}

[RequireComponent(typeof(AudioSource))]
public class PlayOnEvent : MonoBehaviour {

	public EventEnum eventEnum;
	private AudioSource aSource;
	// Use this for initialization
	void Start () {
		aSource = GetComponent<AudioSource>();
		switch (eventEnum)
		{
			case EventEnum.Fire:
				GameManager.fire.AddListener(EventPlayer); break;
			case EventEnum.Damage:
				GameManager.damageEvent.AddListener(EventPlayer); break;
			case EventEnum.ItemPickUp:
				GameManager.itemPickupEvent.AddListener(EventPlayer); break;
			case EventEnum.Jump:
				GameManager.jumpEvent.AddListener(EventPlayer); break;
			default:
				break;
		}
	}
	
	private void EventPlayer()
	{
		aSource.Play();
	}
	private void EventPlayer(LootItem item)
	{
		EventPlayer();
	}

	private void EventPlayer(GameObject damagetaker, float value)
	{
		EventPlayer();
	}
}
