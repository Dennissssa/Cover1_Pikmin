using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public string targetTag = "Target"; // Ŀ������ı�ǩ
    public string npcTag = "NPC"; // NPC �ı�ǩ
    public TextMeshProUGUI counterText; // TextMeshPro �������ı�
    public TextMeshProUGUI timerText; // TextMeshPro ��ʱ���ı�
    private int count = 0; // �غϼ���
    private const int targetCount = 5; // Ŀ������
    private float countdownTime = 60f; // ����ʱ��ʼʱ��

    private void Start()
    {
        // ��ʼ���������ı�
        UpdateCounterText();
        UpdateTimerText();
    }

    private void Update()
    {
        // ÿ֡����غ�
        CheckOverlap();
        UpdateTimer(); // ���¼�ʱ��
    }

    private void CheckOverlap()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag(npcTag); // �������� NPC
        count = 0; // ���ü���

        foreach (var npc in npcs)
        {
            // ��������Ŀ��
            GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
            foreach (var target in targets)
            {
                // ʹ�� Collider ��ײ���
                if (AreColliding(npc, target))
                {
                    count++;
                }
            }
        }

        // ���¼������ı�
        UpdateCounterText();

        // ����Ƿ�ﵽ 5/5
        if (count >= targetCount)
        {
            SceneManager.LoadScene("NextScene"); // �л��ɹ�����
        }
    }

    private bool AreColliding(GameObject npc, GameObject target)
    {
        Collider npcCollider = npc.GetComponent<Collider>();
        Collider targetCollider = target.GetComponent<Collider>();

        if (npcCollider != null && targetCollider != null)
        {
            // ����Ƿ��ص�
            return npcCollider.bounds.Intersects(targetCollider.bounds);
        }
        return false;
    }

    private void UpdateCounterText()
    {
        // ���¼������ı�
        counterText.text = $"Count: {count}/{targetCount}"; // ��ʾ��ǰ����
    }

    private void UpdateTimer()
    {
        // ���ٵ���ʱʱ��
        countdownTime -= Time.deltaTime;

        // ���¼�ʱ���ı�
        UpdateTimerText();

        // ����ʱ���Ƿ񵽴� 0
        if (countdownTime <= 0)
        {
            SceneManager.LoadScene("FailureScene"); // �л�ʧ�ܳ���
        }
    }

    private void UpdateTimerText()
    {
        // ���¼�ʱ���ı�
        timerText.text = $"Time: {Mathf.Ceil(countdownTime)}"; // ����ȡ����ʾ����
    }
}