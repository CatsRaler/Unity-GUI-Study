using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultCreateSetting", menuName = "ScriptableObjects/CreateSetting", order = 1)]
public class CreateSetting : ScriptableObject
{
    //物体prefab
    public GameObject m_cubePrefab;

    //物体材质
    public Material m_material;

    //物体生成位置
    public Vector3 m_createPos;

    //随机生成物体范围
    public float x_Range;
    public float y_Range;
    public float z_Range;

}
