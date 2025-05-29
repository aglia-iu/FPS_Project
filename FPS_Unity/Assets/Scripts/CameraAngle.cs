using UnityEngine;

/// <summary>
/// Controls the angle of the camera, depending on whether or not the character is aiming at the target or if the character is simply moving through 
/// the environment.
/// </summary>
public class CameraAngle : MonoBehaviour
{
    private GameObject _startParent; // The parent of this gameObject at the beginning of the game (i.e. the player.)
    [SerializeField] private Transform _gunTransform; // The transform of the gun component that will be the parent of the Camera when switching view.
    private bool _aiming = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       _startParent = this.transform.parent.gameObject; // At the beginning of the program, get the parent
    }

    // Update is called once per frame
    void Update()
    {
        // Toggle between the aim
        if (Input.GetMouseButton(1))
        {
            _aiming = !_aiming;
        }
        // If aiming at the target, switch camera view so that users can see through the telescope.
        if (_aiming)
        {
            SeeThroughTelescope();
        }
        // Else, view from third-person perspective.
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
