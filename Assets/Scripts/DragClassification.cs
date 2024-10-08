using UnityEngine;

public class DragClassification : MonoBehaviour
{
    //�}�E�X�œ���������
    private void OnMouseDrag()
    {
        Vector3 objectScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        Vector3 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);
        transform.position = objectWorldPoint;
    }
}
