using TMPro;
using UnityEngine;

public class PortalCounterTrigger : MonoBehaviour
{
    [SerializeField] private AnomalyCounter anomalyCounter;
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        //for now i dont have anything in the game to be able to use the AddOne function

        if (!other.CompareTag(playerTag)) return;
        if (anomalyCounter == null) return;
        
        anomalyCounter.ResetToZero();
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
