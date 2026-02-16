using UnityEngine;

public class PropAnomaly : MonoBehaviour, IAnomaly
{
    public bool IsActive { get; private set; }

    public void Activate()
    {
        IsActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        IsActive = false;
        gameObject.SetActive(false);
    }

    public void Resolve()
    {
        Deactivate();
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
