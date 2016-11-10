using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text timerText;
    public Text scoreText;
    
    public Image[] livesImages = new Image[3];
    public Text bombsCountText;

    public Canvas killScreenCanvas;
    public Text killScreenText;

    private int prevLivesCount = 0;
    //--------------
    void Awake() {
        if (killScreenCanvas)
            killScreenCanvas.enabled = false;

    }
    void Start () {
        prevLivesCount = GameController.Lives;
    }
	void Update () {
        // update score text
        if (scoreText) 
            scoreText.text = GameController.Score.ToString();
        // update bombs count
        if (bombsCountText) 
            bombsCountText.text = GameController.Bombs.ToString();
        // update round timer text
        if (timerText) 
            timerText.text = FloatToTimeSting(GameController.GetRemainingTime());
        // update lives sprites
        if (livesImages.Length == 3 && prevLivesCount != GameController.Lives) {
            for (int i = 0; i < 3; i++) {
                livesImages[i].enabled = (i + 1) <= GameController.Lives;
            }
        }
        // update kill screen
        if (!GameController.IsGameRunning() && killScreenCanvas) {
            killScreenCanvas.enabled = true;
            if (killScreenText)
                killScreenText.text = 
                    GameController.GameState == GameState.WinScreen ? "You won!" : "Game over";
        }
    }
    // convert float of elapsed seconds to readable form
    string FloatToTimeSting(float value) {
        string minutes = Mathf.Floor(value / 60.0f).ToString("0");
        string seconds = (value % 60.0f).ToString("00");
        string time = minutes + ":" + seconds;
        return time;
    }
}
