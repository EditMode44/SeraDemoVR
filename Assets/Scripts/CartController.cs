using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CartController : MonoBehaviour
{
    [SerializeField] private ContinuousMoveProviderBase continuousMoveProvider;
    [SerializeField] private float targetSpeed;

    private float defaultPlayerMoveSpeed;

    private void Start()
    {
        defaultPlayerMoveSpeed = continuousMoveProvider.moveSpeed;
    }
    public void HoverEntered()
    {
        continuousMoveProvider.moveSpeed = targetSpeed;
    }

    public void HoverExited()
    {
        continuousMoveProvider.moveSpeed = defaultPlayerMoveSpeed;
    }
}
