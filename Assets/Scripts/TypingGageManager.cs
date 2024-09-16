using UnityEngine;
using UnityEngine.UI;

public class TypingGageManager : MonoBehaviour
{
    [SerializeField] GameObject _backGauge;
    [SerializeField] GameObject _timerGauge;

    [SerializeField, Header("��������")] float _timerLimit = 1f; // 1�P�ʂ̃Q�[�W�����炷�̂ɂ����鎞�� (�b)
    [SerializeField] Gradient _gradient; //�F�̃O���f�[�V������ύX���Ă������

    private float _timer;
    public bool _gameStart;
    public bool _timerReset;
    public bool _timeOver;
    Image _gaugeImage;

    void Start()
    {
        // _timerGauge�̏�������_backGauge�̕��ɍ��킹��
        _timerGauge.GetComponent<RectTransform>().sizeDelta = _backGauge.GetComponent<RectTransform>().sizeDelta;
        // �����̐F��ݒ�i���j
        _gaugeImage = _timerGauge.GetComponent<Image>();
        _gaugeImage.color = _gradient.Evaluate(0);
    }

    void Update()
    {
        if (_gameStart)
        {
            _timer += Time.deltaTime;
            Debug.Log(_timer);

            // _timerGauge�̕����v�Z
            float gaugeWidth = Mathf.Max(0, _backGauge.GetComponent<RectTransform>().sizeDelta.x - (_timer / _timerLimit * _backGauge.GetComponent<RectTransform>().sizeDelta.x));

            // _timerGauge�̕����X�V
            _timerGauge.GetComponent<RectTransform>().sizeDelta = new Vector2(gaugeWidth, _timerGauge.GetComponent<RectTransform>().sizeDelta.y);

            // �������Ԃɋ߂Â��ɂ�ĐF���ω����Ă����悤�ɂ���
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