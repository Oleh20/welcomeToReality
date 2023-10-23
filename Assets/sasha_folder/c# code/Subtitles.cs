using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Subtitles : MonoBehaviour
{
    [SerializeField] private Text subtitleText;
    [SerializeField] private float letterDelay = 0.1f;
    [SerializeField] private float disableDelay = 1.0f;
    [SerializeField] private string currentSubtitle;
    [SerializeField] private string[] mainSubtitle;
    [SerializeField] private string[] secondarySubtitle;
    [SerializeField] private string[] deathSubtitle;
    [SerializeField] private string[] introSubtitle;
    [SerializeField] private int currentIndex;

    [SerializeField] private GameObject textBlock;

    private string saveTextOnPause;
    private int saveIndexOnPause;
    private bool saved;

    private void Start()
    {
    }
    public void SaveDataOnPause()
    {
        saved = true;
        saveTextOnPause = subtitleText.text;
        saveIndexOnPause = currentIndex;
        StopCoroutine(ShowSubtitle());
    }
    public void UploadDataOnContinue()
    {
      StopAllCoroutines(); 
        StartCoroutine(ShowSubtitle());
    }
    private void CheckOnSaved()
    {
        if (saved)
        {
            subtitleText.text = saveTextOnPause;
            currentIndex = saveIndexOnPause;
            saved = false;
        }
    }
    public void StartSubtitles(string type, int index)
    {
        SetTextOf();
        subtitleText.text = "";
        if (type == "death")
        {
            currentSubtitle = LocalizationSettings.StringDatabase.GetLocalizedString(deathSubtitle[index]);
            StartCoroutine(ShowSubtitle());
        }
        else if (type == "main")
        {
            currentSubtitle = LocalizationSettings.StringDatabase.GetLocalizedString(mainSubtitle[index]);
            StartCoroutine(ShowSubtitle());

        }
        else if (type == "intro")
        {
            currentSubtitle = LocalizationSettings.StringDatabase.GetLocalizedString(introSubtitle[index]);

            StopCoroutine(ShowSubtitle());
            StartCoroutine(ShowSubtitle());
        }
        else
        {
            currentSubtitle = LocalizationSettings.StringDatabase.GetLocalizedString(secondarySubtitle[index]);
            StartCoroutine(ShowSubtitle());
        }
    }
    private IEnumerator ShowSubtitle()
    {
        SetTextOf();
        yield return new WaitForSeconds(0.3f);
        CheckOnSaved();
        textBlock.SetActive(true);
        while (currentIndex < currentSubtitle.Length)
        {
            subtitleText.text += currentSubtitle[currentIndex];
            currentIndex++;
            yield return new WaitForSeconds(letterDelay);
        }
        yield return new WaitForSeconds(disableDelay);
        currentIndex = 0;

    }
    public void SetTextOf()
    {
        currentIndex = 0;
        subtitleText.text = null;
    }


}
