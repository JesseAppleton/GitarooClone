using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int multiplier = 1;
    int streak = 0;

    // Start is called before the first frame update
    void Start() {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Streak", 0);
        PlayerPrefs.SetInt("HighStreak", 0);
        PlayerPrefs.SetInt("Mult", 1);
        PlayerPrefs.SetInt("RockMeter", 25);
        PlayerPrefs.SetInt("NotesHit", 0);

        PlayerPrefs.SetInt("Start", 1);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        // Destroy(col.gameObject); //needs to be based on the note that enters...if certain not then destroy?
        // reset streak?
    }

    // When player hits a note it keeps count, adds multiplier, and increases health
    public void AddStreak() {
        if (PlayerPrefs.GetInt("RockMeter") +1 < 50){
            PlayerPrefs.SetInt("RockMeter", PlayerPrefs.GetInt("RockMeter") + 1);
        }
        streak++;
        if (streak >= 24) {
            multiplier = 4;
        }
        else if (streak >= 16) {
            multiplier = 3;
        }
        else if (streak >= 8) {
            multiplier = 2;
        }
        else {
            multiplier = 1;
        }
        
        if (streak > PlayerPrefs.GetInt("HighStreak")) {
            PlayerPrefs.SetInt("HighStreak", streak);
        }

        PlayerPrefs.SetInt("NotesHit", PlayerPrefs.GetInt("NotesHit") + 1);

        UpdateGUI();
    }

    // streak reset when the player misses a note
    public void ResetStreak() {
        PlayerPrefs.SetInt("RockMeter", PlayerPrefs.GetInt("RockMeter") - 2);
        if (PlayerPrefs.GetInt("RockMeter") < 1) {
            LoseGame();
        }
        streak = 0;
        multiplier = 1;
        UpdateGUI();
    }

    // Yeppers
    void UpdateGUI() {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Mult", multiplier);
    }

    // lose the game
    public void LoseGame() {
        PlayerPrefs.SetInt("Start", 0);

        SceneManager.LoadScene(1);
    }
    
    // win the game
    public void WinGame() {
        PlayerPrefs.SetInt("Start", 0);

        if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score")) {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        }
        SceneManager.LoadScene(2);
    }
}
