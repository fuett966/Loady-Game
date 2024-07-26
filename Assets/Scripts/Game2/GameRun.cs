using System.Collections;
using TMPro;
using UnityEngine;

public class GameRun : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTimer;
    [SerializeField] private TextMeshProUGUI _textBestTime;

    private float _bestTime = 0f;
    private float _time = 0f;

    [SerializeField] private GameObject _start;
    [SerializeField] private GameObject _finish;

    private Game2Start _gameStart;
    private Game2Finish _gameFinish;

    private float _timeRun;

    private IEnumerator _gameTimer;

    private PlayerData _playerData;

    private void Awake()
    {
        _gameStart = _start.GetComponent<Game2Start>();
        _gameFinish = _finish.GetComponent<Game2Finish>();
    }
    private void OnEnable()
    {
        Game2Start.OnGameStarted += StartRun;
        Game2Finish.OnGameEnded += FinishRun;
    }

    private void OnDisable()
    {
        Game2Start.OnGameStarted -= StartRun;
        Game2Finish.OnGameEnded -= FinishRun;
    }

    private void Start()
    {
        UpdateUITime();
        _playerData = PlayerManager.instance.GetData();

        if (_playerData != null)
        {
            CheckTimeRecord(_playerData.game2BestTime);
        }
    }

    public void StartRun()
    {
        _time = 0f;
        UpdateUITime();

        _start.SetActive(false);
        _finish.SetActive(true);

        _gameTimer = GameTimer();

        StartCoroutine(_gameTimer);
    }

    public void FinishRun()
    {
        _finish.SetActive(false);
        _start.SetActive(true);

        StopCoroutine(_gameTimer);

        CheckTimeRecord(_time);
    }

    private void CheckTimeRecord(float _newTime)
    {
        if (_bestTime <= 0 || _newTime < _bestTime)
        {
            _bestTime = _newTime;
            _textBestTime.text = "Best time: " + _bestTime.ToString();
            _playerData.game2BestTime = _bestTime;
        }
    }
    private void UpdateUITime()
    {
        _textTimer.text = $"Time: {_time}";
    }

    IEnumerator GameTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            _time += 0.01f;
            UpdateUITime();
        }
    }
}
