using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class CPlayerController : MonoBehaviour
{
    public static CPlayerController Instance;

    public List<GameObject> cubeS = new List<GameObject>();
    public BoxCollider boxCollider;
    public int firstSize;

    [SerializeField] private Transform parent;
    [SerializeField] private GameObject ground;

    private GameObject turnPoint;
    private Rigidbody rigidBody;
    private bool state = true;

    private void Awake()
    {
        //PlayerPrefs.SetInt("LevelIndex", 1);
        //Debug.Log(LevelManager.Instance.LevelIndex);
        if (Instance == null)
            Instance = this;

        rigidBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(AConsts.CUBE_TAG))
        {
            other.gameObject.AddComponent<Rigidbody>();

            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

            CameraController.Instance.SetTarget(other.gameObject.transform, true);
            other.tag = "Player";
            other.GetComponent<Collider>().isTrigger = false;

            cubeS.Add(other.gameObject);

            transform.position = new Vector3(transform.position.x, transform.position.y + 1.01f, transform.position.z);
            other.transform.SetParent(parent);
            other.transform.position = new Vector3(parent.position.x, other.transform.position.y, parent.position.z);

            boxCollider.size = new Vector3(boxCollider.size.x, boxCollider.size.y + 1, boxCollider.size.z);
            boxCollider.center = new Vector3(boxCollider.center.x, boxCollider.center.y - .5f, boxCollider.center.z);

            BCanvasController.Instance.ScoreCounter();
        }
        if (other.gameObject.CompareTag(AConsts.WALL_TAG))
        {
            if (state)
            {
                StartCoroutine(CoroutineSize());
                state = false;
            }
        }
        if (other.gameObject.CompareTag(AConsts.LEFT_TAG))
        {
            other.gameObject.transform.parent = null;
            LevelManager.Instance.LevelGO.transform.parent = other.transform;
            //ground.transform.parent = other.transform;
            turnPoint = GameObject.FindWithTag(AConsts.LEFT_TAG);
            turnPoint.transform.parent = other.transform;

            other.transform.DORotate(new Vector3(0, 90, 0), 0.2f);
            Invoke("DoGroundNull", 1f);

        }
        if (other.gameObject.CompareTag(AConsts.RiGHT_TAG))
        {
            other.gameObject.transform.parent = null;
            LevelManager.Instance.LevelGO.transform.parent = other.transform;
            //ground.transform.parent = other.transform;
            turnPoint = GameObject.FindWithTag(AConsts.LEFT_TAG);
            turnPoint.transform.parent = other.transform;

            other.transform.DORotate(new Vector3(0, 0, 0), 0.2f);
            Invoke("DoGroundNull", 1f);
        }
    }

    IEnumerator CoroutineSize()
    {
        yield return new WaitForSeconds(.1f);
        if (cubeS.Count >= firstSize)
        {
            for (int i = 1; i <= firstSize; i++)
            {
                //Destroy(cubeS[cubeS.Count - 1], 0.1f);
                cubeS[cubeS.Count - 1].transform.parent = null;
                cubeS.RemoveAt(cubeS.Count - 1);

                CameraController.Instance.SetTarget(cubeS[cubeS.Count - 1].transform, false);

                boxCollider.size = new Vector3(boxCollider.size.x, boxCollider.size.y - 1, boxCollider.size.z);
                boxCollider.center = new Vector3(boxCollider.center.x, boxCollider.center.y + .5f, boxCollider.center.z);
            }
        }
        else
        {
            Debug.Log(AConsts.GAME_OVER);
        }
    }
    private void DoGroundNull()
    {
        LevelManager.Instance.LevelGO.transform.parent = null;
        turnPoint.transform.parent = null;
    }
    public void StartMovement()
    {
        rigidBody.isKinematic = false;
    }

    //END LINE.
}