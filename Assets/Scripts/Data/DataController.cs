using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    //ʵ��
    private static DataController m_Instance;
    public static DataController Instance => m_Instance;

    //��������
    public enum DataType 
    { 
        typeA,
        typeB,
        typeC
    }

    //Handler���壬Action�������Ϣ����
    public event Action<string> OnTypeAHandler;
    public event Action<string> OnTypeBHandler;
    public event Action<string> OnTypeCHandler;

    private void Awake()
    {
        if (m_Instance != null && m_Instance != this) Destroy(this.gameObject);
        else m_Instance = this;
    }

    public void OnDataReceived(DataType dataType, String dataString) {
        if (dataString == null) {
            return;
        }
        switch (dataType) 
        {
            case DataType.typeA:
                UnityEngine.Debug.Log("get data A!");
                OnTypeAHandler?.Invoke(dataString);
                break;
            case DataType.typeB:
                UnityEngine.Debug.Log("get data B!");
                OnTypeBHandler?.Invoke(dataString);
                break;
            case DataType.typeC:
                UnityEngine.Debug.Log("get data C!");
                OnTypeCHandler?.Invoke(dataString);
                break;
            default:
                break;
        }
    }


}
