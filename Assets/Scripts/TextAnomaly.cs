using TMPro;
using UnityEngine;

public class TextAnomaly : MonoBehaviour, IAnomaly
{
    [SerializeField] private TMP_Text targetText;

    [SerializeField] private string normalText = "The Gate";
    [SerializeField] private Color normalColor = Color.white;
    
    [SerializeField] private string anomalyText = "DON'T GO DON'T GO DON'T GO";
    [SerializeField] private Color anomalyColor = Color.darkRed;
    
    public bool IsActive {get; private set;}

    private void Awake()
    {
        ApplyNormal();
    }

    public void Activate()
    {
        IsActive = true;
        ApplyAnomaly();
    }

    public void Deactivate()
    {
        IsActive = false;
        ApplyNormal();
    }

    public void Resolve()
    {
        Deactivate();
    }
    
    private void ApplyNormal()
    {
        if (!targetText) return;
        targetText.text = normalText;
        targetText.color = normalColor;
    }

    private void ApplyAnomaly()
    {
        if (!targetText) return;
        targetText.text = anomalyText;
        targetText.color = anomalyColor;
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
