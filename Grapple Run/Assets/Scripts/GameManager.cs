using UnityEngine;

public class GameManager : MonoBehaviour
{ //class

    public static GameManager Instance { get; private set; }

    [Header("Ground Speed")]
    [SerializeField] float initialGameSpeed = 5f;
    [SerializeField] float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }

    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        gameSpeed = initialGameSpeed;
    }


} //class
