using UnityEngine;

public class LetterSpownManager : MonoBehaviour
{
    [SerializeField] GameObject[] letters;
    [SerializeField] GameObject nowLetters;
    [SerializeField] GameObject nextLetters;
    public int clickCount = 0;
    public int spownLetter = 0;
    public int test;
    public int test2;

    void Start()
    {
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
    }

    /// <summary>
    /// 手紙をスポーンさせるメソッド(スタンプの数を増やす）
    /// </summary>
    public void SpownLetter(int stp)
    {
        int test = Random.Range(stp, letters.Length);
        int test2 = Random.Range(stp, letters.Length);
        Instantiate(letters[test]);
    }

    public void NextLetter(GameObject letter)
    {

    }

    /// <summary>
    /// スタンプを押すだけ
    /// </summary>
    public void Stamp()
    {
        clickCount++;
    }
}
