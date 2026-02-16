using StarterAssets;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private AnomalyManager anomalyManager;
    [SerializeField] private InteractPromptUI interactPromptUI;
    [SerializeField] private StarterAssetsInputs input;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask interactLayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anomalyManager == null || interactPromptUI == null) return;

        var current = anomalyManager.Current;
        if (current == null || !current.IsActive)
        {
            interactPromptUI.Hide();
            return;
        }

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance, interactLayer, QueryTriggerInteraction.Collide))
        {
            var hitAnomaly = hit.collider.GetComponentInParent<IAnomaly>();
            if (hitAnomaly != null && ReferenceEquals(hitAnomaly, current))
            {
                interactPromptUI.Show();

                if (input != null && input.interact)
                {
                    anomalyManager.ResolveCurrentAnomaly();
                    input.interact = false;
                }

                return;
            }
        }
        interactPromptUI.Hide();
    }
}
