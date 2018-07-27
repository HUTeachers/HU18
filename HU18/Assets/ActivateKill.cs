using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateKill : MonoBehaviour, IActivatableObject {
    public void Activate()
    {
        Destroy(this.gameObject);
    }

}
