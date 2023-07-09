using System;
using UnityEngine;

public class PlayerContact : MonoBehaviour
{

    [SerializeField]
    private WinLoseStateManager winLoseStateManager;

    [SerializeField]
    private Fall fallController;

    [SerializeField] private Rotate _rotate;

    private Finish _finish;
    
    private void Awake()
    {
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
    }

    private void OnCollisionEnter(Collision other)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, .625f))
        {
            if (hit.collider.CompareTag("Obstacle") || hit.collider.CompareTag("Wall"))
            {
                _rotate.Unlock();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            _finish.CollectKey();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Finish"))
        {
            winLoseStateManager.WinGame();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (transform.position.Approx(other.transform.position, .125f))
        {
            if (!other.CompareTag("Key"))
            {
                transform.position = other.transform.position;
                if (other.CompareTag("Redirection"))
                {
                    _rotate.RotateTowards(other.GetComponent<Redirection>());
                }
            }
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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Redirection"))
        {
            other.GetComponent<Collider>().enabled = true;
            Debug.Log("enabled!");
        }
    }
}
