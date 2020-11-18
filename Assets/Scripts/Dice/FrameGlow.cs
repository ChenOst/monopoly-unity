using UnityEngine;

public class FrameGlow : MonoBehaviour
{
    [SerializeField] private RollTheDice _dice;

    private Animator _animation;
    private SpriteRenderer _frameSprite;

    // Start is called before the first frame update
    private void Start()
    {
        _animation = GetComponent<Animator>();
        _frameSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        var canRoll = !_dice.diceWasRolled;

        // If one of the players can roll - glow
        if (canRoll)
        {
            _animation.enabled = true;
            _frameSprite.enabled = true;
        }
        else
        {
            _animation.enabled = false;
            _frameSprite.enabled = false;
        }
    }
}