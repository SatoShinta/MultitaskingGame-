using UnityEngine;

public class LetterSpownManager : MonoBehaviour
{
    [SerializeField] GameObject[] letters;

    void Start()
    {
        SpownLetter();
    }

    void Update()
    {

    }

    public void SpownLetter()
    {
        int test = Random.Range(0, letters.Length);
        Instantiate(letters[test]);
    }
}
