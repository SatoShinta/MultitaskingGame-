using UnityEngine;

public class ClickGameManager : MonoBehaviour
{
    [SerializeField] GameObject[] stamps;
    [SerializeField] SpriteRenderer[] spriteRenderers;
    public LetterSpownManager letterSpownManager;

    public int clickCount = 0;

    public void Start()
    {
        letterSpownManager = FindFirstObjectByType<LetterSpownManager>();
        spriteRenderers = new SpriteRenderer[stamps.Length];
        for (int i = 0; i < stamps.Length; i++)
        {
            spriteRenderers[i] = stamps[i].GetComponent<SpriteRenderer>();
        }
    }

    public void OnMouseDown()
    {
        if (clickCount < stamps.Length)
        {
            clickCount++;
            spriteRenderers[clickCount - 1].color = Color.red;
        }
        else 
        {
            Destroy(this.gameObject);
            letterSpownManager.SpownLetter();
            clickCount = 0;
        }
        Debug.Log("clickCount: " + clickCount); // デバッグ用
    }
}
