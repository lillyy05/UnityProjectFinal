using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameRestartText;
    public TextMeshProUGUI YouWinText; // Reference to "You Win" text UI
    public AudioSource strawberrySound; // Reference to the AudioSource for the strawberry sound
    private int score;

    public Transform dog; // Reference to the dog's transform

    // Start is called before the first frame update
    void Start()
    {
        ResetScore(); // Initialize the score
        GameRestartText.gameObject.SetActive(false); // Ensure Game Restart text is hidden 
        YouWinText.gameObject.SetActive(false); // Ensure "You Win!" text is hidden
    }

    public void UpdateScore(int scoreToAdd)
    {
        // Increase the score
        score += scoreToAdd;
        scoreText.text = "Score = " + score; // Update the score UI

        // Play the strawberry collection sound
        PlayStrawberrySound();
    }

    public void ResetScore()
    {
        score = -4; // Reset the score to 0
        scoreText.text = "Score: " + score; // Update the score UI
    }

    public void RespawnDog(Vector3 respawnPosition)
    {
        dog.position = respawnPosition; // Move the dog to the respawn position
        ResetScore(); // Reset the score
    }

    public void GameOver()
    {
        // Show the Game Over text
        GameRestartText.gameObject.SetActive(true);

        // Hide the "Game Restart" text after a short delay
        StartCoroutine(HideGameRestartText());
    }

    private IEnumerator HideGameRestartText()
    {
        // Wait for 2 seconds and then hide the "Game Restart" text
        yield return new WaitForSeconds(2f);
        GameRestartText.gameObject.SetActive(false);
    }

    public void DisplayWinText()
    {
        // Show the "You Win!" text
        YouWinText.gameObject.SetActive(true);
    }

    private void PlayStrawberrySound()
    {
        if (strawberrySound != null)
        {
            strawberrySound.Play(); // Play the strawberry collection sound
        }
    }
}

