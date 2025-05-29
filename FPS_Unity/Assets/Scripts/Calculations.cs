using UnityEngine;


/// <summary>
/// This script is used to calculate the time and score which will be used to update the UI in the environment at each point. 
/// </summary>
public class Calculations : MonoBehaviour
{
    [SerializeField] private int _score;
    public float _totalTime = 60.0f;

    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeCounter();
    }
    /// <summary>
    /// The goal of this counter is to keep track of the deltaTime and to update the UI Element representing the time on every FixedUpdate().
    /// </summary>
    /// <returns>a float representing the amount of time left. </returns>
    private float TimeCounter()
    {
        _totalTime -= Time.deltaTime;
        return _totalTime;
    }
    /// <summary>
    /// Increment the score of the player by one. 
    /// </summary>
    public void IncrementScore()
    {
        _score++;
    }

    /// <summary>
    /// Decrement the score of the player by one. 
    /// </summary>
    public void DecrementScore()
    {
        _score--;
    }
    /// <summary>
    /// Get the score of the player. 
    /// </summary>
    /// <returns> An integer value of the current score.</returns>
    public int GetScore()
    {
        return _score;
    }

}
