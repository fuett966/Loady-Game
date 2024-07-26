using TMPro;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score = 0;
    private PlayerData _playerData;

    private void Start()
    {
        UpdateUIScore();
        _playerData = PlayerManager.instance.GetData();

        if (_playerData != null)
        {
            if (_score < _playerData.game1Score)
            {
                _score = _playerData.game1Score;
                UpdateUIScore();
            }
        }
    }


    public void Click()
    {
        _score += 1;
        UpdateUIScore();
        PlayerManager.instance.GetData().game1Score = _score;
    }
    private void UpdateUIScore()
    {
        _scoreText.text = "Score: " + _score;
    }

}
