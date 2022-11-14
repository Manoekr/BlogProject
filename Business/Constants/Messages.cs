using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string Deleted = "Başarılıyla Silindi";

        public static string Added = "Başarılıyla Eklendi";

        public static string Updated = "Başarılıyla Güncellendi";

        public static string AuthorizationDenied = "Yetkiniz Yok";

        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string PasswordError = "Şifre Hatalı";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string UserRegistered = "Kayıt Olundu";
    }
}
