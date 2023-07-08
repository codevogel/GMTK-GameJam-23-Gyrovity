using UnityEngine;

public class Fall : MonoBehaviour
{

    private Rigidbody _rb;
    [SerializeField]
    private float speed;

    [SerializeField] private Rotate rotate;

    private bool _frozen = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        Freeze();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_frozen)
        {
            _rb.velocity = Vector3.zero;
            return;
        }
        _rb.velocity = new Vector3(0, - speed, 0);
    }

    public void Freeze()
    {
        _frozen = true;
    }
    
    public void Unfreeze()
    {
        _frozen = false;
    }
}
