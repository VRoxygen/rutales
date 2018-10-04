//Copyright (c) 2018 - @QuantumCalzone

using UnityEngine;
using UnityEngine.Events;

public class GameManager : GameObjectBase {

    #region Variables

    private static GameManager instance;
    private static object singletonLock = new object();

    public GameStateChangeEvent onGameStateChange = new GameStateChangeEvent();

    private GameStates gameState = GameStates.Free;

    private Player player;
    private Dog dog;
    //private Ball ball;

    #endregion

    #region Unity Methods

    private void Awake() {

        lock (singletonLock) {
            GameManager [] instances = FindObjectsOfType<GameManager>();
            if (instances != null && instances.Length > 1 && instance != this) {
                Debug.LogWarning("Destroying duplicate instance game object.", gameObject);
                UnityUtil.DestroyThis(this);
            } else instance = this;
        }

        player = Player.Instance;
        dog = FindObjectOfType<Dog>();
        //ball = FindObjectOfType<Ball>();

    }

    #endregion

    #region Get

    public static GameManager Instance { get { return instance; } }

    public GameStates GetGameState { get { return gameState; } }

    //public Ball GetBall { get { return ball; } }

    #endregion

    #region Set or Toggle

    public void SetGameState (GameStates targetValue) {

        /*if (debugThis) */Debug.Log(string.Format("SetGameState ( targetValue: {0} )", targetValue), gameObject);

        gameState = targetValue;

        switch (gameState) {
            case GameStates.Free:
            break;
            case GameStates.Ball:
            break;
            case GameStates.Leashed:
            break;
            default:
            Debug.LogWarning(string.Format("SetGameState ( targetValue: {0} ) | might want to add support for this", targetValue), gameObject);
            break;
        }

        onGameStateChange.Invoke(gameState);

    }

    #endregion

    #region Methods
    #endregion

}

[System.Serializable]
public class GameStateChangeEvent : UnityEvent<GameStates> {
}