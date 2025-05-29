using UnityEngine;

/// <summary>
/// Changes the color of the object to which it is attached randomly, and a built in checker to check if an object being passed in has the same material color as the 
/// material attached to this object.
/// </summary>
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material _materialRed; // The red material to be applied to the object.
    [SerializeField] private Material _materialBlue; // The blue material to be applied to the object.
    [SerializeField] private Material _materialYellow; // The yellow material to be applied to the object.

    private float _randomVal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if (this.gameObject.CompareTag("Target"))
        {
            _randomVal = Random.value;
            ChangeColor();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    /// <summary>
    /// Changes the color of the object to which it is attached randomly, and a built in checker to check if an object being passed in has the same material color as 
    /// the material attached to this object.
    /// </summary>
    public void ChangeColor()
    {
        _randomVal = Random.value;

        if (_randomVal < 0.33f)
        {
            this.GetComponent<MeshRenderer>().material = _materialRed;

        }else if (_randomVal > 0.34 && _randomVal < 0.66f)
        {
            this.GetComponent<MeshRenderer>().material = _materialBlue;
        } else if (_randomVal < 1.0f &&  _randomVal > 0.67f)
        {
            this.GetComponent<MeshRenderer>().material = _materialYellow;
        }
    }

    /// <summary>
    /// Change the color of the material attached to this object to yellow, based on the button clicked by the user. 
    /// </summary>
    public void ChangeToYellow(GameObject _obj)
    {
        _obj.GetComponent<MeshRenderer>().material = _materialYellow;
    }

    /// <summary>
    /// Change the color of the material attached to this object to red, based on the button clicked by the user. 
    /// </summary>
    public void ChangeToRed(GameObject _obj)
    {
        _obj.GetComponent<MeshRenderer>().material = _materialRed;
    }

    /// <summary>
    /// Change the color of the material attached to this object to blue, based on the button clicked by the user. 
    /// </summary>
    public void ChangeToBlue(GameObject _obj)
    {
        _obj.GetComponent<MeshRenderer>().material = _materialBlue;
    }
}
