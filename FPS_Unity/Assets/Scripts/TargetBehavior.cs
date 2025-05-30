using UnityEngine;

/// <summary>
/// This object is attached to any object in the scene tagged as a Target Object. The script is responsible for the detection of objects hitting the target, determines
/// whether the object is a bullet of the same color as the target object, and if so, the score will be incremented and the color of the target will change.
/// </summary>
public class TargetBehavior : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private GameObject _playerPos;    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _colorChanger = this.GetComponent<ColorChanger>();

    }

    /// <summary>
    /// This function moves the target to different position around the environment. 
    /// </summary>
    public void MoveTarget()
    {
        //move the target to a random position and have it face the player. 
        this.transform.position = new Vector3(Random.Range(4.0f, -5.0f), -0.7f, Random.Range(-1.0f, -14.0f));
        this.transform.LookAt(_playerPos.transform.position);
    }
}
