using UnityEngine;

public class LetterSpownManager : MonoBehaviour
{
    [SerializeField] GameObject[] letters;

    public int clickCount = 0;

    void Start()
    {
        SpownLetter();
    }


    /// <summary>
    /// 手紙をスポーンさせるメソッド
    /// </summary>
    public void SpownLetter()
    {
        int test = Random.Range(0, letters.Length);
        Instantiate(letters[test]);
    }

    /// <summary>
    /// スタンプを押すだけ
    /// </summary>
    public void Stamp()
    {
        clickCount++;
    }
}
