using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] public TMP_Text textDataA;
    [SerializeField] public TMP_Text textDataB;
    [SerializeField] public TMP_Text textDataC;

    private int cntA;
    private int cntB;
    private int cntC;

    private void Start()
    {
        cntA = cntB = cntC = 0;
        DataController.Instance.OnTypeAHandler += HandlerDataA;
        DataController.Instance.OnTypeBHandler += HandlerDataB;
        DataController.Instance.OnTypeCHandler += HandlerDataC;
    }

    private void HandlerDataA(string dataString) 
    {
        textDataA.text = "DataA Count:" + cntA++ + "/" + dataString;
    }

    private void HandlerDataB(string dataString)
    {
        textDataB.text = "DataB Count:" + cntB++ + "/" + dataString;
    }

    private void HandlerDataC(string dataString)
    {
        textDataC.text = "DataC Count:" + cntC++ + "/" + dataString;
    }

    private void OnDestroy()
    {
        DataController.Instance.OnTypeAHandler -= HandlerDataA;
        DataController.Instance.OnTypeBHandler -= HandlerDataB;
        DataController.Instance.OnTypeCHandler -= HandlerDataC;
    }
}
