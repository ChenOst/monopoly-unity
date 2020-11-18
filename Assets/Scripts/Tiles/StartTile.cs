using UnityEngine;

public class StartTile : MonoBehaviour
{
    [SerializeField] [Range(500, 2000)] private int _startReward = 500;

    public int GetReward()
    {
        return _startReward;
    }
}