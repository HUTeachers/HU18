using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
	public void ChangeScene(string sceneName)
	{
		RoomController.LoadRoom(sceneName);
		
	}
}
