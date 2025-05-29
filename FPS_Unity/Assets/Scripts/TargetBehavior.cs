using UnityEngine;

/// <summary>
/// This object is attached to any object in the scene tagged as a Target Object. The script is responsible for the detection of objects hitting the target, determines
/// whether the object is a bullet of the same color as the target object, and if so, the score will be incremented and the color of the target will change.
/// </summary>
public class TargetBehavior : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private GameObject playerPos;
    private Transform _prevTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _colorChanger = this.GetComponent<ColorChanger>();

        if ( _colorChanger != null)
        {
            Debug.Log("Acquired ColorChanger!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Did the object hit the Target?
        // If it is a bullet -
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Caught a bullet!");
            if (other.GetComponent<BulletBehavior>()._targetHit)
            {
                _colorChanger.ChangeColor();
            }
            MoveTarget();
        }
    }
    /// <summary>
    /// This function moves the target to different position around the environment. 
    /// </summary>
    void MoveTarget()
    {
        _prevTransform = this.transform;
        this.transform.position = new Vector3(Random.Range(4.0f, -5.0f), -0.7f, Random.Range(-1.0f, -14.0f));
        this.transform.LookAt(playerPos.transform.position);
    }
}
