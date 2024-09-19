using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    [SerializeField] TypingGageManager typingGageManager;
    [SerializeField] LetterSpownManager letterSpownManager;

    [SerializeField, Header("問題文")] Text _qText;
    [SerializeField, Header("答え")] Text _aText;

    [SerializeField] string _answerNumber;
    [SerializeField] string _inputText;
    void Start()
    {
        QuestionNumber();
    }

    void Update()
    {
        _aText.text = _inputText;
        // ゲーム画面の上でマウスをクリックするとエラーが出るのでそれの対処
        if (Input.GetMouseButtonDown(0)) return;

        //テンキーの数字部分か1～9までの数字キーが押されたとき以下の処理
        if (Input.anyKeyDown && char.IsDigit(Input.inputString[0]))
        {
            /*
             * ASCIIコードを比較して数値を求めている
             * 例…3(ASCIIコードだと51) - 0(ASCIIコードだと48) = 3となる
             * 基本的には０が基準なのでほかの数値から0を引けばその数値が求められる
             * 覚えておきたい
            */
            int digit = (int)Input.inputString[0] - '0';
            _inputText += digit;

            // 入力文字数が問題の桁数を超えない場合
            if (_inputText.Length <= _answerNumber.Length)
            {
                // 入力された最後の文字と問題の対応する文字を比較
                int lastIndex = _inputText.Length - 1;
                if (_inputText[lastIndex] != _answerNumber[lastIndex])
                {
                    // 間違っていた場合の処理 
                    Debug.Log("間違っています");

                    // 入力された最後の文字を削除
                    _inputText = _inputText.Remove(lastIndex);
                    _aText.text = _inputText;
                }
            }
            else if (Input.anyKeyDown)
            {
                Debug.Log("数字で入力してください");
            }
        }
        //文字数と内容がすべて一致するか、制限じかんを過ぎたら新しい問題を出す
        if (typingGageManager._timeOver == true)
        {
            QuestionNumber();
            _inputText = "";
            typingGageManager._timerReset = true;
        }
        else if (_inputText.Length == _answerNumber.Length && _inputText == _answerNumber)
        {
            QuestionNumber();
            letterSpownManager?.SpownLetter2(3);
            _inputText = "";
            typingGageManager._timerReset = true;
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
