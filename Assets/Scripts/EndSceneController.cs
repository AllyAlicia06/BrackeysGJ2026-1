using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class EndSceneController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private CanvasGroup messageGroup;
    [SerializeField] private GameObject menuObject;

    [Header("Timing")] 
    [SerializeField] private float fadeFromWhiteTime = 1f;
    [SerializeField] private float messageFadeInTime = 0.6f;
    [SerializeField] private float messageHoldSeconds = 2.5f;
    [SerializeField] private float messageFadeOutTime = 0.6f;
    [SerializeField] private float fadeToBlackTime = 1.2f;

    [Header("Scenes")] 
    [SerializeField] private string mainSceneName = "GameplayScene";

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonClickClip;
    [SerializeField] private float buttonDelay = 0.1f;

    private bool _clicked;
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    private IEnumerator Start()
    {
        if(menuObject) menuObject.SetActive(false);

        if (messageGroup != null)
        {
            messageGroup.alpha = 0f;
            messageGroup.gameObject.SetActive(true);
        }

        if (ScreenFader.Instance != null)
            yield return ScreenFader.Instance.FadeFrom(fadeFromWhiteTime);
        
        if(messageGroup != null)
            yield return FadeCanvasGroup(messageGroup, 1f, messageFadeInTime);
        
        yield return new WaitForSeconds(messageHoldSeconds);

        if (messageGroup != null)
        {
            yield return FadeCanvasGroup(messageGroup, 0f, messageFadeOutTime);
            messageGroup.gameObject.SetActive(false);
        }

        if (ScreenFader.Instance != null)
            yield return ScreenFader.Instance.FadeTo(Color.black, fadeToBlackTime);
        
        if(menuObject) menuObject.SetActive(true);
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float target, float duration)
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
    
    /*public void Restart()
    {
        if(ScreenFader.Instance != null)
            ScreenFader.Instance.SetInstant(Color.black, 0f);
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        SceneManager.LoadScene(mainSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }*/

    public void Restart()
    {
        if (_clicked) return;
        _clicked = true;
        StartCoroutine(RestartRoutine());
    }

    private IEnumerator RestartRoutine()
    {
        PlayButtonClick();
        
        yield return new WaitForSeconds(buttonDelay);
        
        if(ScreenFader.Instance != null)
            ScreenFader.Instance.SetInstant(Color.black, 0f);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        SceneManager.LoadScene(mainSceneName);
    }

    public void Quit()
    {
        if (_clicked) return;
        _clicked = true;
        StartCoroutine(QuitRoutine());
    }

    private IEnumerator QuitRoutine()
    {
        PlayButtonClick();
        
        yield return new WaitForSeconds(buttonDelay);
        
        Application.Quit();
    }
    
    private void PlayButtonClick()
    {
        if(audioSource != null && buttonClickClip != null)
            audioSource.PlayOneShot(buttonClickClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
