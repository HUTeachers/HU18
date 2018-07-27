using UnityEngine;
using System.Collections;

public class DealDamageToTag : MonoBehaviour
{
	//Hvor meget den skader
	public int amount;

	//Det tag som tager damage
	public string damageTag;


	//Bruges i kollisioer
	void OnCollisionEnter2D(Collision2D other)
	{
        OnTriggerEnter2D(other.collider);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(damageTag))
        {
            collision.gameObject.GetComponent<IDamageAble>().TakeDamage(amount);
        }
        else
        {
            IDamageAble temp = collision.gameObject.GetComponent<IDamageAble>();
            if (temp != null)
            {
                temp.TakeDamage(0);
            }
        }
    }

    //Kan bruges fra knapper
    public void DealDamageToTagButton()
	{
		GameObject.FindGameObjectWithTag (damageTag).GetComponent<Enemy>().TakeDamage(amount);
	}
}
