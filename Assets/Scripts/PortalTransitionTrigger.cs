using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTransitionTrigger : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    
    [Header("Loop logic")]
    [SerializeField] private AnomalyManager anomalyManager;
    [SerializeField] private AnomalyCounter anomalyCounter;
    
    [Header("Ending")]
    [SerializeField] private string endSceneName = "EndingScene";
    [SerializeField] private float fadeToWhiteTime = 1f;

    private bool busy = false;

    private void OnTriggerEnter(Collider other)
    {
        if (busy) return;
        if (!other.CompareTag(playerTag)) return;

        if (anomalyCounter != null && anomalyCounter.CurrentCount >= anomalyCounter.MaxAnomalies)
        {
            busy = true;
            StartCoroutine(LoadEnding());
            return;
        }
        anomalyManager?.PortalEntered();
    }

    private IEnumerator LoadEnding()
    {
        if(ScreenFader.Instance != null)
            yield return ScreenFader.Instance.FadeTo(Color.white, fadeToWhiteTime);

        SceneManager.LoadScene(endSceneName);
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
