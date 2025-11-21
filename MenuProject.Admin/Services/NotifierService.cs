using System;

namespace MenuProject.Admin.Services
{
    public class NotifierService
    {
        // Uyarı kutusunun abone olacağı olay (Event)
        public event Action<string, bool>? OnShow;

        public void Show(string message, bool isError = false)
        {
            // Mesaj geldiğinde abone olan bileşeni (ToastNotification) tetikle
            OnShow?.Invoke(message, isError);
        }
    }
}