using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorCreateObj : EditorWindow
{
    public CreateSetting m_createSetting;

    [MenuItem("GUILayout Study/Create Gameobject")]
    static void Init()
    {
        EditorCreateObj window = (EditorCreateObj)EditorWindow.GetWindow(typeof(EditorCreateObj));
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("-----------------物体控制-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("生成物体"))
        {
            Debug.Log("Create.");
            GameObject go = GameObject.Instantiate(m_createSetting.m_cubePrefab);
            go.GetComponent<MeshRenderer>().material = m_createSetting.m_material;
            go.transform.position = m_createSetting.m_createPos;
            go.transform.SetParent(GameObject.Find("obj").transform);
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("销毁"))
        {
            try
            {
                GameObject go = GameObject.Find("obj");
                List<Transform> l = new List<Transform>();
                foreach (Transform t in go.transform)
                {
                    l.Add(t);
                }
                for (int i = 0; i < l.Count; i++)
                {
                    GameObject.DestroyImmediate(l[i].gameObject);
                }
            }
            catch (Exception e) {
                ShowError("CleanupScene", e);
            }
        }
        EditorGUILayout.EndHorizontal();

    }

    private static void ShowHint(string message)
    {
        EditorUtility.ClearProgressBar();
        EditorUtility.DisplayDialog("Xiaomi Poc", message, "OK");
    }

    private static void ShowError(string message, Exception e)
    {
        ShowHint("Critical Error Occurs when executing " + message + "\n see console log for more info \n");
        Debug.LogError(e.ToString());
    }
}
