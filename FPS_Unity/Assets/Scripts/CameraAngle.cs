using UnityEngine;

/// <summary>
/// Controls the angle of the camera, depending on whether or not the character is aiming at the target or if the character is simply moving through 
/// the environment.
/// </summary>
public class CameraAngle : MonoBehaviour
{
    private Transform _startTransform;
    private GameObject _startParent;
    [SerializeField] private Transform _gunTransform;
    private bool _aiming = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       _startTransform = this.transform;
       _startParent = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            _aiming = !_aiming;
        }

        if (_aiming)
        {
            SeeThroughTelescope();
        }
        else
        {
            ReturnToThirdPerson();
        }
    }
    /// <summary>
    /// Switch the camera to be positioned inside the telescope of the gun. 
    /// </summary>
    public void SeeThroughTelescope()
    {
        this.transform.SetParent(_gunTransform);
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.Euler(-90f, -90f, 0f);
    }
    /// <summary>
    /// Switch the camera to be positioned in the third person. 
    /// </summary>
    public void ReturnToThirdPerson()
    {
        this.transform.SetParent(_startParent.transform);
        this.transform.localPosition = new Vector3(-4.0f, 3, 0);
        this.transform.localRotation = Quaternion.Euler(35f, 90f, 0f);

    }
}
