using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// This script is attached to every new object tagged as a 'bullet' that is instantiated in the scene. This script detects the collision of the 
/// bullet in the scene, and controls the movement of the bullet by adding a force to the RigidBody component, and detects the movement of the object in the environment.
/// </summary>
public class BulletBehavior : MonoBehaviour
{
    public bool _shot; // Whether or not this bullet has been fired.
    public bool _targetHit; // Whether or not the target has been hit yet.
    [SerializeField] private Calculations _score; //The players current score. 
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _shot = false;
        _targetHit = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Did the bullet collide with a wall? If so, destroy the bullet
        if(other.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        // Did the bullet collide with a target? If so, check to see if the color of the bullet matches the color of the target, and change the score as needed.
        if (other.tag == "Target")
        {
            if(this.GetComponent<MeshRenderer>().material.name == (other.GetComponent<MeshRenderer>().material.name))
            {
                _score.IncrementScore();
            } 
            else
            {
                _score.DecrementScore();
            }
            // Now, the bullet has successfully hit the target.
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
