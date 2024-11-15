using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]    
    private TMPro.TextMeshProUGUI m_TextMeshPro;

    void Update()
    {
        m_TextMeshPro.text = "Score: " + Mathf.FloorToInt(Time.time);
    }
}
