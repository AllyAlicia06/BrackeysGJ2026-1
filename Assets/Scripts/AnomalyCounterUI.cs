using TMPro;
using UnityEngine;

public class AnomalyCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text anomalyCounterText;

    public void Set(int currentCount, int maxAnomalies)
    {
        if (anomalyCounterText == null) return;
        anomalyCounterText.text = $"Anomalies found: {currentCount}/{maxAnomalies}";
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
