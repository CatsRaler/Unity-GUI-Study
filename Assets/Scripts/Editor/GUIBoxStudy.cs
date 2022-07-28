using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class GUIBoxStudy : EditorWindow
{   
    //1.带渐隐渐显效果的折叠块
    #region BeginFadeGroup
    AnimBool m_ShowExtraFields;
    string m_String;
    Color m_Color = Color.white;
    int m_Number = 0;
    #endregion

    //2.三角按钮折叠块
    #region Foldout
    bool showFoldout = true;
    #endregion

    //5.滚动界面
    #region BeginScrollView
    Vector2 scrollPos;
    string m_String2;
    string m_content = "";
    string t = "--------------ScrollView Test！--------------\n";
    #endregion

    //6.勾选界面
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
        m_ShowExtraFields = new AnimBool(true);//创建一个AnimBool对象，true是默认显示。
        m_ShowExtraFields.valueChanged.AddListener(Repaint);//监听重绘
        #endregion
    }

    private void OnGUI()
    {
        //居中显示
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("-----------------1-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        //1.带渐隐渐显效果的折叠块
        #region BeginFadeGroup
        m_ShowExtraFields.target = EditorGUILayout.ToggleLeft("显示折叠内容", m_ShowExtraFields.target);//选择框在左边的开关
        //m_ShowExtraFields.target = EditorGUILayout.Toggle("显示折叠内容", m_ShowExtraFields.target);//选择框在右边的开关
        //创建带渐显动画的折叠块 返回值bool，参数float
        if (EditorGUILayout.BeginFadeGroup(m_ShowExtraFields.faded))
        {
            EditorGUI.indentLevel++;//缩进深度增加，以下的GUI会增加缩进

            EditorGUILayout.LabelField("Test Label Content");//标签栏

            EditorGUILayout.PrefixLabel("Color");//前缀标签
            m_Color = EditorGUILayout.ColorField(m_Color);

            EditorGUILayout.PrefixLabel("Text");
            m_String = EditorGUILayout.TextField(m_String);//文本框

            EditorGUILayout.PrefixLabel("Number");
            m_Number = EditorGUILayout.IntSlider(m_Number, 0, 10);//Int滑动条

            EditorGUI.indentLevel--;//缩进深度减少，以下的GUI会减少缩进
        }
        EditorGUILayout.EndFadeGroup();
        #endregion

        //两个区块内容间隔
        EditorGUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("-----------------2-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        //2.三角按钮折叠块
        #region Foldout
        showFoldout = EditorGUILayout.Foldout(showFoldout, "折叠子物体：");
        if (showFoldout)
        {
            EditorGUI.indentLevel+= 2;
            EditorGUILayout.LabelField("折叠块内容1");
            EditorGUILayout.LabelField("折叠块内容2");
            EditorGUILayout.LabelField("折叠块内容3");
            EditorGUI.indentLevel -= 2;
        }
        #endregion

        EditorGUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("-----------------3-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        //3.水平布局以及按钮
        #region BeginHorizontal 水平布局
        Rect r = EditorGUILayout.BeginHorizontal("Button");
        if (GUI.Button(r, GUIContent.none)) {
            Debug.Log("Go here");
        }
        GUILayout.Label("I'm inside the button");
        GUILayout.Label("So am I");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("测试文本");
        if (GUILayout.Button("弹窗按钮"))
        {
            EditorUtility.DisplayDialog("Dialog Label", "This is a test dialog, press 'OK' to continue!", "OK");
        }
        if (GUILayout.Button("Debug按钮"))
        {
            Debug.Log("GUILayout的按钮");
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("-----------------4-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        //4.垂直布局以及按钮
        #region BeginVertical 垂直布局
        EditorGUILayout.BeginVertical();
        GUILayout.Label("测试文本");
        if (GUILayout.Button("弹窗按钮"))
        {
            EditorUtility.DisplayDialog("Dialog Label", "This is a test dialog, press 'OK' to continue!", "OK");
        }
        if (GUILayout.Button("Debug按钮"))
        {
            Debug.Log("GUILayout的按钮");
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


        //5.滚动界面
        #region BeginScrollView
        //需要将返回值赋值到临时变量，不然拖不动
        //可以添加GUILayoutOption参数控制大小
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(200), GUILayout.Height(100));
        GUILayout.Label(m_content);
        EditorGUILayout.EndScrollView();

        EditorGUILayout.PrefixLabel("Test Text String");
        m_String2 = EditorGUILayout.TextField(m_String2);//文本框

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("添加内容"))
            m_content += m_String2 + "\n";
        if (GUILayout.Button("清空内容"))
            m_content = "";
        EditorGUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("-----------------6-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        //6.勾选界面
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

        //画一个居中的分割线
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();//这个玩意是拿来Space均分的
        GUILayout.Label("-----------------End-----------------");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
    }

}
