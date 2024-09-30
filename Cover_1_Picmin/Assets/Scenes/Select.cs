using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSelection : MonoBehaviour
{
    public Camera mainCamera; // ������ͷ
    public List<Character> characters; // ��ɫ�б�
    public CinemachineVirtualCamera[] characterCameras; // ��ɫ��Ӧ���������

    private Character selectedCharacter; // ��ǰѡ��Ľ�ɫ

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ������
        {
            SelectCharacter();
        }
        else if (Input.GetMouseButtonDown(1)) // �Ҽ����
        {
            DeselectCharacter();
        }
    }

    void SelectCharacter()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Character clickedCharacter = hit.collider.GetComponent<Character>();
            if (clickedCharacter != null)
            {
                if (selectedCharacter != null)
                {
                    selectedCharacter.Deselect(); // ȡ����ǰѡ��Ľ�ɫ
                }

                selectedCharacter = clickedCharacter; // ѡ���½�ɫ
                selectedCharacter.Select(); // ѡ���ɫ

                // ����ѡ��Ľ�ɫ����
                int index = characters.IndexOf(clickedCharacter);
                PlayerPrefs.SetInt("SelectedCharacterIndex", index);
                PlayerPrefs.Save(); // ���� PlayerPrefs

                // �л����
                for (int i = 0; i < characterCameras.Length; i++)
                {
                    characterCameras[i].Priority = (clickedCharacter == characters[i]) ? 10 : 0;
                }
            }
        }
    }

    void DeselectCharacter()
    {
        if (selectedCharacter != null)
        {
            selectedCharacter.Deselect();
            selectedCharacter = null; // ���ѡ��
            foreach (var cam in characterCameras)
            {
                cam.Priority = 0; // �����������
            }
        }
    }
}