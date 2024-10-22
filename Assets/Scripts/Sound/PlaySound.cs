using UnityEngine;

/// <summary>
/// ��� ��������� ������� ��������������� ������
/// </summary>
public class PlaySound : MonoBehaviour
{
    [SerializeField]
    private AudioSource soundAudioSource;
    [SerializeField]
    private AudioClip soundClipPay;
    [SerializeField]
    private AudioClip soundClipAction;
    private void OnEnable()
    {
        PayShoppingCart.PayShopping += ActionPlaySound;
    }

    private void OnDisable()
    {
        PayShoppingCart.PayShopping += ActionPlaySound;
    }

    private void ActionPlaySound()
    {
        soundAudioSource.PlayOneShot(soundClipPay);
    }

    public void AtionButtonSound()
    {
        // ���� ����� ���� ����
        //soundAudioSource.PlayOneShot(soundClipAction);
    }
}
