using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizedButton : MonoBehaviour
{
    public Button button;
    public string localizationKey; // ���� ���������� ��� ������ ������

    private void Start()
    {
        button = GetComponent<Button>();
        UpdateButtonText();

        // ������� �������� ��䳿 ��� ���������� ��� ����
        LocalizationSettings.SelectedLocaleChanged += OnSelectedLocaleChanged;
    }

    private void OnDestroy()
    {
        // ������� �������� ��䳿 ��� ������� ��'����
        LocalizationSettings.SelectedLocaleChanged -= OnSelectedLocaleChanged;
    }

    private void OnSelectedLocaleChanged(Locale locale)
    {
        // ³������ �� ���� ���� � ������� ����� ������
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        // ��������� ����� ������ � Unity Localization Package �� ������
        if (button != null)
        {
            string localizedText = LocalizationSettings.StringDatabase.GetLocalizedString(localizationKey);
            button.GetComponentInChildren<Text>().text = localizedText;
        }
    }
}
