using UnityEngine;

public class SpawnTiles : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToSpawn;

    [SerializeField] [Tooltip("Number of tiles according to the board image")]
    private int _size = 24;

    private int _sizeEdge;
    private GameObject[] _tiles;
    public bool boardCreated { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        _tiles = new GameObject[_size];
        _sizeEdge = _size / 4;
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        // Start Tile
        var posToSpawn = new Vector2(8.8f, -8.8f);
        var newTile = Instantiate(_objectsToSpawn[2], posToSpawn, Quaternion.identity);
        newTile.transform.parent = transform;
        _tiles[0] = newTile;

        // Reward Tiles
        // Left 
        posToSpawn = new Vector2(-8.8f, -8.8f);
        newTile = Instantiate(_objectsToSpawn[1], posToSpawn, Quaternion.identity);
        newTile.transform.parent = transform;
        _tiles[_sizeEdge * 1] = newTile;

        // Up
        posToSpawn = new Vector2(-8.8f, 8.8f);
        newTile = Instantiate(_objectsToSpawn[1], posToSpawn, Quaternion.identity);
        newTile.transform.parent = transform;
        _tiles[_sizeEdge * 2] = newTile;

        // Right
        posToSpawn = new Vector2(8.8f, 8.8f);
        newTile = Instantiate(_objectsToSpawn[1], posToSpawn, Quaternion.identity);
        newTile.transform.parent = transform;
        _tiles[_sizeEdge * 3] = newTile;

        // Property Tiles
        for (var i = 1; i < _sizeEdge; i++)
        {
            // Down
            posToSpawn = new Vector2(8.625f - 2.875f * i, -8.79f);
            newTile = Instantiate(_objectsToSpawn[0], posToSpawn, Quaternion.identity);
            newTile.transform.parent = transform;
            _tiles[i] = newTile;

            // Left
            posToSpawn = new Vector2(-8.79f, -8.625f + 2.875f * i);
            newTile = Instantiate(_objectsToSpawn[0], posToSpawn, Quaternion.identity);
            newTile.transform.Rotate(0, 0, -90);
            newTile.transform.parent = transform;
            _tiles[_sizeEdge * 1 + i] = newTile;

            // Up
            posToSpawn = new Vector2(-8.625f + 2.875f * i, 8.79f);
            newTile = Instantiate(_objectsToSpawn[0], posToSpawn, Quaternion.identity);
            newTile.transform.Rotate(0, 0, 180);
            newTile.transform.parent = transform;
            _tiles[_sizeEdge * 2 + i] = newTile;

            // Right 
            posToSpawn = new Vector2(8.79f, 8.625f - 2.875f * i);
            newTile = Instantiate(_objectsToSpawn[0], posToSpawn, Quaternion.identity);
            newTile.transform.Rotate(0, 0, 90);
            newTile.transform.parent = transform;
            _tiles[_sizeEdge * 3 + i] = newTile;
        }

        boardCreated = true;
    }

    public GameObject[] GetTiles()
    {
        return _tiles;
    }
}