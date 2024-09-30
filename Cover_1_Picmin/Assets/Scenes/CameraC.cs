using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f; // ��������ƶ��ٶ�

    void Update()
    {
        // ��ȡ����
        float moveHorizontal = Input.GetAxis("Horizontal"); // A��D��
        float moveVertical = Input.GetAxis("Vertical"); // W��S��

        // �����ƶ�����ֻ�� X �� Z ����
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed * Time.deltaTime;

        // �ƶ����
        transform.Translate(movement, Space.World);
    }
}