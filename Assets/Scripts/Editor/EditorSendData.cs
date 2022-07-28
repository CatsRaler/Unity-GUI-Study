using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorSendData : EditorWindow
{
    [MenuItem("GUILayout Study/Send Data")]
    static void Init()
    {
        EditorSendData window = (EditorSendData)EditorWindow.GetWindow(typeof(EditorSendData));
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("-----------------Êý¾Ý¿ØÖÆ-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(20);

        EditorGUILayout.BeginVertical();
        EditorGUILayout.PrefixLabel("Send Data");
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Data A")) 
        {
            if (DataController.Instance == null)
            {
                EditorUtility.DisplayDialog("Attention!", "DataController is null, please create it or enter PlayMode first!", "OK");
            }
            else 
            {
                DataController.Instance.OnDataReceived(DataController.DataType.typeA, "this is data of Data A!");
            }           
        }
        if (GUILayout.Button("Data B"))
        {
            if (DataController.Instance == null)
            {
                EditorUtility.DisplayDialog("Attention!", "DataController is null, please create it or enter PlayMode first!", "OK");
            }
            else
            {
                DataController.Instance.OnDataReceived(DataController.DataType.typeB, "this is data of Data B!");
            }
        }
        if (GUILayout.Button("Data C"))
        {
            if (DataController.Instance == null)
            {
                EditorUtility.DisplayDialog("Attention!", "DataController is null, please create it or enter PlayMode first!", "OK");
            }
            else
            {
                DataController.Instance.OnDataReceived(DataController.DataType.typeC, "this is data of Data C!");
            }
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();



    }

}
