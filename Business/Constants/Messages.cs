using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string isAdded = "Araba listeye eklendi";
        public static string nameInvalid = "Isimlendirmede hata var";
        public static string isDeleted = "Araba listeden silindi";
        public static string isUpdated = "Arab guncellendi";
        public static string CarImagesCount="Urune daha fazla resim eklenemez";
        public static string  userNotExist="Boyle bir kullanici yok";
        public static string PasswordError="Kod Yanlis";
        public static string SuccessfullLogin="Hesaba Giris yapildi";
        public static string UserAlreadyExist="Kullanici zaten mevcut";
    }
}
