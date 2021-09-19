using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Ekleme işlemi başarılı";
        public static string Deleted = "Silme işlemi başarılı";
        public static string Updated = "Güncelleme işlemi başarılı";
        public static string Listed = "Listeleme işlemi başarılı";
        public static string CarNotAvailable = "Araba Teslim Edilmedi";
        public static string Error = "İşlem Başarısız";
        public static string CarImageLimitExceeded="Araba resmi ekleme limiti dolmuştur.";
        public static string UserRegistered="Kayıt oluşturuldu";
        public static string UserAlreadyExists="Kullanıcı Mevcut";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string SuccessfulLogin="Giriş Başarılı";
        public static string PasswordError="Şifre Hatalı";
        public static string AccessTokenCreated="Token Oluşturuldu";
        public static string AuthorizationDenied="Yetkiniz yok";
    }
}
