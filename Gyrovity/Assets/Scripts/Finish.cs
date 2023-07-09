using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private Material inactive;
    [SerializeField] private Material active;

    private int _keysNeeded;
    private Collider _collider;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _keysNeeded = GameObject.FindGameObjectsWithTag("Key").Length;
        _collider = GetComponent<Collider>();
        _meshRenderer = GetComponent<MeshRenderer>();

        if (_keysNeeded > 0)
        {
            DisableFinish();
        }
    }

    public void CollectKey()
    {
        if (--_keysNeeded > 0) return;
        EnableFinish();
    }

    private void EnableFinish()
    {
        _collider.enabled = true;
        _meshRenderer.material = active;
    }

    private void DisableFinish()
    {
        _collider.enabled = false;
        _meshRenderer.material = inactive;
    }
}
