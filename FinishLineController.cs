using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLineController : MonoBehaviour
{
    public static FinishLineController Instance;

    private Animator playerAnimator;
    private Rigidbody rigidBody;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        rigidBody = CPlayerController.Instance.gameObject.GetComponent<Rigidbody>();
        playerAnimator = FindObjectOfType<CPlayerController>().transform.GetChild(0).GetChild(0).GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(AConsts.PLYR_TAG))
        {
            GetComponent<BoxCollider>().enabled = false;

            rigidBody.isKinematic = true;
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, rigidBody.velocity.z);

            playerAnimator.SetBool("isFinished", true);

            Debug.Log(AConsts.GAME_WIN);
            LevelManager.Instance.LevelIndex++;

            BCanvasController.Instance.ActiviteNextButton();
            //Sahneyi yeniden y�kle.
        }
    }

    //END LINE.
}