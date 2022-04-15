using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;

        CPlayerController.Instance.cubeS[CPlayerController.Instance.cubeS.Count - 1].transform.parent = null;
        CPlayerController.Instance.cubeS.RemoveAt(CPlayerController.Instance.cubeS.Count - 1);

        CameraController.Instance.SetTarget(CPlayerController.Instance.cubeS[CPlayerController.Instance.cubeS.Count - 1].transform, false);

        CPlayerController.Instance.boxCollider.size = new Vector3(CPlayerController.Instance.boxCollider.size.x, CPlayerController.Instance.boxCollider.size.y - 1, CPlayerController.Instance.boxCollider.size.z);
        CPlayerController.Instance.boxCollider.center = new Vector3(CPlayerController.Instance.boxCollider.center.x, CPlayerController.Instance.boxCollider.center.y + .5f, CPlayerController.Instance.boxCollider.center.z);
    }
}