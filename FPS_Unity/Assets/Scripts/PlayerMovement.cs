using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

/// <summary>
/// Controls the movement of the player along the x,z axes along the arena.This script will always be attached to componenets named/tagged as 
/// 'Player'.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private float _movementX; // The force to apply to the player along the x-axis.
    private float _movementZ; // The force to apply to the player along the z-axis.
    private Vector3 _startPosition; // The starting positon of the character.

    [SerializeField] private float _multiplier; // The value by which the character moves forward. 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the position of this transform over time. 
        Vector3 pos = this.transform.localPosition;
        // The axes along which the user can move. 
        _movementX = UnityEngine.Input.GetAxis("Vertical");
        _movementZ = UnityEngine.Input.GetAxis("Horizontal") * -1.0f;
        // Setting the rigidbody velocity to zero to prevent drift. 
        this.GetComponent<Rigidbody>().linearVelocity = new Vector3(0f, this.GetComponent<Rigidbody>().linearVelocity.y, 0f);

        if (
            (pos.x > -18.0f && pos.x < 18.0f) 
            &&
            (pos.z > -38.5f && pos.z < -1.41f))
        {
            // If character is within these bounds, the character can move freely. 
            this.gameObject.transform.Translate(_movementX * _multiplier, 0.0f, _movementZ * _multiplier);
            
        }
        // Otherwise, the position of the character gets reset. 
        else {
            this.transform.position = _startPosition;
            Debug.Log($"pos x: {pos.x}, pos z: {pos.z}");
        }
       
        PlayerRotate();
    }

    /// <summary>
    ///  The force to be applied to the player.
    /// </summary>
    /// <returns> A new Vector3 Value representing the direction of movement of the object</returns>
    public Vector3 PlayerForce()
    {
        _movementX = UnityEngine.Input.GetAxis("Vertical") * _multiplier;
        _movementZ = UnityEngine.Input.GetAxis("Horizontal") * _multiplier * -1.0f;
        return new Vector3(_movementX, 0.0f, _movementZ);
    }

    /// <summary>
    /// Rotates the player based on the movement of the player's mouse.
    /// </summary>
    public void PlayerRotate()
    {
        Vector3 mouseMovement = UnityEngine.Input.mousePosition; // Collect the position of the mouse to control the shield.
        this.transform.rotation = Quaternion.Euler(
            0,
            // Linearly interpolates the position of the shield relative to the position of the mouse on the screen.
            LinearInterpolation(-180f, 180f, mouseMovement.x / Screen.width),
            0
        );
        
    }
    /// <summary>
    /// This function linearly interpolates between two objects from a starting to an ending point based on a set amount of time (also known as val.)
    /// </summary>
    /// <param name="start">The starting point of the linear interpolation</param>
    /// <param name="end">The ending point of the linear interpolation</param>
    /// <param name="val">The time required for the linear interpolation.</param>
    /// <returns>a float that is representative of the linear interpolation</returns>
    public float LinearInterpolation(float start, float end, float val)
    {
        return ((end - start) * val) + start;
    }
}
