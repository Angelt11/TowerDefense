using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private GameObject particlesPrefab;
    [SerializeField]
    private Transform towerTransform;
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
    private bool alredyShown = false;
    public void ShowGameOver()
    {
        if (alredyShown) return;
        alredyShown = true;
        gameOverPanel.SetActive(true);
        SoundManager.instance.Play("GameOver");
        gameOverAnimator.SetTrigger("Show");
        coinSpawner.Stop();

        foreach (var spawner in enemySpawners)
            spawner.Stop();
        foreach (var button in buttonsToHide)
            button.SetActive(false);
        if (particlesPrefab != null && towerTransform != null)
        {
            GameObject particles = Instantiate(particlesPrefab, towerTransform.position, Quaternion.identity);
            Destroy(particles, 2f);
        }
        if (towerAnimator != null)
        {
            towerAnimator.SetTrigger("Destroyed");
        }
    }

    public void HideGameOver()
    {
        alredyShown = false;
        foreach (var button in buttonsToHide)
            button.SetActive(true);
        gameOverPanel.SetActive(false);
        gameOverAnimator.SetTrigger("Show");
    }
}