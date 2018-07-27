using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Health : MonoBehaviour {
	//Scriptet holder styr på Health
	
	
	//Health værdi fra start
	public int HealthValue = 100;

    private void Start()
    {
        GameManager.damageEvent.Invoke(gameObject, 0);
    }

    //void Update: Hver gang der tegnes et nyt billede
    void Update () {
	
		//Hvis Health er mindre eller lig med 0 går spillet videre til scenen "Lose"
		if (HealthValue <= 0)
		{
			SceneManager.LoadScene("Lose");
		}

        //Damage testing
        if(GameManager.instance.DebugMode && Input.GetKeyDown(KeyCode.K))
        {
            ReceiveDamage(5);
        }
	}
	
	
	// modtager damage værdi fra andre objekter, trækker damage fra Health
	public void ReceiveDamage (int damage) 
	{
		HealthValue = HealthValue - damage;
        GameManager.damageEvent.Invoke(gameObject, damage);
	}
	
}
