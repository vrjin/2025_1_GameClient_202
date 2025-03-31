#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System;


public enum ConversionType
{
    Items,
    Dialogs
}

[Serializable]

public class DialogRowData
{
    public int? id;
    public string characterName;
    public string text;
    public int? nextld;
    private string protraitPath;
    public string choiceText;
    public int? choiceNextld;

}




public class JsonToScriptableConverter : EditorWindow
{
    private string isonFilePath = "";
    private string outputFolder = "Assets/ScriptableObjects";
    private bool creatDatabase = true;
    private ConversionType conversionType = ConversionType.Items;              

    [MenuItem("Tools/JSON to Scriptable Objects")]

    public static void ShowWindow()
    {
        GetWindow<JsonToScriptableConverter>("JSON to Scriptable Objects");

    }                  
}
#endif