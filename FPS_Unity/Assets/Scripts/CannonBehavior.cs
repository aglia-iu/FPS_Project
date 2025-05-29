using UnityEngine;

/// <summary>
/// This script controls the movement of each cannon so that they face the player at each point in time, and ensuring that each player can move around in the 
/// environment. 
/// </summary>
public class CannonBehavior : MonoBehaviour
{
    [SerializeField] private Transform playerPosition; // The position of the player at any point in time.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(playerPosition == null)
        {
            Debug.Log("Unable to acquire cannon.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(playerPosition);
    }
}
