using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class GUIBoxStudy : EditorWindow
{   
    //1.����������Ч�����۵���
    #region BeginFadeGroup
    AnimBool m_ShowExtraFields;
    string m_String;
    Color m_Color = Color.white;
    int m_Number = 0;
    #endregion

    //2.���ǰ�ť�۵���
    #region Foldout
    bool showFoldout = true;
    #endregion

    //5.��������
    #region BeginScrollView
    Vector2 scrollPos;
    string m_String2;
    string m_content = "";
    string t = "--------------ScrollView Test��--------------\n";
    #endregion

    //6.��ѡ����
    #region BeginToggleGroup
    bool[] pos = new bool[3] { true, true, true };
    bool posGroupEnabled = true;
    #endregion

    [MenuItem("GUILayout Study/GUILayout Example")]
    static void Init() {
        GUIBoxStudy window = (GUIBoxStudy)EditorWindow.GetWindow(typeof(GUIBoxStudy));
        window.Show();
    }

    private void OnEnable()
    {
        #region  BeginFadeGroup
        m_ShowExtraFields = new AnimBool(true);//����һ��AnimBool����true��Ĭ����ʾ��
        m_ShowExtraFields.valueChanged.AddListener(Repaint);//�����ػ�
        #endregion
    }

    private void OnGUI()
    {
        //������ʾ
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("-----------------1-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        //1.����������Ч�����۵���
        #region BeginFadeGroup
        m_ShowExtraFields.target = EditorGUILayout.ToggleLeft("��ʾ�۵�����", m_ShowExtraFields.target);//ѡ�������ߵĿ���
        //m_ShowExtraFields.target = EditorGUILayout.Toggle("��ʾ�۵�����", m_ShowExtraFields.target);//ѡ������ұߵĿ���
        //���������Զ������۵��� ����ֵbool������float
        if (EditorGUILayout.BeginFadeGroup(m_ShowExtraFields.faded))
        {
            EditorGUI.indentLevel++;//����������ӣ����µ�GUI����������

            EditorGUILayout.LabelField("Test Label Content");//��ǩ��

            EditorGUILayout.PrefixLabel("Color");//ǰ׺��ǩ
            m_Color = EditorGUILayout.ColorField(m_Color);

            EditorGUILayout.PrefixLabel("Text");
            m_String = EditorGUILayout.TextField(m_String);//�ı���

            EditorGUILayout.PrefixLabel("Number");
            m_Number = EditorGUILayout.IntSlider(m_Number, 0, 10);//Int������

            EditorGUI.indentLevel--;//������ȼ��٣����µ�GUI���������
        }
        EditorGUILayout.EndFadeGroup();
        #endregion

        //�����������ݼ��
        EditorGUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("-----------------2-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        //2.���ǰ�ť�۵���
        #region Foldout
        showFoldout = EditorGUILayout.Foldout(showFoldout, "�۵������壺");
        if (showFoldout)
        {
            EditorGUI.indentLevel+= 2;
            EditorGUILayout.LabelField("�۵�������1");
            EditorGUILayout.LabelField("�۵�������2");
            EditorGUILayout.LabelField("�۵�������3");
            EditorGUI.indentLevel -= 2;
        }
        #endregion

        EditorGUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("-----------------3-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        //3.ˮƽ�����Լ���ť
        #region BeginHorizontal ˮƽ����
        Rect r = EditorGUILayout.BeginHorizontal("Button");
        if (GUI.Button(r, GUIContent.none)) {
            Debug.Log("Go here");
        }
        GUILayout.Label("I'm inside the button");
        GUILayout.Label("So am I");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("�����ı�");
        if (GUILayout.Button("������ť"))
        {
            EditorUtility.DisplayDialog("Dialog Label", "This is a test dialog, press 'OK' to continue!", "OK");
        }
        if (GUILayout.Button("Debug��ť"))
        {
            Debug.Log("GUILayout�İ�ť");
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("-----------------4-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        //4.��ֱ�����Լ���ť
        #region BeginVertical ��ֱ����
        EditorGUILayout.BeginVertical();
        GUILayout.Label("�����ı�");
        if (GUILayout.Button("������ť"))
        {
            EditorUtility.DisplayDialog("Dialog Label", "This is a test dialog, press 'OK' to continue!", "OK");
        }
        if (GUILayout.Button("Debug��ť"))
        {
            Debug.Log("GUILayout�İ�ť");
        }
        EditorGUILayout.EndVertical();
        #endregion

        EditorGUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("-----------------5-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndHorizontal();


        //5.��������
        #region BeginScrollView
        //��Ҫ������ֵ��ֵ����ʱ��������Ȼ�ϲ���
        //�������GUILayoutOption�������ƴ�С
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(200), GUILayout.Height(100));
        GUILayout.Label(m_content);
        EditorGUILayout.EndScrollView();

        EditorGUILayout.PrefixLabel("Test Text String");
        m_String2 = EditorGUILayout.TextField(m_String2);//�ı���

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("�������"))
            m_content += m_String2 + "\n";
        if (GUILayout.Button("�������"))
            m_content = "";
        EditorGUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("-----------------6-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        //6.��ѡ����
        #region BeginToggleGroup
        posGroupEnabled = EditorGUILayout.BeginToggleGroup("ToggleGroup", posGroupEnabled);
        EditorGUILayout.BeginVertical();
        pos[0] = EditorGUILayout.Toggle("Toggle1", pos[0]);
        pos[1] = EditorGUILayout.Toggle("Toggle2", pos[1]);
        pos[2] = EditorGUILayout.Toggle("Toggle3", pos[2]);

        EditorGUILayout.EndVertical();
        EditorGUILayout.EndToggleGroup();
        #endregion

        EditorGUILayout.Space(20);

        //��һ�����еķָ���
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();//�������������Space���ֵ�
        GUILayout.Label("-----------------End-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
    }

}
