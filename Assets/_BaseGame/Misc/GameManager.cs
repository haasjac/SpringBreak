using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager S;
    [HideInInspector] public Player player;
    GameManagerJuice juice;

    int score = 100;
    int lastTime = 0;
    public Text scoreText;
    [HideInInspector] public bool gameEnding = false; 

    void Awake() {
        S = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        juice = this.GetComponent<GameManagerJuice>();

    }

    void Update() {
        int thisTime = Mathf.FloorToInt(Time.time);
        if (thisTime != lastTime && !gameEnding) {
            ChangePoints(-1);
            lastTime = thisTime;
        }
    }

    public void PlayerDied() {
        StartCoroutine(RestartGame(2));
        juice.OnPlayerDied();
    }

    public void LevelComplete() {
        StartCoroutine(RestartGame(10));
        juice.OnLevelComplete();
    }

    IEnumerator RestartGame(float time) {
        gameEnding = true;
        yield return new WaitForSeconds(time);
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }

    public void ChangePoints(int pointChange) {
        score += pointChange;
        scoreText.text = score.ToString();
        juice.OnPointsChanged(pointChange);        
    }
}
