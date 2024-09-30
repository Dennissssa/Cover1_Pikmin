using UnityEngine;
using UnityEngine.AI;

public class TestNavAgent : MonoBehaviour
{
    public NavMeshAgent agent; // ��������
    public GameObject cylinderPrefab; // Բ����Ԥ����
    private GameObject currentCylinder; // ��ǰ���ɵ�Բ����

    void Update()
    {
        // ������������
        if (Input.GetMouseButtonDown(0))
        {
            // ��ȡ���λ�ò�ת��Ϊ��������
            Vector2 mousePosition = Input.mousePosition;
            Ray worldRay = Camera.main.ScreenPointToRay(mousePosition);

            // ���߼��
            if (Physics.Raycast(worldRay, out RaycastHit hitInfo))
            {
                // �������Բ���壬ɾ����
                if (currentCylinder != null)
                {
                    Destroy(currentCylinder);
                }

                // �����µ�Բ���岢����λ��
                currentCylinder = Instantiate(cylinderPrefab, hitInfo.point + Vector3.up * 0.5f, Quaternion.identity);

                // ���õ��������Ŀ��λ��
                agent.SetDestination(hitInfo.point);

                // ��ʼЭ�̵ȴ�����
                StartCoroutine(WaitForArrival());
            }
        }
    }

    private System.Collections.IEnumerator WaitForArrival()
    {
        // �ȴ�ֱ��������Ŀ��λ��
        while (true)
        {
            // ����ɫ�Ƿ�ӽ�Ŀ��λ��
            if (Vector3.Distance(transform.position, agent.destination) < 0.1f && !agent.pathPending)
            {
                // ɾ����ǰԲ����
                if (currentCylinder != null)
                {
                    Destroy(currentCylinder);
                    currentCylinder = null; // �������
                }
                yield break; // �˳�Э��
            }
            yield return null; // �ȴ���һ֡
        }
    }
}