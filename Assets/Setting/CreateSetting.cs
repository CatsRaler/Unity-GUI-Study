using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultCreateSetting", menuName = "ScriptableObjects/CreateSetting", order = 1)]
public class CreateSetting : ScriptableObject
{
    //����prefab
    public GameObject m_cubePrefab;

    //�������
    public Material m_material;

    //��������λ��
    public Vector3 m_createPos;

}
