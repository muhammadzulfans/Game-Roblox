using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
            GameOverPanel.SetActive(true);
//            FindObjectOfType<ScoreManager>().StopScore();
            Time.timeScale = 0f;
        }
    }
}
