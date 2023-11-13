using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSera : MonoBehaviour
{
    [SerializeField] private Image fadeImage;

    private void Start()
    {
        fadeImage.DOFade(0f, 1f);
    }

    public void StartSeraSim()
    {
        fadeImage.DOFade(1f, 1f).OnComplete(() => SceneManager.LoadScene(1));
    }
}
