using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ScrewSpawner : MonoBehaviour
{
    public static ScrewSpawner instance;

    public InputActionReference leftIns;   
    public InputActionReference rightIns;


    [SerializeField] private GameObject screw;
    [SerializeField] private XRDirectInteractor rightInteractor;
    [SerializeField] private XRDirectInteractor leftInteractor;
    [SerializeField] private XRInteractionManager XRInteractionManager;


    private GameObject leftScrew;
    private GameObject rightScrew;
     

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

        leftIns.action.started += InstantiateLeft;
        rightIns.action.started += InstantiateRight;
    }

    private void InstantiateRight(InputAction.CallbackContext obj)
    {
        if (rightScrew == null)
        {
            if (!rightInteractor.hasSelection)
            {
                GameObject insScrew = Instantiate(screw, rightInteractor.transform.position, Quaternion.identity);
                insScrew.GetComponent<Screw>().SetIsRight(true);
                XRInteractionManager.SelectEnter(rightInteractor, (IXRSelectInteractable)insScrew.GetComponent<XRBaseInteractable>());
                insScrew.GetComponent<GrabHandPose>().SetupPoseForInsObjects(rightInteractor.GetComponentInChildren<HandData>());
                rightScrew = insScrew;
            }
        }
    }

    private void InstantiateLeft(InputAction.CallbackContext obj)
    {
        if (leftScrew == null)
        {
            if (!leftInteractor.hasSelection)
            {
                GameObject insScrew = Instantiate(screw, leftInteractor.transform.position, Quaternion.identity);
                insScrew.GetComponent<Screw>().SetIsRight(false);
                XRInteractionManager.SelectEnter(leftInteractor, (IXRSelectInteractable)insScrew.GetComponent<XRBaseInteractable>());
                insScrew.GetComponent<GrabHandPose>().SetupPoseForInsObjects(leftInteractor.GetComponentInChildren<HandData>());
                leftScrew = insScrew;
            }
        }
    }


    public void ClearHandScrews(SelectExitEventArgs arg)
    {
        if (arg.interactorObject.transform.GetComponentInChildren<HandData>().handType == HandData.HandModelType.Right)
        {
            rightScrew = null;
        }
        else
        {
            leftScrew = null;
        }
    }


    public void CancelLeft()
    {
        leftScrew.GetComponent<GrabHandPose>().UnSetupPoseForInsObjects(leftInteractor.GetComponentInChildren<HandData>());
        XRInteractionManager.SelectExit(leftInteractor, (IXRSelectInteractable)leftScrew.GetComponent<XRBaseInteractable>());
    }

    public void CancelRight()
    {
        rightScrew.GetComponent<GrabHandPose>().UnSetupPoseForInsObjects(rightInteractor.GetComponentInChildren<HandData>());
        XRInteractionManager.SelectExit(rightInteractor, (IXRSelectInteractable)rightScrew.GetComponent<XRBaseInteractable>());
    }

}
