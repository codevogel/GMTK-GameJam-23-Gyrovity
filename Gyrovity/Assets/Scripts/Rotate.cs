using System.Collections;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] [Range(0,1)]
    private float lerpSpeed = .25f;

    private Transform _target;

    [SerializeField]
    private Fall fallController;

    private bool _canRotate = true;

    private Redirection _previousRedirect = null;

    private void Awake()
    {
        _target = new GameObject().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_canRotate)
        {
            var rightDown = Input.GetKeyDown(KeyCode.D);
            var leftDown = Input.GetKeyDown(KeyCode.A);
            var upDown = Input.GetKeyDown(KeyCode.W);
            var downDown = Input.GetKeyDown(KeyCode.S);

            if (rightDown || leftDown || upDown || downDown)
            {
                _target.Rotate(new Vector3(rightDown ? 90 : leftDown ? -90 : 0, 0, upDown ? 90 : downDown ? -90 : 0), Space.World);    
                Lock();
                fallController.Freeze();
                StartCoroutine(UnfreezeAfterDelay());
            }
        }
        transform.rotation = Quaternion.LerpUnclamped(transform.rotation, _target.rotation, lerpSpeed);
    }

    private IEnumerator UnfreezeAfterDelay(Redirection redirection = null)
    {
        // Set the redirection
        _previousRedirect = redirection;
        while (!_target.rotation.eulerAngles.Approx(transform.rotation.eulerAngles, .125f))
        {
            yield return null;
        }
        fallController.transform.position += new Vector3(0, .025f, 0);
        fallController.Unfreeze();
    }

    public void Lock()
    {
        _canRotate = false;
    }

    public void Unlock()
    {
        _canRotate = true;
        
        // It's safe to re-enable the collider now that we're sure we're no longer in it.
        if (_previousRedirect != null)
        {
            _previousRedirect.GetComponent<Collider>().enabled = true;
        }
    }

    public void RotateTowards(Redirection redirection)
    {
        _target.up = redirection.pointingDir.forward;
        
        // Disable the redirection collider
        redirection.GetComponent<Collider>().enabled = false;
        fallController.Freeze();
        
        // Pass the redirection so we can later re-enable the collider
        StartCoroutine(UnfreezeAfterDelay(redirection));
    }
}
