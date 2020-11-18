using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    [SerializeField] private GameObject _endGameCanvas;

    private string gameScene = "Game";

    public void LoadGame()
    {
        _endGameCanvas.SetActive(false);
        SceneManager.LoadScene("Game");
    }
}