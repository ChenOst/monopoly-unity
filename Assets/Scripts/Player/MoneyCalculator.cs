using UnityEngine;

public class MoneyCalculator : MonoBehaviour
{
    private Player _player;
    private int _playersMoney;

    private void Start()
    {
        _player = gameObject.GetComponent<Player>();
        _playersMoney = _player.Money;
    }

    // Check if the player can buy the property
    public bool PlayerCanBuy(int payment)
    {
        return _playersMoney > payment;
    }

    public void Pay(int payment)
    {
        _player.UpdateMoney(-payment);
    }

    public void GetPayment(int payment)
    {
        _player.UpdateMoney(payment);
    }

    public void PayOtherPlayer(Player otherPlayer, int payment)
    {
        otherPlayer.UpdateMoney(payment);
        _player.UpdateMoney(-payment);
    }
}