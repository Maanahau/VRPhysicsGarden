using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfilePageManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameBox;
    [SerializeField] TextMeshProUGUI questCountBox;

    private void Awake()
    {
        nameBox.text = ProfileManager.activeProfile.name;
        questCountBox.text = ProfileManager.activeProfile.completedQuests.Length.ToString();
    }
}
