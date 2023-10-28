using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private Animator rightHandAnimator;
    public InputActionProperty showButton;


    private void Start()
    {
        menu.SetActive(false);
        menu.transform.localScale = Vector3.zero;
    }


    private void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            if (menu.activeSelf)
            {
                rightHandAnimator.SetBool("Sign", false);
                menu.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => menu.SetActive(false));
            }
            else
            {
                rightHandAnimator.SetBool("Sign", true);
                menu.SetActive(true);
                menu.transform.DOScale(Vector3.one, 0.5f);
            }
        }

    }
}
