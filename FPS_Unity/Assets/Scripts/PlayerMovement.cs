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
            //rb.AddForce(value);
        }
        else
        {
            Debug.Log("Unable to acquire the rigidbody value");
        }
    }

    /// <summary>
    ///  The force to be applied to the player.
    /// </summary>
    /// <returns></returns>
    public Vector3 PlayerForce()
    {
        movementX = UnityEngine.Input.GetAxis("Vertical") * multiplier;
        movementZ = UnityEngine.Input.GetAxis("Horizontal") * multiplier * -1.0f;
        //Debug.Log($"{movementX} {movementZ}");
        return new Vector3(movementX, 0.0f, movementZ);
    }
}
