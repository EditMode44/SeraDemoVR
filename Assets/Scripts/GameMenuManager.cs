using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    
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
                menu.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => menu.SetActive(false));
            }
            else
            {
                menu.SetActive(true);
                menu.transform.DOScale(Vector3.one, 0.5f);
            }
        }

    }
}
