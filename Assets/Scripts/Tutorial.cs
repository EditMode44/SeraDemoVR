using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Tutorial : MonoBehaviour
{
    [Header("Requaired Objects")]
    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private GameObject leftHandController;
    [SerializeField] private GameObject rightHandController;
    [SerializeField] private GameObject triggerController;
    [SerializeField] private TutorialMission[] misions;
    [SerializeField] private AudioClip[] misionClips;
    [SerializeField] private AudioSource audioSource;
    public InputActionProperty movementButton;
    public InputActionProperty turnButton;
    public InputActionProperty leftScrewButton;
    public InputActionProperty rightScrewButton;
    public InputActionProperty controlPanelButton;
    public InputActionProperty leftTriggerButton;
    public InputActionProperty rightTriggerButton;
    [SerializeField] private XRDirectInteractor leftInteractor;
    [SerializeField] private XRDirectInteractor rightInteractor;

    [Header("Left Hand Circles")]
    [SerializeField] private GameObject LeftJoystickPos;
    [SerializeField] private GameObject LeftGripPos;
    [SerializeField] private GameObject LeftSecondaryButtonPos;
    [SerializeField] private GameObject LeftPrimaryButtonPos;

    [Header("Right Hand Circles")]
    [SerializeField] private GameObject RightJoystickPos;
    [SerializeField] private GameObject RightGripPos;
    [SerializeField] private GameObject RightSecondaryButtonPos;
    [SerializeField] private GameObject RightPrimaryButtonPos;

    [Header("Trigger Hand Circles")]
    [SerializeField] private GameObject triggerHandCircle;

    [Header("Poses")]
    [SerializeField] private Vector3 leftNormalPos;  
    [SerializeField] private Vector3 rightNormalPos; 
    [SerializeField] private Vector3 rightPos;  
    [SerializeField] private Vector3 leftPos;  
    [SerializeField] private Vector3 triggerNormalPos;


    public int currentMissionIndex;

    private GameObject leftSelectedObject;
    private GameObject rightSelectedObject;

    private void Awake()
    {
        leftInteractor.selectEntered.AddListener(OnSelectLeft);
        rightInteractor.selectEntered.AddListener(OnSelectRight);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        UpdateTutorialUI();
        CheckMisionFinish();
    }

    private void UpdateTutorialUI()
    {
        if (currentMissionIndex < misions.Length)
        {
            if (audioSource.clip != misionClips[currentMissionIndex])
            {
                audioSource.clip = misionClips[currentMissionIndex];
                audioSource.Play();
            }
            tutorialText.text = misions[currentMissionIndex].missionText;
            switch (misions[currentMissionIndex].hand)
            {
                case TutorialMission.Hand.Left:
                    leftHandController.SetActive(true);
                    rightHandController.SetActive(false);
                    triggerController.SetActive(false);
                    switch (misions[currentMissionIndex].circleArea)
                    {
                        case TutorialMission.CircleArea.Joystick:
                            LeftJoystickPos.SetActive(true);
                            LeftGripPos.SetActive(false);
                            LeftPrimaryButtonPos.SetActive(false);
                            LeftSecondaryButtonPos.SetActive(false);
                            break;
                        case TutorialMission.CircleArea.Primary:
                            LeftJoystickPos.SetActive(false);
                            LeftGripPos.SetActive(false);
                            LeftPrimaryButtonPos.SetActive(true);
                            LeftSecondaryButtonPos.SetActive(false);
                            break;
                        case TutorialMission.CircleArea.Secondary:
                            LeftJoystickPos.SetActive(false);
                            LeftGripPos.SetActive(false);
                            LeftPrimaryButtonPos.SetActive(false);
                            LeftSecondaryButtonPos.SetActive(true);
                            break;
                        case TutorialMission.CircleArea.Grip:
                            LeftJoystickPos.SetActive(false);
                            LeftGripPos.SetActive(true);
                            LeftPrimaryButtonPos.SetActive(false);
                            LeftSecondaryButtonPos.SetActive(false);
                            break;
                    }
                    switch (misions[currentMissionIndex].pos)
                    {
                        case TutorialMission.ImagePos.Normal:
                            leftHandController.GetComponent<RectTransform>().localPosition = leftNormalPos;
                            break;
                        case TutorialMission.ImagePos.Both:
                            leftHandController.GetComponent<RectTransform>().localPosition = leftPos;
                            break;
                    }
                    break;
                case TutorialMission.Hand.Right:
                    leftHandController.SetActive(false);
                    rightHandController.SetActive(true);
                    triggerController.SetActive(false);
                    switch (misions[currentMissionIndex].circleArea)
                    {
                        case TutorialMission.CircleArea.Joystick:
                            RightJoystickPos.SetActive(true);
                            RightGripPos.SetActive(false);
                            RightPrimaryButtonPos.SetActive(false);
                            RightSecondaryButtonPos.SetActive(false);
                            break;
                        case TutorialMission.CircleArea.Primary:
                            RightJoystickPos.SetActive(false);
                            RightGripPos.SetActive(false);
                            RightPrimaryButtonPos.SetActive(true);
                            RightSecondaryButtonPos.SetActive(false);
                            break;
                        case TutorialMission.CircleArea.Secondary:
                            RightJoystickPos.SetActive(false);
                            RightGripPos.SetActive(false);
                            RightPrimaryButtonPos.SetActive(false);
                            RightSecondaryButtonPos.SetActive(true);
                            break;
                        case TutorialMission.CircleArea.Grip:
                            RightJoystickPos.SetActive(false);
                            RightGripPos.SetActive(true);
                            RightPrimaryButtonPos.SetActive(false);
                            RightSecondaryButtonPos.SetActive(false);
                            break;
                    }
                    switch (misions[currentMissionIndex].pos)
                    {
                        case TutorialMission.ImagePos.Normal:
                            rightHandController.GetComponent<RectTransform>().localPosition = rightNormalPos;
                            break;
                        case TutorialMission.ImagePos.Both:
                            rightHandController.GetComponent<RectTransform>().localPosition = rightPos;
                            break;
                    }
                    break;
                case TutorialMission.Hand.Both:
                    leftHandController.SetActive(true);
                    rightHandController.SetActive(true);
                    triggerController.SetActive(false);
                    switch (misions[currentMissionIndex].circleArea)
                    {
                        case TutorialMission.CircleArea.Joystick:
                            LeftJoystickPos.SetActive(true);
                            LeftGripPos.SetActive(false);
                            LeftPrimaryButtonPos.SetActive(false);
                            LeftSecondaryButtonPos.SetActive(false);
                            RightJoystickPos.SetActive(true);
                            RightGripPos.SetActive(false);
                            RightPrimaryButtonPos.SetActive(false);
                            RightSecondaryButtonPos.SetActive(false);
                            break;
                        case TutorialMission.CircleArea.Primary:
                            LeftJoystickPos.SetActive(false);
                            LeftGripPos.SetActive(false);
                            LeftPrimaryButtonPos.SetActive(true);
                            LeftSecondaryButtonPos.SetActive(false);
                            RightJoystickPos.SetActive(false);
                            RightGripPos.SetActive(false);
                            RightPrimaryButtonPos.SetActive(true);
                            RightSecondaryButtonPos.SetActive(false);
                            break;
                        case TutorialMission.CircleArea.Secondary:
                            LeftJoystickPos.SetActive(false);
                            LeftGripPos.SetActive(false);
                            LeftPrimaryButtonPos.SetActive(false);
                            LeftSecondaryButtonPos.SetActive(true);
                            RightJoystickPos.SetActive(false);
                            RightGripPos.SetActive(false);
                            RightPrimaryButtonPos.SetActive(false);
                            RightSecondaryButtonPos.SetActive(true);
                            break;
                        case TutorialMission.CircleArea.Grip:
                            LeftJoystickPos.SetActive(false);
                            LeftGripPos.SetActive(true);
                            LeftPrimaryButtonPos.SetActive(false);
                            LeftSecondaryButtonPos.SetActive(false);
                            RightJoystickPos.SetActive(false);
                            RightGripPos.SetActive(true);
                            RightPrimaryButtonPos.SetActive(false);
                            RightSecondaryButtonPos.SetActive(false);
                            break;
                    }
                    switch (misions[currentMissionIndex].pos)
                    {
                        case TutorialMission.ImagePos.Normal:
                            leftHandController.GetComponent<RectTransform>().localPosition = leftNormalPos;
                            rightHandController.GetComponent<RectTransform>().localPosition = rightNormalPos;
                            break;
                        case TutorialMission.ImagePos.Both:
                            leftHandController.GetComponent<RectTransform>().localPosition = leftPos;
                            rightHandController.GetComponent<RectTransform>().localPosition = rightPos;
                            break;
                    }
                    break;
                case TutorialMission.Hand.Trigger:
                    leftHandController.SetActive(false);
                    rightHandController.SetActive(false);
                    triggerController.SetActive(true);
                    switch (misions[currentMissionIndex].circleArea)
                    {
                        case TutorialMission.CircleArea.Trigger:
                            triggerHandCircle.SetActive(true);
                            break;
                    }
                    switch (misions[currentMissionIndex].pos)
                    {
                        case TutorialMission.ImagePos.Normal:
                            triggerController.GetComponent<RectTransform>().localPosition = triggerNormalPos;
                            break;
                    }
                    break;
            }
        }
    }

    private void CheckMisionFinish()
    {
        switch (currentMissionIndex)
        {
            case 0:
                if (movementButton.action.ReadValue<Vector2>().magnitude > 0.9f)
                {
                    misions[currentMissionIndex].missionCompleted = true;
                    IncreaseCurrentMisionIndex();
                }
                break;
            case 1:
                if (turnButton.action.ReadValue<Vector2>().magnitude > 0.9f)
                {
                    misions[currentMissionIndex].missionCompleted = true;
                    IncreaseCurrentMisionIndex();
                }
                break;
            case 2:
                if (leftInteractor.hasSelection || rightInteractor.hasSelection)
                {
                    misions[currentMissionIndex].missionCompleted = true;
                    IncreaseCurrentMisionIndex();
                }
                break;
            case 3:
                if (leftScrewButton.action.WasPressedThisFrame() || rightScrewButton.action.WasPressedThisFrame())
                {
                    misions[currentMissionIndex].missionCompleted = true;
                    IncreaseCurrentMisionIndex();
                }
                break;
            case 4:
                if (controlPanelButton.action.WasPressedThisFrame())
                {
                    if (controlPanelButton.action.WasPressedThisFrame())
                    {
                        misions[currentMissionIndex].missionCompleted = true;
                        IncreaseCurrentMisionIndex();
                    }
                }
                break;
            case 5:
                if (leftInteractor.hasSelection || rightInteractor.hasSelection)
                {
                    if (leftSelectedObject != null)
                    {
                        if (leftSelectedObject.TryGetComponent(out DrillManager drillManager))
                        {
                            if (leftTriggerButton.action.WasPressedThisFrame())
                            {
                                Debug.Log("Completed");
                                misions[currentMissionIndex].missionCompleted = true;
                                IncreaseCurrentMisionIndex();
                                return;
                            }
                        }
                        
                    }

                    if (rightSelectedObject != null)
                    {
                        if (rightSelectedObject.TryGetComponent(out DrillManager drillManager))
                        {
                            if (rightTriggerButton.action.WasPressedThisFrame())
                            {
                                Debug.Log("Completed");
                                misions[currentMissionIndex].missionCompleted = true;
                                IncreaseCurrentMisionIndex();
                                return;
                            }
                        }
                    }
                }
                break;
        }
    }

    private void IncreaseCurrentMisionIndex()
    {
        if (currentMissionIndex < misions.Length)
        {
            currentMissionIndex++;
        }
    }

    private void OnSelectLeft(SelectEnterEventArgs arg)
    {
        leftSelectedObject = arg.interactableObject.transform.gameObject;
    }

    private void OnSelectRight(SelectEnterEventArgs arg)
    {
        rightSelectedObject = arg.interactableObject.transform.gameObject;
    }
}

