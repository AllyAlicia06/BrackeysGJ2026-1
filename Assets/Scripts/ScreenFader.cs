using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public static ScreenFader Instance { get; private set; }

    private Image overlayImage;
    private CanvasGroup canvasGroup;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(transform.root.gameObject);
        overlayImage = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();

        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = true;
    }

    public Coroutine FadeTo(Color color, float duration)
    {
        overlayImage.color = color;
        return StartCoroutine(Fade(1f,duration));
    }

    public Coroutine FadeFrom(float duration)
    {
        return StartCoroutine(Fade(0f, duration));
    }

    private IEnumerator Fade(float target, float duration)
    {
        float start = canvasGroup.alpha;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, target, t / duration);
            yield return null;
        }
        canvasGroup.alpha = target;
    }

    public void SetInstant(Color color, float alpha)
    {
        overlayImage.color = color;
        canvasGroup.alpha = alpha;
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
