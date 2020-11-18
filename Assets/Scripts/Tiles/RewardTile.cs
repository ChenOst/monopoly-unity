using UnityEngine;

public class RewardTile : MonoBehaviour
{
    [SerializeField] [Range(50, 500)] private int _baseReward = 50;

    public int CalculateReward()
    {
        var number1Prob = 0.5;
        var number2Prob = number1Prob + 0.1;
        var number3Prob = number2Prob + 0.1;
        var number4Prob = number3Prob + 0.1;
        var number5Prob = number4Prob + 0.1;
        var number6Prob = number5Prob + 0.05;

        double randomNumber = Random.value;

        int selectedReward;

        if (randomNumber < number1Prob)
        {
            selectedReward = _baseReward;
        }
        else if (randomNumber >= number1Prob && randomNumber < number2Prob)
        {
            selectedReward = _baseReward - (int) (_baseReward * 0.2);
        }
        else if (randomNumber >= number2Prob && randomNumber < number3Prob)
        {
            selectedReward = _baseReward + (int) (_baseReward * 0.2);
        }
        else if (randomNumber >= number3Prob && randomNumber < number4Prob)
        {
            selectedReward = _baseReward - (int) (_baseReward * 0.4);
            ;
        }
        else if (randomNumber >= number4Prob && randomNumber < number5Prob)
        {
            selectedReward = _baseReward + (int) (_baseReward * 0.4);
            ;
        }
        else if (randomNumber >= number5Prob && randomNumber < number6Prob)
        {
            selectedReward = _baseReward - (int) (_baseReward * 0.8);
        }
        else
        {
            selectedReward = _baseReward + (int) (_baseReward * 0.8);
        }

        return selectedReward;
    }
}