using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleObject : MonoBehaviour
{
    public bool isDrag;
    public bool isUsed;
    Rigidbody2D rb;

    public int index;

    public float EndTime;
    public SpriteRenderer spriteRenderer;

    public GameManager gameManager;


    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isDrag = false;
        isUsed = false;
        rb.simulated = false;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed)
            return;

        if(isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float leftBorder = -2.0f + transform.localScale.x / 2f;
            float rightBorder = 2.0f - transform.localScale.x / 2f;

            if(mousePos.x < leftBorder) mousePos.x = leftBorder;
            if(mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 0.7f;
            mousePos.z = 0;
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);
        }

        if (Input.GetMouseButtonDown(0)) Drag();
        if (Input.GetMouseButtonUp(0)) Drop();
    }

    void Drag()
    {
        isDrag = true;
        rb.simulated = false;
    }
    
    void Drop()
    {
        isDrag = false;
        isUsed = true;
        rb.simulated = true;

        gameManager.GenObject();
    }

    public void Used()
    {
        isDrag = false;
        isUsed = true;
        rb.simulated = true;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "EndLine")
        {
            EndTime += Time.deltaTime;
            if(EndTime > 1f)
            {
                spriteRenderer.color = new Color(0.9f, 0.2f, 0.2f);
            }
            if(EndTime > 3f)
            {
                gameManager.EndGame();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "EndLine")
        {
            EndTime = 0.0f;
            spriteRenderer.color = Color.white;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (index >= 7)
            return;

        if(collision.gameObject.tag == "fruit")
        {
            circleObject temp = collision.gameObject.GetComponent<circleObject>();

            if(temp.index == index)
            {
                if(gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
                {
                    gameManager.MergeObject(index, gameObject.transform.position);

                    Destroy(temp.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}
