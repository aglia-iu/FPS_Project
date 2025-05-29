using UnityEngine;

/// <summary>
/// This script will be applied to the Gun prefab in the project. This script is responsible for detecting when the gun has collided with the player to attach to the player, and shoots 
/// bullets out of the gun.
/// </summary>
public class GunMechanics : MonoBehaviour
{
    public bool shotFromGun; // Whether or not a bullet has been fired from the gun, and is set to false upon completion of the shot
    private string _colorname; // The color to which we set the bullets.
    private bool _attached; // Whether the gun is attached to a player or not. 

    [SerializeField] private GameObject _bulletPrefab; // The prefab to be instantiated
    [SerializeField] private float _forceVal; // The force value applied to the bullet
    [SerializeField] private ColorChanger _colorChanger; // The ColorChanger component on this object.
    [SerializeField] private UICanvas _uicanvas; // The UI Canvas component on this object.
                                                 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shotFromGun = false; 
        _attached = false;
    }

    // Update is called once per frame
    void Update()
    {
        // On left-click, shoot bullet forward.
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player collides with the gun, attach the gun to the player. 
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
        // If the player is holding the gun and it has been a second since they last fired a shot.
        if (_attached && !shotFromGun) {
            shotFromGun = true;

            // Create a new bullet and face it in the correct direction.
            GameObject newBullet = Instantiate(_bulletPrefab);
            switch (_colorname)
            {
                case "Red":
                    _colorChanger.ChangeToRed(newBullet);
                    break;

                case "Blue":
                    _colorChanger.ChangeToBlue(newBullet);
                    break;

                case "Yellow":
                    _colorChanger.ChangeToYellow(newBullet);
                    break;
            }
            // Apply force to bullet to shoot the bullet in the forward direction.
            newBullet.GetComponent<BulletBehavior>().Shoot(_forceVal, this.transform.Find("BulletSpawn").gameObject);
            shotFromGun = false;
        }
        
    }
    /// <summary>
    /// Attaches the gun to the player.
    /// </summary>
    /// <param name="player">The player to which the gun must attach.</param>
    public void AttachToPlayer(Collider player)
    {
        // Attach and orient gun
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.75f);
        this.transform.parent = player.transform;
        this.transform.forward = player.transform.forward * -1;
        // Enable the UI Color Palette Panel
        _uicanvas.ColorPaletteScreen();
        _attached = true;
    }

    /// <summary>
    /// The color to which the bullet prefab will be instantiated with. Used by buttons (on Canvas) to select objects. 
    /// </summary>
    /// <param name="colorName">The color of the object to which we want to change.</param>
    public void ChangeColor(string colorName)
    {
        _colorname = colorName;
    }
}
