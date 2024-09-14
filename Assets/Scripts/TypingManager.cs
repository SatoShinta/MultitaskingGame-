using System;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    [SerializeField, Header("��蕶")] Text _qText;
    //[SerializeField, Header("����")] Text _aText;

    [SerializeField] string _answerNumber;
    [SerializeField] string _inputText;
    void Start()
    {
        _inputText = "";
        QuestionNumber();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key) && key >= KeyCode.Alpha0 && key <= KeyCode.Alpha9)
                {                                       
                    //���͂���KeyCode.Alpha�̓����̒l����
                    //KeyCode.Alpha0�̐��������ė]�v�ȕ����iAlpha�̕����j�������đ�����Ă���
                    //5����͂����ꍇ�cKeyCode.Alpha5(53) - KeyCode.Alpha0(48) = 5!!!!!
                    int digit = (int)key - (int)KeyCode.Alpha0;
                    _inputText += digit;
                    Debug.Log(_inputText);
                }
            }
            if (_inputText == _answerNumber)
            {
                QuestionNumber();
                _inputText = "";
            }
        }
    }

    /// <summary>
    /// �����_���ɐ����𐶐����A��蕶�ɏo��
    /// </summary>
    public void QuestionNumber()
    {
        _answerNumber = UnityEngine.Random.Range(0, 1000000).ToString("D6");
        _qText.text = _answerNumber;
    }
}
