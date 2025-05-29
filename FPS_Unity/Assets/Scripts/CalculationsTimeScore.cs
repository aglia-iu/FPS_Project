using Unity.VisualScripting;
using UnityEngine;
using TMPro;

/// <summary>
/// This script is used to calculate the time and score which will be used in separate script to update the UI in teh environment at each point. 
/// </summary>
public class CalculationsTimeScore : MonoBehaviour
{
    [SerializeField] private int _score;
    private float _totalTime = 60.0f;

    [SerializeField] TMP_Text _scoreUIElement;
    [SerializeField] TMP_Text _timeUIElement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeCounter();
        DisplayScore();
    }
    /// <summary>
    /// The goal of this counter is to keep track of the deltaTime and to update the UI Element representing the time on every FixedUpdate().
    /// </summary>
    /// <returns>a float representing the amount of time left. </returns>
    private float TimeCounter()
    {
       _totalTime -= Time.deltaTime;
        _timeUIElement.text = "Time Left: " + _totalTime.ToString();
        return _totalTime;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int IncrementScore()
    {
        _score++;
        return _score;
    }
    /// <summary>
    /// 
    /// </summary>
    public void DisplayScore()
    {
        _scoreUIElement.text = "Score: " + _score.ToString();
    }

}
