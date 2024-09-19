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
    /// �莆���X�|�[�������郁�\�b�h
    /// </summary>
    public void SpownLetter()
    {
        int test = Random.Range(0, letters.Length);
        Instantiate(letters[test]);
    }

    /// <summary>
    /// �莆���X�|�[�������郁�\�b�h(�X�^���v�̐��𑝂₷�j
    /// </summary>
    public void SpownLetter(int stp)
    {
        int test = Random.Range(stp, letters.Length);
        Instantiate(letters[test]);
    }

    /// <summary>
    /// �X�^���v����������
    /// </summary>
    public void Stamp()
    {
        clickCount++;
    }
}
