using UnityEngine;
using UnityEngine.AI;

public class NPCContro : MonoBehaviour
{
    public float followDistance = 5f; // �������
    public float speed = 3.5f; // NPC �����ٶ�
    public string targetTag = "Target"; // �ض�����ı�ǩ

    private Transform player; // ���ǵ� Transform
    private NavMeshAgent agent; // ��������
    private bool isFollowing = true; // ����״̬

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // ��������
        agent.speed = speed; // ���õ���������ٶ�
    }

    void Update()
    {
        if (isFollowing)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // ��� NPC �Ƿ���ָ���ĸ��������
            if (distanceToPlayer < followDistance)
            {
                // ��������
                agent.SetDestination(player.position);
            }
            else
            {
                agent.ResetPath(); // ����������룬ֹͣ�ƶ�
            }

            // ����Ƿ������ض���ǩ������
            if (IsTouchingTarget())
            {
                agent.ResetPath(); // ֹͣ�ƶ�
                isFollowing = false; // ����Ϊ���ٸ���
                Debug.Log("NPC reached the target."); // ������Ϣ
            }
        }
    }

    private bool IsTouchingTarget()
    {
        // ʹ���������Ƿ������ض���ǩ������
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                return true; // �����ײ��ı�ǩƥ�䣬���� true
            }
        }
        return false; // δ�ҵ�ƥ��ı�ǩ
    }

    private void OnDrawGizmos()
    {
        // �ڳ�����ͼ����ʾ��ⷶΧ
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f); // ���뾶
    }
}