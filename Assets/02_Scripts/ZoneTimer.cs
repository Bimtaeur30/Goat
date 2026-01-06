using TMPro;
using UnityEngine;

public class ZoneTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeTxt;
    private bool inZone = false;
    private float timer = 0.0f;
    private void Update()
    {
        if (inZone)
        {
            timer += Time.deltaTime;
            timeTxt.text = timer.ToString("F1");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goat"))
        {
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Goat"))
        {
            inZone = false;
        }
    }
}
