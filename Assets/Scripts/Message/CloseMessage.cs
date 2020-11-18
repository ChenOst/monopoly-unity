using UnityEngine;

public class CloseMessage : MonoBehaviour
{
    [SerializeField] private GameObject _message;

    public void Close()
    {
        _message.SetActive(false);
    }
}