using UnityEngine;

/// <summary>
/// Controls the movement of the player along the x,y,z axes along the arena.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private float movementX; // The force to apply to the player along the x-axis.
    private float movementY; // The force to apply to the player along the y-axis.
    private float movementZ; // The force to apply to the player along the z-axis.

    [SerializeField] private float multiplier; // The value by which the character moves forward. 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    ///  The force to be applied to the player.
    /// </summary>
    /// <returns></returns>
    private float PlayerForce()
    {
        return 0.0f;
    }
}
