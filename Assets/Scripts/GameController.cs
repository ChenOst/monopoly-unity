using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private SpawnTiles _spawn;

    [SerializeField] private GameObject _nowPlayingMessage;

    [SerializeField] private GameObject _nowPlayingMessageBody;

    [SerializeField] private Text _nowPlayingTexts;

    [SerializeField] private GameObject message;

    [SerializeField] private GameObject _endGameCanvas;

    [SerializeField] private Text _winnersText;

    [SerializeField] private Image background;

    private GameObject[] _tiles;
    private bool _once;
    private Player _player1, _player2;

    // Start is called before the first frame update
    private void Start()
    {
        // Find both players and set player1 to begin
        _player1 = GameObject.Find("Player 1").GetComponent<Player>();
        _player2 = GameObject.Find("Player 2").GetComponent<Player>();
        _player1.NowPlaying = true;
        UpperPlayingText();
    }

    // Update is called once per frame
    private void Update()
    {
        RunGame();
        CheckForWinners();
    }

    private void CheckForWinners()
    {
        // If one of the player run out of money finish the game
        if (_player1.Money <= 0)
        {
            Debug.Log("End Game : " + _player2.name + " Wins");
            Color color = new Color32(20, 62, 106, 232);
            StartCoroutine(WaitBeforeEndingTheGame(_player2.name, color));
        }

        if (_player2.Money <= 0)
        {
            Debug.Log("End Game : " + _player1.name + " Wins");
            Color color = new Color32(152, 3, 0, 232);
            StartCoroutine(WaitBeforeEndingTheGame(_player1.name, color));
        }
    }

    private void RunGame()
    {
        // player1's turn
        if (_player1.NowPlaying)
        {
            _nowPlayingMessage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            _nowPlayingMessageBody.transform.rotation = new Quaternion(0, 0, 0, 0);
            if (_player1.PlayersTurn() || _once)
            {
                _once = true;
                if (!message.activeSelf)
                {
                    _player1.NowPlaying = false;
                    _player1.ResetAll();
                    _player2.NowPlaying = true;
                    _once = false;
                }
            }
        }

        // player2's turn
        if (_player2.NowPlaying)
        {
            _nowPlayingMessage.GetComponent<RectTransform>().anchoredPosition = new Vector2(480, 0);
            _nowPlayingMessageBody.transform.rotation = new Quaternion(0, 0, 180, 0);
            if (_player2.PlayersTurn() || _once)
            {
                _once = true;
                if (!message.activeSelf)
                {
                    _player2.NowPlaying = false;
                    _player2.ResetAll();
                    _player1.NowPlaying = true;
                    _once = false;
                }
            }
        }
    }

    private IEnumerator WaitBeforeEndingTheGame(string winner, Color color)
    {
        yield return new WaitForSeconds(0.7f);
        _endGameCanvas.SetActive(true);
        background.color = color;
        _winnersText.text = $"Congratulations\n{winner}!\nYou are the winner!";
    }

    private void UpperPlayingText()
    {
        string str = _nowPlayingTexts.text;
        _nowPlayingTexts.text = str.ToUpper();
    }
}