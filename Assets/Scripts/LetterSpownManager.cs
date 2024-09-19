using UnityEngine;

public class LetterSpownManager : MonoBehaviour
{
    [SerializeField] GameObject[] letters;
    [SerializeField] GameObject nowLetters;
    [SerializeField] GameObject nextLetters;
    [SerializeField, Header("次の手紙")] GameObject NLP;
    [SerializeField] Sprite[] letterSprites;
    SpriteRenderer letterSpriterenderer;
    public int clickCount = 0;
    public int spownLetter = 0;
    public int test;
    public int test2;

    void Start()
    {
        letterSpriterenderer = NLP.GetComponent<SpriteRenderer>();
        SpownLetter();
    }

    public void Update()
    {
    }


    /// <summary>
    /// 手紙をスポーンさせるメソッド
    /// </summary>
    public void SpownLetter()
    {
        if (nowLetters == null)
        {
            test = Random.Range(0, letters.Length);
            nowLetters = letters[test];
            Instantiate(nowLetters);
        }
        else
        {
            nowLetters = nextLetters;
            Instantiate(nowLetters);
        }
        test2 = Random.Range(0, letters.Length);
        nextLetters = letters[test2];
        letterSpriterenderer.sprite = letterSprites[test2];
    }

    /// <summary>
    /// 手紙をスポーンさせるメソッド(スタンプの数を増やす）
    /// </summary>
    public void SpownLetter2(int stp)
    {
        Debug.Log("aaaaa");
        if (test2 <= 2)
        {
            test2 = Random.Range(stp, letters.Length);
            nextLetters = letters[test2];
            letterSpriterenderer.sprite = letterSprites[test2];
        }
        //test2 = Random.Range(stp, letters.Length);
        //nextLetters = letters[test2];

        //letterSpriterenderer.sprite = letterSprites[test2];
    }


    /// <summary>
    /// スタンプを押すだけ
    /// </summary>
    public void Stamp()
    {
        clickCount++;
    }
}
