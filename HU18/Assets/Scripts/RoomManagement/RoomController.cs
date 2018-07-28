using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour {
    /// <summary>
    /// Initializes the RoomController module. This method has multiple uses. It can be used to wake up
    /// the module, to get the current instance of the RoomController module.
    /// </summary>
    /// <returns>The current RoomController. If none exist, one will be instantiated and returned.</returns>
    public static RoomController InitiateController()
    {
        if (instance == null)
        {
            var go = new GameObject("RoomController");
            instance = go.AddComponent<RoomController>();
        }
        return instance;
    }
    private static RoomController instance;
    private static Scene currentScene
    {
        get
        {
            return SceneManager.GetActiveScene();
        }
    }

    private void OnEnable()
    {
        if(instance == null)
        {
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.activeSceneChanged += NewActiveScene;
            EstablishConnections(currentScene);
            DontDestroyOnLoad(this);
        } else
        {
            Destroy(this);
        }
    }

    private void NewActiveScene(Scene oldScene, Scene newScene)
    {
        EstablishConnections(newScene); 
    }

    private void EstablishConnections(Scene scene)
    {
        //Search for array of connected scenes from RoomIndicator object in new scene
        string[] nameArray = null;
        foreach(GameObject go in scene.GetRootGameObjects())
        {
            var indicator = go.GetComponentInChildren<RoomIndicator>();
            if(indicator != null)
            {
                nameArray = indicator.connectedRoomNames;
                break;
            }
        }

        //Unload all unused scenes
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var currentScene = SceneManager.GetSceneAt(i);
            if (currentScene != scene)
            {
                SceneManager.UnloadSceneAsync(currentScene);
            }
        }

        //Load new connected scenes
        if (nameArray != null)
        {
            foreach(string name in nameArray)
            {
                SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
            }
        }
    }

    private void OnDisable()
    {
        instance = null;
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.activeSceneChanged -= NewActiveScene;
    }

    /// <summary>
    /// Requests that the room controller loads a room with a given scene name. If the room in question has been
    /// preloaded, it will show that scene. Otherwise it will single load the scene with that name.
    /// </summary>
    /// <param name="name">The name of the room to be loaded.</param>
    public static void LoadRoom(string name)
    {
        Scene newScene = SceneManager.GetSceneByName(name);
        if(newScene.buildIndex == -1)
        {
            //SceneIsNotLoaded
            SceneManager.LoadScene(name);
        } else
        {
            //SceneIsLoaded
            instance.DisableScene(currentScene);
            SceneManager.SetActiveScene(newScene);
            instance.EnableScene(currentScene);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (mode == LoadSceneMode.Additive)
        {
            DisableScene(scene);
        } else
        {
            SceneManager.SetActiveScene(scene);
        }
    }

    private void DisableScene(Scene scene)
    {
        foreach (GameObject go in scene.GetRootGameObjects())
        {
            go.SetActive(false);
        }
    }

    private void EnableScene(Scene scene)
    {
        foreach(GameObject go in scene.GetRootGameObjects())
        {
            go.SetActive(true);
        }
    }
}
