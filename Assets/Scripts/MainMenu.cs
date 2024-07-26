using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button _startGame1;
    [SerializeField] private Button _startGame2;

    [SerializeField] private bool _game1Loaded = false;
    [SerializeField] private bool _game2Loaded = false;

    private void Start()
    {
        _startGame1.interactable = false;
        _startGame2.interactable = false;

        if (PlayerManager.instance.GetData().isGame1Loaded)
        {
            LoadGame1();
        }
        else
        {
            UnloadGame1();
        }
        if (PlayerManager.instance.GetData().isGame2Loaded)
        {
            LoadGame2();
        }
        else
        {
            UnloadGame2();
        }
    }

    public void LoadGame1()
    {
        _game1Loaded = true;
        _startGame1.interactable = true;
        PlayerManager.instance.GetData().isGame1Loaded = true;
    }

    public void UnloadGame1()
    {
        _game1Loaded = false;
        _startGame1.interactable = false;
        PlayerManager.instance.GetData().isGame1Loaded = false;
    }

    public void StartGame1()
    {
        if (_game1Loaded)
        {
            // ? DI+Singletone LevelLoader
            SceneManager.LoadScene("Game1");
        }
    }

    public void LoadGame2()
    {
        _game2Loaded = true;
        _startGame2.interactable = true;
        PlayerManager.instance.GetData().isGame2Loaded = true;
    }

    public void UnloadGame2()
    {
        _game2Loaded = false;
        _startGame2.interactable = false;
        PlayerManager.instance.GetData().isGame2Loaded = false;
    }

    public void StartGame2()
    {
        if (_game2Loaded)
        {
            // ? DI+Singletone LevelLoader
            SceneManager.LoadScene("Game2");
        }
    }
}

