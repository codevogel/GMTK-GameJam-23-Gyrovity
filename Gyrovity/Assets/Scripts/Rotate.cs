using System;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField]
    private float lerpSpeed = 25;

    private Transform _target;

    public bool _flipRightLeft = false;
    public bool _flipUpDown = false;

    private void Awake()
    {
        _target = new GameObject().transform;
    }

    // Update is called once per frame
    void Update()
    {
        var rightDown = Input.GetKeyDown(KeyCode.D);
        var leftDown = Input.GetKeyDown(KeyCode.A);
        var upDown = Input.GetKeyDown(KeyCode.W);
        var downDown = Input.GetKeyDown(KeyCode.S);

        _target.Rotate(new Vector3(rightDown ? 90 : leftDown ? -90 : 0, 0, upDown ? 90 : downDown ? -90 : 0), Space.World);
        
        transform.rotation = Quaternion.LerpUnclamped(transform.rotation, _target.rotation, .25f);
    }
    
}
