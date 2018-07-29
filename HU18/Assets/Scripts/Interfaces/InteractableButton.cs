using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour, IDamageAble {
    [SerializeField]
    private GameObject ActivateObject;
    
    private IActivatableObject AttachedObject;
    // Use this for initialization
    private void Start()
    {

        //AttachedObject = ActivateObject.GetComponent<IActivatableObject>();
    }

    public void TakeDamage(int damage)
    {
        if(ActivateObject != null)
        {
            AttachedObject.Activate();
        }
    }
}
