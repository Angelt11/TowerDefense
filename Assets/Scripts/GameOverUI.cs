using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _showAnimationName = "ShowGameOver";
    [SerializeField] private string _hideAnimationName = "HideGameOver";

    public void Show()
    {
        _animator.Play(_showAnimationName);
    }

    public void Hide()
    {
        _animator.Play(_hideAnimationName);
    }
}