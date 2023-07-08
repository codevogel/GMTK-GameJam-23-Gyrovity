using UnityEngine;

public class PlayerContact : MonoBehaviour
{

    [SerializeField]
    private WinLoseStateManager winLoseStateManager;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Death"))
        {
            winLoseStateManager.LoseGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            winLoseStateManager.WinGame();
        }
    }
}
