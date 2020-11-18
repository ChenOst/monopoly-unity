using UnityEngine;
using UnityEngine.UI;

public class PopMessage : MonoBehaviour
{
    [SerializeField] private GameObject _gameMessage;

    [SerializeField] private Text _gameMessageText;

    [SerializeField] private Text _paymentText;

    public void BuyPropertyMessage(int playersPayment)
    {
        _gameMessage.SetActive(true);
        _gameMessageText.text = "You are the new owner of this property";
        _paymentText.text = $"Lose {playersPayment}$";
    }

    public void CantBuyPropertyMessage()
    {
        _gameMessage.SetActive(true);
        _gameMessageText.text = "You don't have enough money to buy this property";
        _paymentText.text = "";
    }

    public void OtherPlayerPropertyMessage(string otherPlayerName, int playersPayment)
    {
        _gameMessage.SetActive(true);
        _gameMessageText.text = $"You landed on {otherPlayerName}'s property";
        _paymentText.text = $"Lose {playersPayment}$";
    }

    public void RewardMessage(int reward)
    {
        _gameMessage.SetActive(true);
        _gameMessageText.text = "You landed on a Reward!";
        _paymentText.text = $"Won {reward}$";
    }

    public void StartMessage(int reward)
    {
        _gameMessage.SetActive(true);
        _gameMessageText.text = "You landed on the Starting tile!";
        _paymentText.text = $"Won {reward}$";
    }
}