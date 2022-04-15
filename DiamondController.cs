using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class DiamondController : MonoBehaviour
{
    private Transform targetPosition;
    private Rigidbody rigidBody;

    private BCanvasController bCanvasController;
    private ObjectController objectController;

    private void Awake()
    {
        rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.FreezePosition;
    }
    private void Start()
    {
        bCanvasController = BCanvasController.Instance;
        objectController = ObjectController.Instance;

        targetPosition = objectController.TargetPosition.transform;
    }
    private void FixedUpdate()
    {
        transform.DORotate(new Vector3(0, 90, 0), 2f, RotateMode.LocalAxisAdd);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(AConsts.GRND_TAG))
        {
            transform.DOJump(new Vector3(transform.position.x, transform.position.y, transform.position.z), 1f, 1, 1f, false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(AConsts.PLYR_TAG))
        {
            BCanvasController.Instance.DiamondCounter();

            //Camera.main.WorldToScreenPoint(transform.position)); Pozisyonu ekran pozisyonunaçevir
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

            //Elmasý canvasýn çocuðu yap
            this.transform.parent = bCanvasController.transform;

            //Elmasýn layer'ýný "UI" yap
            this.gameObject.layer = LayerMask.NameToLayer("UI");

            transform.localScale = new Vector3(25f, 25f, 25f);

            //Ekran Pozisyonunu ortho camerada çevirip elmasýn pozisyonuna ver
            transform.position = objectController.UiCamera.ScreenToWorldPoint(screenPoint);

            Invoke("VisibleFalse", 3.02f);

            transform.DOMove(targetPosition.position, 3f);
        }
    }
    private void VisibleFalse()
    {
        gameObject.SetActive(false);
    }
}