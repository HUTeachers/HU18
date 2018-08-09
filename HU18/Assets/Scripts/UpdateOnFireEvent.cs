using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateOnFireEvent : MonoBehaviour {
    Slider slider;
	// Use this for initialization
	void OnEnable () {
        GameManager.heatChange.AddListener(UpdateSlider);
        slider = GetComponent<Slider>();

        //
        UpdateSlider(GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<FiringManagement>().GetHeat());

    }

    private void UpdateSlider(float sliderHeat)
    {
        slider.value = sliderHeat;
    }

    private void OnDisable()
    {
        GameManager.heatChange.RemoveListener(UpdateSlider);
    }
}
