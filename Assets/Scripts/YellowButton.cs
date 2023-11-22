using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class YellowButton : MonoBehaviour
{

    public Color overColor = Color.white;
    public Color outColor = Color.white;
    public float transitionTime = .3f;

    private Image image;

    void Start()
    {
        image  = GetComponent<Image>();
    }

    public void OnOver()    
    {
        image.DOColor(overColor, transitionTime);
    }

    public void OnOut()
    {
        image.DOColor(outColor, transitionTime);
    }

    public void OnDown()
    {
        transform.DOScale(new Vector3(.92f, .92f, .92f), transitionTime);
    }

    public void OnUp()
    {
        transform.DOScale(new Vector3(1f, 1f, 1f), transitionTime);        
    }

    public void OnClick()
    {
        transform.DOScale(new Vector3(1f, 1f, 1f), transitionTime * 2.5f).SetEase(Ease.OutElastic);
        EventManager.instance.RandomDice();
    }

}
