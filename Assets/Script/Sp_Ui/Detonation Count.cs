using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetonationCount : MonoBehaviour
{
    public PlayerExploding playerExploding;
    public TMP_Text countText;

    // Update is called once per frame
    void Update()
    {
        countText.text = $"{playerExploding.detonationCount}/3";
    }
}
