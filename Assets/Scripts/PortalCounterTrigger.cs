using TMPro;
using UnityEngine;

public class PortalCounterTrigger : MonoBehaviour
{
    [SerializeField] private AnomalyManager anomalyManager;
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;
        if (anomalyManager == null) return;
        
        anomalyManager.PortalEntered();
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
