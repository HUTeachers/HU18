using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Teleport : MonoBehaviour
{
    public Teleport connectedPortal;
    public float teleCooldown = 1;
    private bool stopMomentum = false;
    private static float TeleportCooldown = 0f;
    
    private void Start()
    {
        if (connectedPortal == null)
        {
            Debug.LogWarning("Der er ikke forbundet nogen portal i din teleporter!!");
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        // Spiller ændrer position i x og y retningen
        if (player.gameObject.CompareTag("Player") && TeleportCooldown <= 0)
        {
            //Flyt spilleren
            player.transform.position = connectedPortal.transform.position;
            
            //Aktiver cooldown (så man ikke teleporter tilbage instantly)
            TeleportCooldown = teleCooldown;

            if (stopMomentum)
            {
                //Set spillerens fart i x og y retninger til ingenting
                player.GetComponent<Rigidbody2D>().velocity = new Vector2();
                    
            }
        }
    }

    private void Update()
    {
        if (TeleportCooldown > 0)
        {
            TeleportCooldown -= Time.deltaTime;
        }
    }
}