using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Animator gameOverAnimator;
    [SerializeField]
    private CoinSpawner coinSpawner;
    [SerializeField]
    private Animator towerAnimator;
    [SerializeField] 
    private EnemySpawner[] enemySpawners;
    [SerializeField]
    private GameObject[] buttonsToHide;

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        SoundManager.instance.Play("GameOver");
        gameOverAnimator.SetTrigger("Show");
        coinSpawner.Stop();

        foreach (var spawner in enemySpawners)
        spawner.Stop();
        foreach (var button in buttonsToHide)
        button.SetActive(false);
        if (towerAnimator != null)
        {
            towerAnimator.SetTrigger("Destroyed");
        }
    }

    public void HideGameOver()
    {
        foreach (var button in buttonsToHide)
            button.SetActive(true);
        gameOverPanel.SetActive(false);
        gameOverAnimator.SetTrigger("Show");
    }
}