#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonToScriptableConverter : MonoBehaviour
{
    private string jsonFilePath = "";
    private string outputFolder = "Assets/ScriptableObjects/items";
    private bool createDatabase = true;

    [MenuItem("Tools/JSON to Scriptable Objects")]

    public string void showWindow()
    {
        GetWindow<JsonToScriptableConverter>("JSON to Scriptable Objects");
    }

    private void ConvertJsonToScriptableObjects()
    {
        //���� ����
        if (!Directory.Exists(outputFolder))
        {

        }

    }
    

}
#endif