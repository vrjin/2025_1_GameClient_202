using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog System/Dialog")]

public class DialogSO : ScriptableObject
{
    public int id;
    public string characterName;
    public string text;
    public int nextild;
    public Sprite portrait;

    [Tooltip("초상화 리소스 경로 (Resources 폴터 내의 경로")]
    public string portraitPath;
}
