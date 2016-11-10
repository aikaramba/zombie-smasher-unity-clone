using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    static GameController instance;
    public static GameController Instance  {
        get { if (instance == null) instance = FindObjectOfType<GameController>(); return instance; }
        private set { instance = value; }
    }
    //-----------------
    private int bombs = 3;
    private int lives = 3;
    private int score = 0;
    private GameState gameState;
    public static GameState GameState {
        get { return Instance.gameState; }
        private set { Instance.gameState = value;  }
    }
    private float elapsedTime = 0f;
    // editor public
    public float roundDuration = 60f;
    public Transform[] spawnPoints; // possible spawn points for zombies
    public Transform[] movementTargets; // possible movement targets for zombie behaviour
    // editor public end

    public static int Score {
        get { return Instance.score; }
        private set { Instance.score = value; }
    }
    public static int Lives
    {
        get { return Instance.lives; }
        private set { Instance.lives = value; }
    }
    public static int Bombs
    {
        get { return Instance.bombs; }
        private set { Instance.bombs = value; }
    }

    public static void AddScore(int score) {
        Score += score;
    }
    public static float GetRemainingTimeRatio() {
        return Instance.elapsedTime / Instance.roundDuration;
    }
    public static float GetRemainingTime() {
        return Instance.roundDuration - Instance.elapsedTime;
    }
    public static float GetElapsedTime() {
        return Instance.elapsedTime;
    }
    public static float GetRoundDuration() {
        return Instance.roundDuration;
    }
    public static void DetonateBomb() {
        if (AreBombsAvailable() && IsGameRunning()) {
            Bombs--;
            Instance.KillAllZombies();
        }
    }
    public static Vector3 GetRandomSpawnPoint() {
        return Instance.spawnPoints[Random.Range(0, Instance.spawnPoints.Length)].position;
    }
    public static Vector3 GetRandomMovementTarget() {
        return Instance.movementTargets[Random.Range(0, Instance.movementTargets.Length)].position;
    }
    public static void SpendLives(int lives) {
        Lives -= lives;
    }
    public static bool IsGameRunning() {
        return GameState == GameState.Running;
    }
    public static bool AreBombsAvailable() {
        return Bombs > 0;
    }
    public static void RestartGame() {
        SceneManager.LoadScene("Game");
    }
    //------------------------
    private void KillAllZombies() {
        foreach (ZombieBehaviour zbT in FindObjectsOfType<ZombieBehaviour>()) {
            if(zbT.GetType() != typeof(FriendlyZombie))
                zbT.Kill();
        }
    }
    //----------------------
    void Start() {
        // setting game to run normally
        Time.timeScale = 1;
        gameState = GameState.Running;
    }
    void Update() {
        switch (gameState) {
            case GameState.Running:
                // check if round has ended
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= roundDuration) {
                    elapsedTime = roundDuration;
                    gameState = GameState.WinScreen;
                }
                // check if player is dead
                if (lives <= 0) {
                    gameState = GameState.GameOver;
                }
                break;
            case GameState.WinScreen:
                Time.timeScale = 0; // hard pausing the game if it is not running
                break;
            case GameState.GameOver:
                Time.timeScale = 0; // hard pausing the game if it is not running
                break;
            default:
                break;
        }
    }
}
public enum GameState { Running, WinScreen, GameOver }
