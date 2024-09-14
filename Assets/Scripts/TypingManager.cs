using System;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    [SerializeField, Header("問題文")] Text _qText;
    //[SerializeField, Header("答え")] Text _aText;

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
                    //入力したKeyCode.Alphaの内部の値から
                    //KeyCode.Alpha0の数を引いて余計な部分（Alphaの文字）を消して代入している
                    //5を入力した場合…KeyCode.Alpha5(53) - KeyCode.Alpha0(48) = 5!!!!!
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
    /// ランダムに数字を生成し、問題文に出す
    /// </summary>
    public void QuestionNumber()
    {
        _answerNumber = UnityEngine.Random.Range(0, 1000000).ToString("D6");
        _qText.text = _answerNumber;
    }
}
