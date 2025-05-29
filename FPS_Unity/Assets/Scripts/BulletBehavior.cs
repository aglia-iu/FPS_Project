using UnityEngine;

/// <summary>
/// This script is attached to every new object tagged as a 'bullet' that is instantiated in the scene. This script detects the collision of the bullet in the scene, 
/// and controls the movement of the bullet by adding a force to the RigidBody component, and detects the movement of the object in the environment.
/// </summary>
public class BulletBehavior : MonoBehaviour
{
    public bool _shot;
    public bool _targetHit;
    [SerializeField] private CalculationsTimeScore _score;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _shot = false;
        _targetHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // Did the bullet collide with a wall?
        if(other.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        // Did the bullet collide with a target?
        if (other.tag == "Target")
        {
            if(this.GetComponent<MeshRenderer>().material.name == (other.GetComponent<MeshRenderer>().material.name))
            {
                Debug.Log("bruh");
                _score.IncrementScore();
            } 
            _targetHit=true;
        }
    }

    /// <summary>
    /// Shoots the bullet out with the appropriate amount of force
    /// </summary>
    /// <param name="_forceVal"> The amount of force to apply to the bullet to shoot out of.</param>
    /// <param name="_bulletSpawnPoint"> The position from which bullets populate.</param>
    public void Shoot(float _forceVal, GameObject _bulletSpawnPoint) {

        this.transform.position = _bulletSpawnPoint.transform.position;
        this.transform.forward = _bulletSpawnPoint.transform.forward;

        // Apply force to the bullet to shoot it out of the object
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward * _forceVal);   
        _shot = true;
    }

    
}
