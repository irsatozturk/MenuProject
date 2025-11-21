namespace MenuProject.Admin.Services
{
    // Bu servis, mesaj gönderenlerle (sayfalar) mesajı gösteren (NotificationSystem) arasında köprüdür.
    public class ToastService
    {
        // Olay (Event): "Birisi mesaj göster dediğinde tetiklenir"
        public event Action<string, bool>? OnShow;

        public void ShowToast(string message, bool isError)
        {
            // Abone olan (NotificationSystem) varsa ona haber ver
            OnShow?.Invoke(message, isError);
        }
    }
}