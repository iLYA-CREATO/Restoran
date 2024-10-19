using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ќткрывает завкрывает окна без остановки времени
/// </summary>
public class OppenerPanel : MonoBehaviour
{
    public void OpenClousePanel(GameObject  panel)
    {
        panel.SetActive(!panel.activeSelf);
    }
}
