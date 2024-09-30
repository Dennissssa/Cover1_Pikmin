using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
    
    public GameObject[] npcPrefabs; // NPCԤ��������
    public int npcCount = 10; // NPC����
    public Transform spawnArea; // NPC��������

    void Start()
    {
        // ��ȡѡ��Ľ�ɫ����
        int index = PlayerPrefs.GetInt("SelectedCharacterIndex", -1);
        
        {
            
            SpawnNPCs(); // ���� NPC
        }
    }

    void SpawnNPCs()
    {
        for (int i = 0; i < npcCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2),
                0,
                Random.Range(spawnArea.position.z - spawnArea.localScale.z / 2, spawnArea.position.z + spawnArea.localScale.z / 2)
            );

            // ���ѡ�� NPC Ԥ����
            int npcIndex = Random.Range(0, npcPrefabs.Length);
            Instantiate(npcPrefabs[npcIndex], randomPosition, Quaternion.identity);
        }
    }
}