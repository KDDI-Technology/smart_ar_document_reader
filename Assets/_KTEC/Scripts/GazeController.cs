using UnityEngine;

public class GazeController : MonoBehaviour
{
    [Header("RayCast設定")]
    [SerializeField] private Transform head;
    [SerializeField] private float maxDistance = 10f;
    
    [Header("デバッグ")]
    [SerializeField] private bool showDebugRay = true;
    
    private ArrowButton currentGazedButton = null;
    
    void Update()
    {
        Gaze();
    }
    
    private void Gaze()
    {
        Ray ray = new Ray(head.position, head.forward);
        RaycastHit hit;
        
        if (showDebugRay)
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red);
        }
        
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            ArrowButton hitButton = hit.collider.GetComponent<ArrowButton>();
            
            if (hitButton != null)
            {
                if (currentGazedButton != hitButton)
                {
                    if (currentGazedButton != null)
                    {
                        currentGazedButton.OnGazeEnd();
                    }
                    
                    currentGazedButton = hitButton;
                    currentGazedButton.OnGazeStart();
                }
            }
            else
            {
                if (currentGazedButton != null)
                {
                    currentGazedButton.OnGazeEnd();
                    currentGazedButton = null;
                }
            }
        }
        else
        {
            if (currentGazedButton != null)
            {
                currentGazedButton.OnGazeEnd();
                currentGazedButton = null;
            }
        }
    }
}
