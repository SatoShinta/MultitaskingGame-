using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    [SerializeField, Header("��蕶")] Text _qText;
    [SerializeField, Header("����")] Text _aText;

    [SerializeField] string _answerNumber;
    [SerializeField] string _inputText;
    void Start()
    {
        QuestionNumber();
    }

    void Update()
    {
        _aText.text = _inputText;

        //�e���L�[�̐���������1�`9�܂ł̐����L�[�������ꂽ�Ƃ��ȉ��̏���
        if (Input.anyKeyDown && char.IsDigit(Input.inputString[0]))
        {
            /*
             * ASCII�R�[�h���r���Đ��l�����߂Ă���
             * ��c3(ASCII�R�[�h����51) - 0(ASCII�R�[�h����48) = 3�ƂȂ�
             * ��{�I�ɂ͂O����Ȃ̂łق��̐��l����0�������΂��̐��l�����߂���
             * �o���Ă�������
            */
            int digit = (int)Input.inputString[0] - '0';
            _inputText += digit;

            // ���͕����������̌����𒴂��Ȃ��ꍇ
            if (_inputText.Length <= _answerNumber.Length)
            {
                // ���͂��ꂽ�Ō�̕����Ɩ��̑Ή����镶�����r
                int lastIndex = _inputText.Length - 1;
                if (_inputText[lastIndex] != _answerNumber[lastIndex])
                {
                    // �Ԉ���Ă����ꍇ�̏��� 
                    Debug.Log("�Ԉ���Ă��܂�");

                    // ���͂��ꂽ�Ō�̕������폜
                    _inputText = _inputText.Remove(lastIndex);
                    _aText.text = _inputText;
                }
            }

            //�������Ɠ��e�����ׂĈ�v������
            if (_inputText.Length == _answerNumber.Length &&_inputText == _answerNumber)
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
