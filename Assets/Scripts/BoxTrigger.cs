using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    [Header("�����/�� �����")]
    public bool isTrigBox;

    private void OnTriggerStay(Collider other)
    {
        isTrigBox = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isTrigBox = false;
    }
}
