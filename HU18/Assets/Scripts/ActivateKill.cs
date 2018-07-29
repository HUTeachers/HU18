using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateKill : MonoBehaviour, IActivatableObject {
    public void Activate()
    {
        gameObject.SetActive(false);
        //Destroy(this.gameObject);
    }

}
