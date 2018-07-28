using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomIndicator : MonoBehaviour {
    public string[] connectedRoomNames;

    private void Start()
    {
        RoomController.InitiateController();
    }
}
