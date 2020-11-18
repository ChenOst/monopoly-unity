using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private RollTheDice _dice;

    [SerializeField] private Text _playersName;

    [SerializeField] private Text _playersScore;

    private Mover _movement;
    private int _playerStepStatus = 1;

    private int _stepsThisTurn;

    public bool NowPlaying { get; set; }
    public int Money { get; private set; } = 2000;
    public int Location { get; set; } = 0;

    // Start is called before the first frame update
    private void Start()
    {
        _movement = GetComponent<Mover>();
        _playersScore.text = Money.ToString();
        _playersName.text = name.ToUpper();
    }

    // Update is called once per frame
    private void Update()
    {
        _playersScore.text = $"{Money}$";
    }

    /*
     * Each turn contains 3 main steps:
     * 1) Roll the dice - get number of steps
     * 2) Move - move the steps to another tile
     * 3) Check - get the type of the tile and act accordingly
     * If the turn was completed (all 3 steps completed) - return true
     * Else return false
     */
    public bool PlayersTurn()
    {
        if (_playerStepStatus == 1)
        {
            // Roll the dice
            if (_dice.diceWasRolled)
            {
                _playerStepStatus = 0;
                _stepsThisTurn = _dice.rollResult;
                // Set number of steps
                _movement.SetSteps(_stepsThisTurn);
                StartCoroutine(WaitCoroutine(2, 3));
            }
        }
        else if (_playerStepStatus == 2)
        {
            _movement.PlayerCanMove();
            if (_movement.reachedDestination)
            {
                _playerStepStatus = 0;
                StartCoroutine(WaitCoroutine(3, 0.5f));
            }
        }
        else if (_playerStepStatus == 3)
        {
            _playerStepStatus = 0;
            // Check the tile
            GetComponent<CheckLocation>().Check();
            return true;
        }

        return false;
    }

    public void UpdateMoney(int value)
    {
        Money += value;
    }

    private IEnumerator WaitCoroutine(int status, float waitSecond)
    {
        yield return new WaitForSeconds(waitSecond);
        _playerStepStatus = status;
    }

    public void ResetAll()
    {
        // Reset all members of next step
        _movement.Reset();
        _dice.ResetRoll();

        // Player Finished its turn
        NowPlaying = false;
        _playerStepStatus = 1;
    }
}