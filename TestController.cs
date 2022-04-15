using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public static TestController Instance;
    public int firstSize;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void TestControl(int value)
    {
        if (value > firstSize)
        {
            firstSize = value;
        }
        Invoke("GetValue", 0.1f);
    }

    public void GetValue()
    {
        //Debug.Log(firstSize);
        CPlayerController.Instance.firstSize = firstSize;
    }
}