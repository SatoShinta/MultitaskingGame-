using UnityEngine;

public class LetterSpownManager : MonoBehaviour
{
    [SerializeField] GameObject[] letters;

    void Start()
    {
        int test = Random.Range(0, letters.Length);
        Instantiate(letters[test]);
    }

    void Update()
    {

    }
}
