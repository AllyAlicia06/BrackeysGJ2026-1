using UnityEngine;

public class MainSceneBootstrap : MonoBehaviour
{
    [SerializeField] private AnomalyCounter counter;
    [SerializeField] private int startCount = 0;
    [SerializeField] private bool lockCursor = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(counter != null)
            counter.ResetToZero();

        if (lockCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
