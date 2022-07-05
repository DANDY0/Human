using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;


public class UITransitions : MonoBehaviour
{
    [SerializeField] private Transform menu;
    [SerializeField] private int duration;
    [SerializeField] private bool canClick = true;
    [SerializeField] private EventTrigger[] buttons;

    
    public void ToMenuTransition()
    {
        menu.transform.DOLocalMoveX(0, duration);
        StartCoroutine(KeepOffButton());
    }
    public void ToSettingsTransition()
    {
        menu.transform.DOLocalMoveX(-1920, duration);
        StartCoroutine(KeepOffButton());
    }
    
 
    private void Update()
    {
        if (canClick)
        {
            OnButtons();
        }
        else
        {
            OffButtons();
        }
        
    }
    IEnumerator KeepOffButton()
    {
        canClick = false;
        yield return new WaitForSeconds(duration);
        canClick = true;
    }
    
    private void OffButtons()
    {
        foreach (var i in buttons)
        {
            i.enabled = false;
        }
    }
    private void OnButtons()
    {
        foreach (var i in buttons)
        {
            i.enabled = true;
        }
    }
    
    
}