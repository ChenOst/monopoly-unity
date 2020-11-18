using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] [Range(2, 5)] private float _speed;

    [SerializeField] [Range(-1, 1)] private float _dist;

    [SerializeField] private SpawnTiles spawn;

    private bool _canMove;
    private int _correntLocation;
    private int _destination;
    private int _edgePoint;
    private bool _goAround;
    private int _numberOfSteps;
    private int _boardSize;
    private int _edgeSize;
    private int _firstTileLocation;
    private GameObject[] tiles;
    public bool reachedDestination { get; private set; }

    public void Reset()
    {
        _canMove = false;
        reachedDestination = false;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Make sure the tiles exsits before using
        if (spawn != null && spawn.GetTiles() != null) tiles = spawn.GetTiles();
        _correntLocation = GetComponent<Player>().Location;
        _boardSize = tiles.Length;
        _edgeSize = _boardSize / 4;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_canMove)
        {
            if (_goAround)
                MoveToEdge();
            else
                MoveToDestination();
        }
    }

    // Go to destination
    private void MoveToDestination()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(tiles[_destination].transform.position.x + _dist, tiles[_destination].transform.position.y),
            _speed * Time.deltaTime);
        if ((Vector2) transform.position == new Vector2(tiles[_destination].transform.position.x + _dist,
            tiles[_destination].transform.position.y))
        {
            reachedDestination = true;
            _correntLocation = _destination;
            GetComponent<Player>().Location = _correntLocation;
        }
    }

    // Go to the edge before the destination
    private void MoveToEdge()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(tiles[_edgePoint].transform.position.x + _dist, tiles[_edgePoint].transform.position.y),
            _speed * Time.deltaTime);
        if ((Vector2) transform.position == new Vector2(tiles[_edgePoint].transform.position.x + _dist,
            tiles[_edgePoint].transform.position.y))
        {
            _correntLocation = _edgePoint;
            GetComponent<Player>().Location = _correntLocation;
            _goAround = false;
        }
    }

    public void SetSteps(int steps)
    {
        _numberOfSteps = steps;
        _destination = _correntLocation + _numberOfSteps;
        if (_destination > _boardSize)
        {
            // Can add cycle completed
            _goAround = true;
            _destination -= _boardSize;
            _edgePoint = _firstTileLocation;
        }
        else if (_destination == _boardSize)
        {
            _goAround = false;
            _destination = _firstTileLocation;
        }
        else
        {
            if (_destination / _edgeSize != _correntLocation / _edgeSize)
            {
                _goAround = true;
                _edgePoint = _destination / _edgeSize * _edgeSize;
            }
            else
            {
                _goAround = false;
            }
        }
    }

    public void PlayerCanMove()
    {
        _canMove = true;
    }
}