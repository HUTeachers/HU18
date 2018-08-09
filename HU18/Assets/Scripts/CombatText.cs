using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatText : MonoBehaviour
{
    [SerializeField]
    private GameObject textTemplate;
    private void OnEnable()
    {
        GameManager.damageEvent += SpawnCombatText;
    }


    private void SpawnCombatText(GameObject damagetaker, float damage)
    {
        if(damage == 0f)
        {
            return;
        }

        GameObject tt = Instantiate(textTemplate, transform);
        tt.GetComponent<Text>().text = damage.ToString();
        Vector3 viewPos = Camera.main.WorldToViewportPoint(damagetaker.transform.position);
        RectTransform rect = tt.GetComponent<RectTransform>();
        rect.anchorMin = viewPos;
        rect.anchorMax = viewPos;
        tt.GetComponent<TextAnimate>().Animate();
    }

    private void OnDisable()
    {
        GameManager.damageEvent -= SpawnCombatText;
    }
}