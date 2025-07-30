using UnityEngine;
using UnityEngine.UI;

public class BuscandoCarta : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Text _text;
    [SerializeField]
    private string _appearAnimationName = "BuscandoCartaAppear";
    [SerializeField]
    private string _showAnimationName = "ShowBuscandoCarta";
    [SerializeField]
    private string _hideAnimationName = "HideBuscandoCarta";

    public void BuscandoCartaAppear()
    {
        _animator.Play(_appearAnimationName);
    }
    public void ShowBuscandoCarta()
    {
        _animator.Play(_showAnimationName);
        CenterOnScreen();
    }

    public void HideBuscandoCarta()
    {
        _animator.Play(_hideAnimationName);
    }
    private void CenterOnScreen()
    {
        RectTransform rt = GetComponent<RectTransform>();
        if (rt != null)
        {
            rt.anchorMin = new Vector2(0.5f, 0.5f); // punto central
            rt.anchorMax = new Vector2(0.5f, 0.5f);
            rt.pivot = new Vector2(0.5f, 0.5f);      // centro del objeto
            rt.anchoredPosition = Vector2.zero;     // lo coloca exactamente en el centro
        }
    }
}
