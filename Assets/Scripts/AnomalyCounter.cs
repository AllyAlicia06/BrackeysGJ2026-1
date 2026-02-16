using UnityEngine;

public class AnomalyCounter : MonoBehaviour
{
    [SerializeField] private AnomalyCounterUI ui;
    [SerializeField] private int maxAnomalies = 5;
    [SerializeField] private int currentCount = 0;

    public int CurrentCount => currentCount;
    public int MaxAnomalies => maxAnomalies;

    private void Awake()
    {
        ApplyToUI();
    }

    public void ResetToZero()
    {
        currentCount = 0;
        ApplyToUI();
    }

    public void AddOne()
    {
        currentCount = Mathf.Clamp(currentCount + 1, 0, maxAnomalies);
        ApplyToUI();
    }

    private void ApplyToUI()
    {
        if(ui != null)
            ui.Set(currentCount, maxAnomalies);
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
