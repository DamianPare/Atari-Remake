using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isMoving;
    public Vector3 origPos, targetPos;
    public float timeToMove = 0.2f;
    private Animator animationController;
    private Rigidbody2D rb;
    private int bLevel;
    private int mLevel;
    private GameObject block;
    public static Movement instance;
    public bool isAttacking;
    public GameObject pickaxe;
    public Vector3 moveDir;
    public int maxHeight;

    private void Start()
    {
        instance = this;
    }

    private void Awake()
    {
        animationController = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            block = collision.gameObject;
            bLevel = block.GetComponent<Block>().blockLevel;
            if (mLevel >= bLevel)
            {
                Destroy(block);
            }

            else
            {
                targetPos = origPos;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            Attack();
        }

        mLevel = GameManager.instance.miningLevel;

        if (Input.GetKey(KeyCode.W) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.up));
            
        if (Input.GetKey(KeyCode.A) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.left));

        if (Input.GetKey(KeyCode.S) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.down));

        if (Input.GetKey(KeyCode.D) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.right));
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        moveDir = direction;
        animationController.SetFloat("MovementY", direction.y);
        animationController.SetFloat("MovementX", direction.x);
        isMoving = true;
        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    private void Attack()
    {
        pickaxe.SetActive(true);
    }
}
