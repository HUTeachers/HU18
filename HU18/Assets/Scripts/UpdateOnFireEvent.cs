using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateOnFireEvent : MonoBehaviour {
    Slider slider;
    FiringManagement fireManagement;
	// Use this for initialization
	void Start () {
        GameManager.fire.AddListener(UpdateSlider);
        slider = GetComponent<Slider>();
        fireManagement = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<FiringManagement>();
    }

    private void UpdateSlider()
    {
        if (fireManagement == null)
        {
            fireManagement = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<FiringManagement>();
        }
        slider.value = fireManagement.GetHeat();
    }

    private void OnDisable()
    {
        GameManager.fire.RemoveListener(UpdateSlider);
    }
}
