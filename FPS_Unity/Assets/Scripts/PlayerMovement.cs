using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

/// <summary>
/// Controls the movement of the player along the x,z axes along the arena.This script will always be attached to componenets named/tagged as 'Player'.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private float movementX; // The force to apply to the player along the x-axis.
    private float movementZ; // The force to apply to the player along the z-axis.
    private Rigidbody rb; // The RigidBody of the player

    [SerializeField] private float multiplier; // The value by which the character moves forward. 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 value = PlayerForce();
        if (rb)
        {
            this.gameObject.transform.Translate(movementX, 0.0f, movementZ);
        }
        else
        {
            Debug.Log("Unable to acquire the rigidbody value");
        }
        PlayerRotate();
    }

    /// <summary>
    ///  The force to be applied to the player.
    /// </summary>
    /// <returns></returns>
    public Vector3 PlayerForce()
    {
        movementX = UnityEngine.Input.GetAxis("Vertical") * multiplier;
        movementZ = UnityEngine.Input.GetAxis("Horizontal") * multiplier * -1.0f;
        return new Vector3(movementX, 0.0f, movementZ);
    }

    /// <summary>
    /// Rotates the player based on the movement of the player's mouse.
    /// </summary>
    public void PlayerRotate()
    {
        Vector3 mouseMovement = UnityEngine.Input.mousePosition; // Collect the position of the mouse to control the shield.
        this.transform.rotation = Quaternion.Euler(
            0.0f,
            // Linearly interpolates the position of the shield relative to the position of the mouse on the screen.
            LinearInterpolation(-180f, 180f, mouseMovement.x / Screen.width),
            0.0f
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
