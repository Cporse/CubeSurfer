using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSize : MonoBehaviour
{
    public int size;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(AConsts.PLYR_TAG))
        {
            TestController.Instance.TestControl(size);
        }
    }
}