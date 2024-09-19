using UnityEngine;

public class ClickGameManager : MonoBehaviour
{
    [SerializeField] GameObject[] stamps;
    [SerializeField] SpriteRenderer[] spriteRenderers;
    [SerializeField] LetterSpownManager letterSpownManager;

    float dragTimer = 0;
    int previousClicCount = 0;
    public bool stampOK;
    public bool isDrag;
    Vector3 offset;

    public void Start()
    {
        letterSpownManager = FindFirstObjectByType<LetterSpownManager>();
        spriteRenderers = new SpriteRenderer[stamps.Length];
        for (int i = 0; i < stamps.Length; i++)
        {
            spriteRenderers[i] = stamps[i].GetComponent<SpriteRenderer>();
        }
    }

    public void Update()
    {
        // clickCountが変化したタイミングでのみ処理を実行
        if (letterSpownManager.clickCount != previousClicCount)
        {
            if (letterSpownManager.clickCount == stamps.Length)
            {
                stampOK = true;
                spriteRenderers[letterSpownManager.clickCount - 1].color = Color.red;
            }
            else if (letterSpownManager.clickCount > 0 && letterSpownManager.clickCount <= spriteRenderers.Length)
            {
                spriteRenderers[letterSpownManager.clickCount - 1].color = Color.red;
            }

            if (stampOK && letterSpownManager.clickCount > stamps.Length)
            {
                LetterDestroy();
                stampOK = false;
            }
            previousClicCount = letterSpownManager.clickCount;
        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        if (isDrag && letterSpownManager.clickCount == stamps.Length && collision.gameObject.tag == ("kuti"))
        {
            LetterDestroy();
        }
    }

    public void LetterDestroy()
    {
        Destroy(this.gameObject);
        letterSpownManager.SpownLetter();
        letterSpownManager.clickCount = 0;
    }


    public void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePos;
    }

    public void OnMouseDrag()
    {

        dragTimer += Time.deltaTime;
        if (dragTimer > 0.1f)
        {
            isDrag = false;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos + offset;
        }
    }

    public void OnMouseUp()
    {
        isDrag = true;
    }


}
