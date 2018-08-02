using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DoorDirection
{
    Up,
    Down,
    Left,
    Right
}

public class RoomIndicator : MonoBehaviour {

    [SerializeField]
    private string connectedRoom;

    [SerializeField]
    private DoorDirection direction;

    [SerializeField]
    private KeyEnum requiredKey = KeyEnum.None;

    public string GetConnectedRoom()
    {
        return connectedRoom;
    }

    public DoorDirection GetDirection()
    {
        return direction;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) && collision.GetComponent<Inventory>().KeyCheck(requiredKey))
            {

                RoomController.LoadRoom(connectedRoom);
            }
            
        }    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }
}
