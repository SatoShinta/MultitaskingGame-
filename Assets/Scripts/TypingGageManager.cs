using UnityEngine;
using UnityEngine.UI;

public class TypingGageManager : MonoBehaviour
{
    [SerializeField] GameObject _backGauge;
    [SerializeField] GameObject _timerGauge;

    [SerializeField, Header("制限時間")] float _timerLimit = 1f; // 1単位のゲージを減らすのにかかる時間 (秒)
    [SerializeField] Gradient _gradient; //色のグラデーションを変更してくれるやつ

    private float _timer;
    public bool _gameStart;
    public bool _timerReset;
    public bool _timeOver;
    Image _gaugeImage;

    void Start()
    {
        // _timerGaugeの初期幅を_backGaugeの幅に合わせる
        _timerGauge.GetComponent<RectTransform>().sizeDelta = _backGauge.GetComponent<RectTransform>().sizeDelta;
        // 初期の色を設定（白）
        _gaugeImage = _timerGauge.GetComponent<Image>();
        _gaugeImage.color = _gradient.Evaluate(0);
    }

    void Update()
    {
        if (_gameStart)
        {
            _timer += Time.deltaTime;
            Debug.Log(_timer);

            // _timerGaugeの幅を計算
            float gaugeWidth = Mathf.Max(0, _backGauge.GetComponent<RectTransform>().sizeDelta.x - (_timer / _timerLimit * _backGauge.GetComponent<RectTransform>().sizeDelta.x));

            // _timerGaugeの幅を更新
            _timerGauge.GetComponent<RectTransform>().sizeDelta = new Vector2(gaugeWidth, _timerGauge.GetComponent<RectTransform>().sizeDelta.y);

            // 制限時間に近づくにつれて色が変化していくようにした
            _gaugeImage.color = _gradient.Evaluate(_timer / _timerLimit);
            if (_timer >= _timerLimit)
            {
                _timeOver = true;
            }

            if (_timerReset == true)
            {
                _timerReset = false;
                _timeOver = false;
                _timer = 0;
            }
        }
       
    }
}