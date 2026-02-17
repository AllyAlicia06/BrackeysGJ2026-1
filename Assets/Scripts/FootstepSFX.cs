using StarterAssets;
using UnityEngine;

public class FootstepSFX : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip footstepClip;

    [Header("Timing")] 
    [SerializeField] private float walkStepInterval = 0.5f;
    [SerializeField] private float sprintStepInterval = 0.35f;
    
    private CharacterController characterController;
    private StarterAssetsInputs  inputs;
    private float timer;
    private bool wasMoving;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        inputs = GetComponent<StarterAssetsInputs>();
        
        if(audioSource == null) audioSource  = GetComponent<AudioSource>();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource == null || footstepClip == null) return;
        if (inputs == null) return;
        
        bool grounded = characterController.isGrounded;
        bool movingInput = inputs.move.sqrMagnitude > 0.2f;

        if (!grounded || !movingInput)
        {
            timer = 0f;
            wasMoving = false;
            return;
        }
        
        float interval = (inputs != null && inputs.sprint) ? sprintStepInterval : walkStepInterval;

        if (!wasMoving)
        {
            PlayStepSound();
            timer = 0f;
            wasMoving = true;
            return;
        }
        
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            PlayStepSound();
        }
    }

    private void PlayStepSound()
    {
        audioSource.PlayOneShot(footstepClip);
    }
}
