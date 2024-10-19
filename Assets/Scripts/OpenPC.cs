using UnityEngine;

public class OpenPC : MonoBehaviour
{
    [SerializeField]
    [Header("�������� ������")]
    private KeyManager keyManager;
    [SerializeField]
    [Header("���� ��")]
    private GameObject PcPanel;
    [SerializeField]
    [Header("������ ��")]
    private bool isOpenPC;

    [SerializeField]
    [Header("���������� ������")]
        private MoveCamera moveCamera;
    [SerializeField]
    [Header("���������� ������")]
        private MoveCharacter moveCharacter;
    private void OnEnable()
    {
        AllRaycast.OnRaycast += RayOpenPC;
    }

    private void OnDisable()
    {
        AllRaycast.OnRaycast -= RayOpenPC;
    }

    private void RayOpenPC()
    {
        if (Input.GetKeyDown(keyManager.PressAction))
        {
            isOpenPC = true;
            PcPanel.SetActive(isOpenPC);
            
            ParametrPlayer(isOpenPC);
        }
    }
    /// <summary>
    /// ����� ����� ��������� ���� ��
    /// </summary>
    /// ������ ��� ������ ����������, ����� ��������� �������
    /// � ����������� �� ��� ���������
    public void ClousePC()
    {
        isOpenPC = false;
        PcPanel.SetActive(isOpenPC);
       
        ParametrPlayer(isOpenPC);
    }

    /// <summary>
    /// ��������� ���������� ������� ��� �������� ��
    /// </summary>
    private void ParametrPlayer(bool isOpenPC)
    {
        if(isOpenPC)
        {
            Cursor.lockState = CursorLockMode.None;
            moveCamera.enabled = false;
            moveCharacter.enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            moveCamera.enabled = true;
            moveCharacter.enabled = true;
        }

    }
}
