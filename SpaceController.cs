using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(AConsts.PLYR_TAG))
        {
            Debug.Log("Collision durumu tetiklendi.\n" + AConsts.GAME_OVER);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}