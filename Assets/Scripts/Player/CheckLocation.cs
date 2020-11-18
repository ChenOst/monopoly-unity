using UnityEngine;

public class CheckLocation : MonoBehaviour
{
    [SerializeField] private SpawnTiles _spawn;

    [SerializeField] private GameObject _gameManager;

    private PopMessage _message;
    private MoneyCalculator _calculator;
    private GameObject[] _tiles;

    public void Check()
    {
        var location = GetComponent<Player>().Location;
        _tiles = _spawn.GetTiles();
        _message = _gameManager.GetComponent<PopMessage>();
        _calculator = GetComponent<MoneyCalculator>();

        if (_tiles[location].tag == "Property")
        {
            var owner = _tiles[location].GetComponent<PropertyTile>().GetOwner();
            var payment = _tiles[location].GetComponent<PropertyTile>().GetPayment();

            if (owner.Equals(name))
            {
            }
            // Dont belong to anyone
            else if (owner.Equals(""))
            {
                if (_calculator.PlayerCanBuy(payment))
                {
                    _message.BuyPropertyMessage(payment);
                    _calculator.Pay(payment);
                    _tiles[location].GetComponent<PropertyTile>().SetOwner(name);
                }
                else
                {
                    _message.CantBuyPropertyMessage();
                }
            }
            // Belong to other player
            else
            {
                var otherPlayer = GameObject.Find(owner).GetComponent<Player>();
                _message.OtherPlayerPropertyMessage(owner, payment);
                _calculator.PayOtherPlayer(otherPlayer, payment);
            }
        }
        else if (_tiles[location].tag == "Reward")
        {
            var reward = _tiles[location].GetComponent<RewardTile>().CalculateReward();
            _message.RewardMessage(reward);
            _calculator.GetPayment(reward);
        }

        else if (_tiles[location].tag == "Start")
        {
            var reward = _tiles[location].GetComponent<StartTile>().GetReward();
            _message.StartMessage(reward);
            _calculator.GetPayment(reward);
        }
    }
}