using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportManager : MonoBehaviour
{
    public static TeleportManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    [SerializeField] private Image fadeImage;
    public void Teleport(Transform targetTransform)
    {
        fadeImage.DOFade(1f, 1f).SetDelay(1f);
        transform.DOMove(targetTransform.position, 0f).SetDelay(2f);
        transform.DORotateQuaternion(targetTransform.rotation, 0f).SetDelay(2f);
        fadeImage.DOFade(0f, 1f).SetDelay(2f);
    }
}
