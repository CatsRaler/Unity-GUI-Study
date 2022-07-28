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


        EditorGUILayout.Space(20);
        EditorGUILayout.BeginVertical();
        EditorGUILayout.PrefixLabel("物体设置");
        m_createSetting = (CreateSetting)EditorGUILayout.ObjectField("",m_createSetting,typeof(CreateSetting),true);
        EditorGUILayout.EndVertical();


        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("生成固定位置物体"))
        {
            if (m_createSetting == null)
            {
                EditorUtility.DisplayDialog("Attention!", "m_CreateSetting is null, please choose a setting first!", "OK");
            }
            else 
            {
                Debug.Log("Create.");
                GameObject go = GameObject.Instantiate(m_createSetting.m_cubePrefab);
                go.GetComponent<MeshRenderer>().material = m_createSetting.m_material;
                go.transform.position = m_createSetting.m_createPos;
                go.transform.SetParent(GameObject.Find("obj").transform);
            }
        }
        if (GUILayout.Button("生成随机位置物体"))
        {
            if (m_createSetting == null)
            {
                EditorUtility.DisplayDialog("Attention!", "m_CreateSetting is null, please choose a setting first!", "OK");
            }
            else
            {
                Debug.Log("Create.");
                GameObject go = GameObject.Instantiate(m_createSetting.m_cubePrefab);
                go.GetComponent<MeshRenderer>().material = m_createSetting.m_material;
                go.transform.position = new Vector3(
                        m_createSetting.x_Range * UnityEngine.Random.Range(-1f,1f),
                        m_createSetting.y_Range * UnityEngine.Random.Range(-1f,1f),
                        m_createSetting.z_Range * UnityEngine.Random.Range(-1f,1f)
                    ) ; 
                go.transform.SetParent(GameObject.Find("obj").transform);
            }
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("销毁所有物体"))
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
