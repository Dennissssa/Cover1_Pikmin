using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] characterPrefabs; // ��ɫԤ��������

    void Start()
    {
        int index = PlayerPrefs.GetInt("SelectedCharacterIndex", -1); // ��ȡѡ��Ľ�ɫ����
        if (index >= 0 && index < characterPrefabs.Length)
        {
            // ����ѡ��Ľ�ɫ
            Instantiate(characterPrefabs[index], Vector3.zero, Quaternion.identity);
        }
    }
}