using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.XR.Interaction.Toolkit;

public class DrillManager : MonoBehaviour
{
    [SerializeField] private LayerMask nutLayer;
    [SerializeField] private Transform sphereTransform;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip drillStart;
    [SerializeField] private AudioClip drillLoop;
    [SerializeField] private AudioClip drillEnd;
    [SerializeField] private Transform turningPart;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float rotateSmooth;

    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private ActionBasedController leftController;
    [SerializeField] private ActionBasedController rightController;

    [SerializeField] private XRGrabInteractable interactable;

    private bool activated;
    private HandData currentHandData;

    private void Awake()
    {
        interactable.selectEntered.AddListener(OnSelectEnter);
    }


    private void Update()
    {
        if (activated)
        {
            
            turningPart.transform.DOBlendableLocalRotateBy(new Vector3(0f, 0f, rotateSpeed), rotateSmooth);

            Collider[] nuts = Physics.OverlapSphere(sphereTransform.position, 0.0164766f, nutLayer);

            if (nuts.Length == 1)
            {
                if (nuts[0].transform.localPosition.y < nuts[0].GetComponent<Nut>().GetTargetY())
                {
                    if (currentHandData.handType == HandData.HandModelType.Right)
                    {
                        if (rightController.positionAction.reference.action.enabled)
                        {
                            rightController.positionAction.reference.action.Disable();
                            rightController.rotationAction.reference.action.Disable();
                            rightController.isTrackedAction.reference.action.Disable();
                            rightController.trackingStateAction.reference.action.Disable();
                            
                            rightHand.transform.DOMove(FindClosestAngleObject(nuts[0].GetComponent<Nut>().GetScrewArea().GetHandTransforms()).position, 0.2f);
                            rightHand.transform.DORotateQuaternion(FindClosestAngleObject(nuts[0].GetComponent<Nut>().GetScrewArea().GetHandTransforms()).rotation, 0.2f);
                        }
                        rightHand.transform.position = Vector3.MoveTowards(rightHand.transform.position, new Vector3(rightHand.transform.position.x
                            , nuts[0].transform.position.y, rightHand.transform.position.z), 0.025f * Time.deltaTime);


                    }
                    else if (currentHandData.handType == HandData.HandModelType.Left)
                    {
                        if (leftController.positionAction.reference.action.enabled)
                        {
                            leftController.positionAction.reference.action.Disable();
                            leftController.rotationAction.reference.action.Disable();
                            leftController.isTrackedAction.reference.action.Disable();
                            leftController.trackingStateAction.reference.action.Disable();

                            leftHand.transform.DOMove(FindClosestAngleObject(nuts[0].GetComponent<Nut>().GetScrewArea().GetHandTransforms()).position, 0.2f);
                            leftHand.transform.DORotateQuaternion(FindClosestAngleObject(nuts[0].GetComponent<Nut>().GetScrewArea().GetHandTransforms()).rotation, 0.2f);
                        }

                        leftHand.transform.position = Vector3.MoveTowards(leftHand.transform.position, new Vector3(leftHand.transform.position.x
                            , nuts[0].transform.position.y, leftHand.transform.position.z), 0.025f * Time.deltaTime);

                    }
                    nuts[0].transform.localPosition = Vector3.MoveTowards(nuts[0].transform.localPosition, new Vector3(0f, nuts[0].GetComponent<Nut>().GetTargetY(), 0f), 0.025f * Time.deltaTime);
                    nuts[0].transform.DOBlendableLocalRotateBy(new Vector3(0f, -rotateSpeed, 0f), rotateSmooth);
                }
            }
        }
        else
        {
            if (currentHandData == null)
            {
                return;
            }


            if (currentHandData.handType == HandData.HandModelType.Right)
            {
                if (!rightController.positionAction.reference.action.enabled)
                {
                    rightController.positionAction.reference.action.Enable();
                    rightController.rotationAction.reference.action.Enable();
                    rightController.isTrackedAction.reference.action.Enable();
                    rightController.trackingStateAction.reference.action.Enable();
                }
            }
            else if (currentHandData.handType == HandData.HandModelType.Left)
            {
                if (!leftController.positionAction.reference.action.enabled)
                {
                    leftController.positionAction.reference.action.Enable();
                    leftController.rotationAction.reference.action.Enable();
                    leftController.isTrackedAction.reference.action.Enable();
                    leftController.trackingStateAction.reference.action.Enable();
                }
            }
        }
    }

    public void Activated()
    {
        activated = true;
        audioSource.clip = drillLoop;
        audioSource.loop = true;
        audioSource.Play();
        
    }


    public void DeActivated()
    {
        activated = false;
        audioSource.clip = null;
        audioSource.loop = false;
        audioSource.PlayOneShot(drillEnd);
    }

    public void OnSelectEnter(SelectEnterEventArgs arg)
    {
        currentHandData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
    }

    private Transform FindClosestAngleObject(Transform[] posesAray)
    {
        float closestAngleDifference = float.MaxValue;
        int closestObjectIndex = -1;

        for (int i = 0; i < posesAray.Length; i++)
        {
            float angleDifference = Quaternion.Angle(transform.rotation, posesAray[i].rotation);

            if (angleDifference < closestAngleDifference)
            {
                closestAngleDifference = angleDifference;
                closestObjectIndex = i;
            }
        }

        return posesAray[closestObjectIndex].transform;
    }
}
