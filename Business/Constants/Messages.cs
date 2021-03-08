using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdd = "Araç başarıyla eklendi.";
        public static string CarNameİnvalid = "Araç markası geçersiz!";
        public static string CarListed = "Araçlar başarıyla listelendi.";
        public static string CarDeleted = "Araç başarıyla silindi.";
        public static string Updated = "Araç başarıyla güncellendi.";
        public static string CarDetails = "Araç tüm detayları ile karşınızda";

        public static string MaintenanceTime = "Bakım Zamanı";

        public static string BrandUpdate = "Marka başarıyla güncellendi.";
        public static string BrandAdd = "Marka başarıyla eklendi.";
        public static string BrandDelete = "Marka başarıyla silindi.";
        public static string BrandListed = "Markalar başarıyla listelendi.";

        public static string ColorUpdate = "Renk başarıyla güncellendi.";
        public static string ColorDeleted = "Renk başarıyla silindi.";
        public static string ColorAdded = "Renk başarıyla eklendi.";

        public static string UserAdded = "Kullanıcı başarıyla eklendi.";
        public static string UserDeleted = "Kullanıcı başarıyla silindi.";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi.";

        public static string CutomerAdded = "Müşteri başarıyla eklendi.";
        public static string CustomerDeleted = "Müşteri başarıyla eklendi.";
        public static string CustomerUpdated = "Müşteri başarıyla eklendi.";

        public static string RentalAdded = "Araç kiralama işlemi başarıyla gerçekleşti.";
        public static string RentalDeleted = "Araç kiralama işlemi başarıyla silindi.";
        public static string RentalUpdated = "Araç kiralama işlemi başarıyla güncellendi.";

        public static string FailedRentalAddOrUpdate = "Araç henüz teslim edilmediği için kiralayamazsınız.";
        public static string ReturnedRental = "Kiraladığınız araç teslim edildi.";

        public static string FailedCarImageAdd="Bir araba 5'den fazla resme sahip olamaz.";
        public static string AddedCarImage = "Araba için yüklenilen resim başarıyla eklendi.";
        public static string DeletedCarImage = "Arabanın resmi başarıyla silindi.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kayıt oldu.";
        public static string UserAlreadyExists = "Kullanıcı mevcut!";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        public static string SuccessfulLogin = "Baraşıyla giriş yapıldı";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola hatası!";
    }
}
