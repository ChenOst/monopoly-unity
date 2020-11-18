using UnityEngine;

public class PropertyTile : MonoBehaviour
{
    [SerializeField] private Sprite[] _images;

    [SerializeField] private SpriteRenderer _myImage;

    [SerializeField] [Range(200, 1000)] private int _payment = 500;

    private string _owner = "";

    public void SetOwner(string name)
    {
        _owner = name;
        if (name.Equals("Player 1"))
            _myImage.sprite = _images[0];
        else
            _myImage.sprite = _images[1];
    }

    public string GetOwner()
    {
        return _owner;
    }

    public int GetPayment()
    {
        return _payment;
    }

    /*
    public string owner
    {
        get
        {
            return _owner;
        }
        set
        {
            _owner = name;
            if (name.Equals("Player 1"))
            {
                _myImage.sprite = _images[0];
            }
            else
            {
                _myImage.sprite = _images[1];
            }
        }
    }
    public int payment { get; set; }*/
}