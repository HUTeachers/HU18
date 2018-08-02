using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatText : MonoBehaviour
{

    public GameObject textTemplate;
    private void Start()
    {
        GameManager.damageEvent += CombatTextDemonstration;
        GameManager.damageEvent += SpawnCombatText;
    }


    public void CombatTextDemonstration(GameObject damagetaker, float damage)
    {
        Debug.Log("Hej Daniel, vidste du at " + damagetaker.name + " tog hele " + damage + " skade");
    }

    private void SpawnCombatText(GameObject damagetaker, float damage)
    {
        GameObject tt = Instantiate(textTemplate, transform);
        tt.GetComponent<Text>().text = damage.ToString();
        Vector3 viewPos = Camera.main.WorldToViewportPoint(damagetaker.transform.position);
        RectTransform rect = tt.GetComponent<RectTransform>();
        rect.anchorMin = viewPos;
        rect.anchorMax = viewPos;
    }

    private void OnDisable()
    {
        GameManager.damageEvent -= CombatTextDemonstration;
        GameManager.damageEvent -= SpawnCombatText;
    }
}