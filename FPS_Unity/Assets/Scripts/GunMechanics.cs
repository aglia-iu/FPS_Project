using UnityEngine;

/// <summary>
/// This script will be applied to the Gun prefab in the project. This script is responsible for detecting when the gun has collided with the player to attach to the player, and shoots bullets out of 
/// the gun.
/// </summary>
public class GunMechanics : MonoBehaviour
{
    public bool shotFromGun; // Whether or not a bullet has been fired from the gun, and is set to false upon completion of the shot
    [SerializeField] private GameObject _bulletPrefab; // The prefab to be instantiated
    private bool _attached; // Whether the gun is attached to a player or not. 
    [SerializeField] float _forceVal;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shotFromGun = false;
        _attached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AttachToPlayer(other);
        }
    }


    /// <summary>
    /// Instantiates a bullet and shoots it from the object
    /// </summary>
    public void ShootBullet()
    {
        if (_attached && !shotFromGun) {
            shotFromGun = true;

            // Create a new bullet and face it in the correct direction.
            GameObject newBullet = Instantiate(_bulletPrefab);
            newBullet.GetComponent<BulletBehavior>().Shoot(_forceVal, this.transform.Find("BulletSpawn").gameObject);
            shotFromGun = false;
        }
        
    }
    /// <summary>
    /// Attaches the gun to the player
    /// </summary>
    /// <param name="player">The player to which the gun must attach.</param>
    public void AttachToPlayer(Collider player)
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.75f);
        this.transform.parent = player.transform;
        this.transform.forward = player.transform.forward * -1;
        _attached = true;
    }
}
