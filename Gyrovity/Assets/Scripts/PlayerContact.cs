using System;
using UnityEngine;

public class PlayerContact : MonoBehaviour
{

    [SerializeField]
    private WinLoseStateManager winLoseStateManager;

    [SerializeField]
    private Fall fallController;

    [SerializeField] private Rotate _rotate;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle") || other.collider.CompareTag("Wall"))
        {
            _rotate.Unlock();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            winLoseStateManager.WinGame();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (transform.position.Approx(other.transform.position, .125f))
        {
            transform.position = other.transform.position;
            if (other.CompareTag("Finish"))
            {
                fallController.Freeze();
                winLoseStateManager.WinGame();
            }
            if (other.CompareTag("Death"))
            {
                fallController.Freeze();
                winLoseStateManager.LoseGame();
            }
        }
    }
}
