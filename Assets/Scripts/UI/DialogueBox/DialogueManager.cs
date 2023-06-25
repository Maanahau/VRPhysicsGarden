using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] Button button;
    [SerializeField] GameObject touchTooltip;
    [SerializeField] AudioSource beepSource;

    [SerializeField] UnityEvent onSequenceStart;
    [SerializeField] UnityEvent onSequenceEnd;

    [SerializeField] GameObject questMarker;
    private bool wasQuestMarkerActive;


    private DialogueSequence playingSequence;
    private int sequenceIndex;
    private bool ignoreEvents;

    Coroutine beepCoroutine;

    public void StartSequence(DialogueSequence sequence)
    {
        QuestGiver.lockedSteps = true;
        if (playingSequence != null)
            return;
        playingSequence = sequence;
        sequenceIndex = 1;
        gameObject.SetActive(true);
        StartCoroutine(PlayLine(sequence.lines[0]));
        beepCoroutine = StartCoroutine(PlayBeepSound());
        if(!ignoreEvents)
            onSequenceStart.Invoke();
        CheckQuestMarkerOnStart();
    }

    public void StartSequenceIgnoreEvents(DialogueSequence sequence)
    {
        ignoreEvents = true;
        StartSequence(sequence);
    }

    //attach to button
    public void PlayNextLine()
    {
        if(sequenceIndex < playingSequence.lines.Length)
        {
            StartCoroutine(PlayLine(playingSequence.lines[sequenceIndex++]));
            beepCoroutine = StartCoroutine(PlayBeepSound());
        }
        else
        {
            QuestGiver.lockedSteps = false;
            textBox.text = "";
            gameObject.SetActive(false);
            playingSequence = null;
            if (!ignoreEvents)
            {
                onSequenceEnd.Invoke();
            }
            else
            {
                ignoreEvents = false;
            }
            CheckQuestMarkerOnEnd();
        }
    }

    private void CheckQuestMarkerOnStart()
    {
        if(questMarker != null && !QuestGiver.isQuestActive)
        {
            questMarker.transform.parent.GetComponent<QuestGiver>().disableMarker = true;
        }
    }

    private void CheckQuestMarkerOnEnd()
    {
        if (questMarker != null && !QuestGiver.isQuestActive)
        {
            questMarker.transform.parent.GetComponent<QuestGiver>().disableMarker = false;
        }
    }

    private IEnumerator PlayLine (LocalizedString line)
    {
        button.enabled = false;
        touchTooltip.SetActive(false);
        textBox.text = "";
        foreach(char c in line.GetLocalizedString().ToCharArray())
        {
            textBox.text += c;
            yield return new WaitForSecondsRealtime(0.02f);
        }
        button.enabled = true;
        touchTooltip.SetActive(true);
        StopCoroutine(beepCoroutine);
    }

    private IEnumerator PlayBeepSound()
    {
        while (true)
        {
            beepSource.pitch = Random.Range(1f, 1.5f);
            beepSource.Play();
            yield return new WaitForSecondsRealtime(Random.Range(0.08f, 0.2f));
        }
    }
}
