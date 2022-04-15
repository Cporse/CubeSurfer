using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    private float duration;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (CPlayerController.Instance.cubeS.Count == 0)
            {
                //Time.timeScale = 0;
                Debug.Log(AConsts.GAME_OVER);
            }
            duration += Time.deltaTime;
            if (duration >= .5f)
            {
                if (CPlayerController.Instance.cubeS.Count >= 1)
                {
                    CPlayerController.Instance.cubeS[CPlayerController.Instance.cubeS.Count - 1].transform.parent = null;
                    CPlayerController.Instance.cubeS[CPlayerController.Instance.cubeS.Count - 1].GetComponent<BoxCollider>().isTrigger = true;
                    CPlayerController.Instance.cubeS[CPlayerController.Instance.cubeS.Count - 1].AddComponent<Rigidbody>();

                    CPlayerController.Instance.cubeS.RemoveAt(CPlayerController.Instance.cubeS.Count - 1);

                    CameraController.Instance.SetTarget(CPlayerController.Instance.cubeS[CPlayerController.Instance.cubeS.Count - 1].transform, false);

                    CPlayerController.Instance.boxCollider.size = new Vector3(CPlayerController.Instance.boxCollider.size.x, CPlayerController.Instance.boxCollider.size.y - 1, CPlayerController.Instance.boxCollider.size.z);
                    CPlayerController.Instance.boxCollider.center = new Vector3(CPlayerController.Instance.boxCollider.center.x, CPlayerController.Instance.boxCollider.center.y + .5f, CPlayerController.Instance.boxCollider.center.z);
                }
                duration = 0f;

            }
        }
    }

    //END LINE.
}