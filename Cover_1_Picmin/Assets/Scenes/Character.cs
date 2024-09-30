using UnityEngine;

public class Character : MonoBehaviour
{
    private bool isSelected = false;
    public AudioClip selectionMusic; // ��ɫ��Ӧ������Ƭ��
    private AudioSource audioSource; // ��ƵԴ

    public GameObject particlePrefab; // ������Ч��Ԥ����
    private GameObject activeParticle; // ��ǰ�����������Ч

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // �����ƵԴ���
        audioSource.clip = selectionMusic; // ������ƵƬ��
    }

    void OnMouseDown()
    {
        ActivateParticleEffect();
    }

    public void Select()
    {
        isSelected = true;
        audioSource.Play(); // ��������
    }

    public void Deselect()
    {
        isSelected = false;
        audioSource.Stop(); // ֹͣ���֣���ѡ��
    }

    void Update()
    {
        if (isSelected)
        {
            float move = Input.GetAxis("Horizontal") * Time.deltaTime;
            transform.position += new Vector3(move, 0, 0); // ֻ�ƶ���ǰѡ�еĽ�ɫ
        }
    }

    void ActivateParticleEffect()
    {
        // ����Ѿ���������Ч�ڲ��ţ���������
        if (activeParticle != null)
        {
            Destroy(activeParticle);
        }

        // ʵ�����µ�������Ч
        activeParticle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        Destroy(activeParticle, 2f); // 2�������������Ч��������Ҫ�޸ģ�
    }
}