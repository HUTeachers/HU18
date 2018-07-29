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
            RoomController.LoadRoom(connectedRoom);
        }    
    }

}
