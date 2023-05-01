using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public string gameOverSceneName = "GameOverScene";

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Handle player death
            Debug.Log("Player died");
            LoadGameOverScene();
        }
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}

//Idhi correct pani chesthundi

