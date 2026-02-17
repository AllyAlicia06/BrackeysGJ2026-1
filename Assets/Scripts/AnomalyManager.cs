using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    [SerializeField] private AnomalyCounter counter;
    
    [Header("Anomalies")]
    [SerializeField] private List<PropAnomaly> propAnomalyList = new();
    [SerializeField] private List<TextAnomaly> textAnomalyList = new();
    
    private IAnomaly currentAnomaly;
    private IAnomaly lastAnomaly;
    private bool foundThisRound = false;

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip collectClip;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var anomaly in propAnomalyList)
            if(anomaly != null)
                anomaly.gameObject.SetActive(false);

        PickNext();
    }

    public IAnomaly Current => currentAnomaly;
    
    public void ResolveCurrentAnomaly()
    {
        if (currentAnomaly == null) return;
        foundThisRound = true;
        counter?.AddOne();
        
        if(sfxSource != null && collectClip != null)
            sfxSource.PlayOneShot(collectClip);
        
        currentAnomaly.Resolve();
    }

    public void PortalEntered()
    {
        if(!foundThisRound)
            counter?.ResetToZero();
        
        foundThisRound = false;
        PickNext();
    }

    private void PickNext()
    {
        currentAnomaly?.Deactivate();
        
        var pool = new List<IAnomaly>();
        foreach (var anomaly in propAnomalyList) if (anomaly != null) pool.Add(anomaly);
        foreach (var anomaly in textAnomalyList) if (anomaly != null) pool.Add(anomaly);

        if (pool.Count == 0) return;

        IAnomaly chosen;
        if(pool.Count == 1) chosen = pool[0];
        else
        {
            chosen = pool[Random.Range(0, pool.Count)];
            if(chosen == lastAnomaly) chosen = pool[Random.Range(0, pool.Count)];
        }
        
        lastAnomaly = currentAnomaly;
        currentAnomaly = chosen;
        currentAnomaly.Activate();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
