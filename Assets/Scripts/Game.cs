using UnityEngine;
using UnityEngine.Events;


public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;

    private int _score;
    
    public float speed;
    public bool isStarted;

    public UnityEvent<int> onCoin;
    public UnityEvent started;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void AddScore()
    {
        _score++;
        onCoin?.Invoke(_score);
    }

    public void StartGame()
    {
        isStarted = true;
        spawner.StartSpawner();
        started?.Invoke();
    }
}