using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public float scoreSpeed = 1f;
    private float timer;
    public int score = 0;
    private bool isGameOver = false;

    private void Update()
    {
        if (!isGameOver)
        {
            timer += Time.deltaTime;
            if (timer >= scoreSpeed)
            {
                AddScore(1);
                timer = 0f;
            }
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }

    public void StopScore()
    {
        isGameOver = true;
    }
}
