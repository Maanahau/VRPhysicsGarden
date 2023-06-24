using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "DialogueSequence", menuName = "ScriptableObject/DialogueSequence")]
public class DialogueSequence : ScriptableObject
{
    public LocalizedString[] lines;
}
