using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Constants
{
    /// <summary>
    /// Contains constant messages used throughout the application.
    /// </summary>
    public static class Messages
    {
        public static string SessionNotFound = "Session bilgisi alınamadı.";
        public static string SessionDataNotFound = "Session datası bulunamadı.";
        public static string InvalidSessionData = "Geçersiz oturum verisi.";
        public static string OriginAndDestinationMustBeDifferent = "Kalkış ve varış lokasyonu noktası olarak aynı lokasyon seçilemez.";
        public static string DepartureDateMustNotBeInPast = "Kalkış tarihi bugünden küçük olamaz.";
        public static string DestinationIdIsRequired = "Varış lokasyonu boş geçilemez.";
        public static string OriginIdIsRequired = "Kalkış lokasyonu boş geçilemez.";
        public static string DepartureDateIsRequired = "Kalkış tarihi boş geçilemez.";
        public static string JourneyListError = "Seyahat listesi yüklenirken hata oluştu";
    }
}
