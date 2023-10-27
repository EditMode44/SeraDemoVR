using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TutorialMission", menuName = "Tutorial")]
public class TutorialMission : ScriptableObject
{
    [TextArea(3, 10)]
    public string missionText;
    public ImageType imageType;
    public CircleArea circleArea;
    public Hand hand;
    public ImagePos pos;
    public bool missionCompleted;





    public enum ImageType
    {
        Normal,
        Trigger
    }

    public enum CircleArea
    {
        Joystick,
        Primary,
        Secondary,
        Grip,
        Trigger
    }

    public enum Hand
    {
        Left,
        Right,
        Both,
        Trigger
    }

    public enum ImagePos
    {
        Normal,
        Both
    }
}
