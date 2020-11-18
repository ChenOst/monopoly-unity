using System.Collections;
using UnityEngine;

public class RollAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;

    [SerializeField] private RollTheDice _dice;

    [SerializeField] private SpriteRenderer _diceNumber;

    [SerializeField] private AudioSource _rollAudio;

    private Animator _anim;
    private int _rollResult;

    // Start is called before the first frame update
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Playes the animation after one of the players roll the dice
    public void PlayAnimation()
    {
        _anim.enabled = true;
        _rollAudio.enabled = true;
        _rollResult = _dice.rollResult;
        StartCoroutine(StopAnimation());
    }

    // Stops the animation after 5 seconds
    private IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(3);
        SetSpriteResult(_rollResult);
        _anim.enabled = false;
        _rollAudio.enabled = false;
    }

    // Set random number sprite
    private void SetRandomSpriteNumber()
    {
        var index = Random.Range(1, 7);
        _diceNumber.sprite = _sprites[index - 1];
    }

    // Set result number sprite
    private void SetSpriteResult(int index)
    {
        _diceNumber.sprite = _sprites[index - 1];
    }
}