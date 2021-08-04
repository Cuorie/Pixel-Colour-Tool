using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelTool : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;

    [Header("Input Values")]
    [SerializeField] private Vector2Int _coordinate;
    [SerializeField] private Color _pixelMarkColour;

    [Header("Output Values")]
    [SerializeField] [Tooltip("Colour of the current coordinate")] private Color _colour;
    [Tooltip("RGB 0-1.0")] [SerializeField] private Vector3 _colourValues;


    private Vector2Int _currentCoordinate = Vector2Int.zero;
    private Color _colourSave;
    private bool _canUpdate = true;


    //==========================================
    private void OnValidate()
    {
        if (_canUpdate && _texture != null)
        {
            _canUpdate = false;
            GetColourByCoordinate();
        }
    }

    //==========================================

    private void MarkPixel(int x, int y)
    {
        _colourSave = _texture.GetPixel(x, y);
        _texture.SetPixel(x, y, _pixelMarkColour);
        _texture.Apply();

        _canUpdate = true;
    }

    private void UnmarkPixel(int x, int y)
    {
        _texture.SetPixel(x, y, _colourSave);
        _texture.Apply();
    }

    //==========================================

    private void GetColourByCoordinate()
    {
        UnmarkPixel(_currentCoordinate.x, _currentCoordinate.y);

        _currentCoordinate = _coordinate; //retrieve updated coordinate from inspector

        if (_currentCoordinate.x > _texture.width - 1) //if reached right => go to left
            _currentCoordinate.x = 0;
        else if (_currentCoordinate.x < 0) //if reached left => go to right
            _currentCoordinate.x = _texture.width - 1;

        if (_currentCoordinate.y > _texture.height - 1) //if reached top => go to bottom row
            _currentCoordinate.y = 0;
        else if (_currentCoordinate.y < 0) //if reached bottom => go to top row
            _currentCoordinate.y = _texture.height - 1;

        //update colour values
        _colour = _texture.GetPixel(_currentCoordinate.x, _currentCoordinate.y);
        _colourValues = new Vector3(_colour.r, _colour.g, _colour.b);

        MarkPixel(_currentCoordinate.x, _currentCoordinate.y);

        _coordinate = _currentCoordinate; //update coordinate visible in inspector
    }

    //==========================================

    public void NextPixel() //moves as a scanner --> from left to right and down to up
    {
        UnmarkPixel(_currentCoordinate.x, _currentCoordinate.y);

        if (_currentCoordinate.x == _texture.width - 1) //if reached right => go to left and and one step up
        {
            _currentCoordinate.x = 0;
            _currentCoordinate.y += 1;
        }
        else
            _currentCoordinate.x += 1;

        if (_currentCoordinate.y > _texture.height - 1) //reached end => start over
        {
            _currentCoordinate = Vector2Int.zero;
        }

        //update colour values
        _colour = _texture.GetPixel(_currentCoordinate.x, _currentCoordinate.y);
        _colourValues = new Vector3(_colour.r, _colour.g, _colour.b);

        MarkPixel(_currentCoordinate.x, _currentCoordinate.y);

        _coordinate = _currentCoordinate; //update coordinate visible in inspector
    }

    public void PreviousPixel() //moves as a scanner --> from right to left and up to down
    {
        UnmarkPixel(_currentCoordinate.x, _currentCoordinate.y);

        if (_currentCoordinate.x == 0)  //if reached left => go to right and one step down
        {
            _currentCoordinate.x = _texture.width - 1;
            _currentCoordinate.y -= 1;
        }
        else
            _currentCoordinate.x -= 1;

        if (_currentCoordinate.y < 0) //reached start => go to end
        {
            _currentCoordinate.x = _texture.width - 1;
            _currentCoordinate.y = _texture.height - 1;
        }

        //update colour values
        _colour = _texture.GetPixel(_currentCoordinate.x, _currentCoordinate.y);
        _colourValues = new Vector3(_colour.r, _colour.g, _colour.b);

        MarkPixel(_currentCoordinate.x, _currentCoordinate.y);

        _coordinate = _currentCoordinate; //update coordinate visible in inspector
    }

    //==========================================

    public void NextColumn() //move right
    {
        UnmarkPixel(_currentCoordinate.x, _currentCoordinate.y);

        if (_currentCoordinate.x == _texture.width - 1) //if reached right => go to left
            _currentCoordinate.x = 0;
        else
            _currentCoordinate.x += 1;

        //update colour values
        _colour = _texture.GetPixel(_currentCoordinate.x, _currentCoordinate.y);
        _colourValues = new Vector3(_colour.r, _colour.g, _colour.b);

        MarkPixel(_currentCoordinate.x, _currentCoordinate.y);
        
        _coordinate = _currentCoordinate; //update coordinate visible in inspector
    }

    public void PreviousColumn() //move left
    {
        UnmarkPixel(_currentCoordinate.x, _currentCoordinate.y);

        if (_currentCoordinate.x == 0) //if reached left => go to right
            _currentCoordinate.x = _texture.width - 1;
        else
            _currentCoordinate.x -= 1;

        //update colour values
        _colour = _texture.GetPixel(_currentCoordinate.x, _currentCoordinate.y);
        _colourValues = new Vector3(_colour.r, _colour.g, _colour.b);

        MarkPixel(_currentCoordinate.x, _currentCoordinate.y);

        _coordinate = _currentCoordinate; //update coordinate visible in inspector
    }

    public void NextRow() //move up
    {
        UnmarkPixel(_currentCoordinate.x, _currentCoordinate.y);

        if (_currentCoordinate.y == _texture.height - 1) //if reached top => go to bottom row
            _currentCoordinate.y = 0;
        else
            _currentCoordinate.y += 1;

        //update colour values
        _colour = _texture.GetPixel(_currentCoordinate.x, _currentCoordinate.y);
        _colourValues = new Vector3(_colour.r, _colour.g, _colour.b);

        MarkPixel(_currentCoordinate.x, _currentCoordinate.y);

        _coordinate = _currentCoordinate; //update coordinate visible in inspector
    }

    public void PreviousRow() //move down
    {
        UnmarkPixel(_currentCoordinate.x, _currentCoordinate.y);

        if (_currentCoordinate.y == 0) //if reached bottom => go to top row
            _currentCoordinate.y = _texture.height - 1;
        else
            _currentCoordinate.y -= 1;

        //update colour values
        _colour = _texture.GetPixel(_currentCoordinate.x, _currentCoordinate.y);
        _colourValues = new Vector3(_colour.r, _colour.g, _colour.b);

        MarkPixel(_currentCoordinate.x, _currentCoordinate.y);

        _coordinate = _currentCoordinate; //update coordinate visible in inspector
    }

    //==========================================

    public int GetTextureWidth()
    {
        if (_texture == null)
            return 0;
        else
            return _texture.width;
    }

    public int GetTextureHeight()
    {
        if (_texture == null)
            return 0;
        else
            return _texture.height;
    }
}
