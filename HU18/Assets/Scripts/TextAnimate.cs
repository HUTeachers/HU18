using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimate : MonoBehaviour {
    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    internal void Animate()
    {
        StartCoroutine(animateText());
        Destroy(this.gameObject, 2f);
    }

    IEnumerator animateText()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D + Vector3.up * 0.5f;
        }
    }
}
