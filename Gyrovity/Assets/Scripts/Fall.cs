using UnityEngine;

public class Fall : MonoBehaviour
{

    private Rigidbody _rb;
    [SerializeField]
    private float speed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = new Vector3(0, - speed, 0);
    }
}
