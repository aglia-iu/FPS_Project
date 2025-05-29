using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;



/// <summary>
/// This script is used to modify UI Canvas elements in the environment given certain . 
/// </summary>
public class UICanvas : MonoBehaviour
{
    //[SerializeField] private int _score;
    //private float _totalTime = 60.0f;

    [SerializeField] private TMP_Text _scoreUIElement;
    [SerializeField] private TMP_Text _timeUIElement;

    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _instructionsPanel;

    [SerializeField] private GameObject _colorPalettePanel;
    [SerializeField] private GameObject _timePanel;
    [SerializeField] private Calculations _calculations;
    private bool _start;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      _start = false;
      _calculations = this.GetComponent<Calculations>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_start)
        {
            TimeDisplay();
            DisplayScore();
            if (_calculations._totalTime <= 0 && !(_calculations.GetScore() > 15))
            {
                LoseScreen();
            }
            if (_calculations._totalTime <= 0 && (_calculations.GetScore() > 15))
            {
                WinScreen();
            }
        }
    }
    /// <summary>
    ///  Displays the current time on the corresponding UI Panel.
    /// </summary>
    private void TimeDisplay()
    {
        _timeUIElement.text = "Time Left: " + _calculations._totalTime.ToString();
    }
    
    /// <summary>
    /// Displays the current score on the corresponding UI Panel.
    /// </summary>
    public void DisplayScore()
    {
        _scoreUIElement.text = "Score: " + _calculations.GetScore().ToString();
    }
    /// <summary>
    /// The Lose Screen that is activated when the character loses the game. The ColorPalette and Time Panel are deactivated.
    /// </summary>
    public void LoseScreen()
    {
        _losePanel.SetActive(true);
        _colorPalettePanel.SetActive(false);
        _timePanel.SetActive(false);
    }
    /// <summary>
    /// The Win Screen that is activated when the character loses the game. The ColorPalette and Time Panel are deactivated. 
    /// </summary>
    public void WinScreen()
    {
        _winPanel.SetActive(true);
        _colorPalettePanel.SetActive(false);
        _timePanel.SetActive(false);
    }

    /// <summary>
    /// The Color Palette tab that is activated when the character acquires a gun. 
    /// </summary>
    public void ColorPaletteScreen()
    {
        _colorPalettePanel.SetActive(true);
    }
    /// <summary>
    /// Activates the Instruction Panel at the beginning of the game. 
    /// </summary>
    public void InstructionalPanel()
    {
        _instructionsPanel.SetActive(true);
    }
    /// <summary>
    /// Start the game and the counter.
    /// </summary>
    public void StartGame()
    {
        _start = true;
        _instructionsPanel.SetActive(false);
        _timePanel.SetActive(true);
    }
}

