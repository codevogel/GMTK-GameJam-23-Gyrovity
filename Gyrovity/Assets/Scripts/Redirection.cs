using UnityEngine;

public class Redirection : MonoBehaviour
{

    public Transform pointingDir;
    
    private void Awake()
    {
        pointingDir = new GameObject().transform;
        pointingDir.forward = transform.forward;
    }
}
