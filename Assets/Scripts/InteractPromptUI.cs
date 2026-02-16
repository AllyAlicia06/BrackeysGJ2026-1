using TMPro;
using UnityEngine;

public class InteractPromptUI : MonoBehaviour
{
    [SerializeField] private TMP_Text promptText;

    public void Show()
    {
        if (!promptText) return;
        promptText.gameObject.SetActive(true);
    }

    public void Hide()
    {
        if (!promptText) return;
        promptText.gameObject.SetActive(false);
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
