using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizedButton : MonoBehaviour
{
    public Button button;
    public string localizationKey; // Ключ локалізації для тексту кнопки

    private void Start()
    {
        button = GetComponent<Button>();
        UpdateButtonText();

        // Додайте обробник події для відстеження змін мови
        LocalizationSettings.SelectedLocaleChanged += OnSelectedLocaleChanged;
    }

    private void OnDestroy()
    {
        // Видаліть обробник події при знищенні об'єкта
        LocalizationSettings.SelectedLocaleChanged -= OnSelectedLocaleChanged;
    }

    private void OnSelectedLocaleChanged(Locale locale)
    {
        // Відповідає на зміну мови і оновлює текст кнопки
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        // Отримайте текст кнопки з Unity Localization Package за ключем
        if (button != null)
        {
            string localizedText = LocalizationSettings.StringDatabase.GetLocalizedString(localizationKey);
            button.GetComponentInChildren<Text>().text = localizedText;
        }
    }
}
