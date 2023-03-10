using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Constants
{
    public static class DefaultDomainExceptionTitles
    {
        public const String InternalExceptionTitle = "Sunucu Hatası";
        public const String BusinessExceptionTitle = "Operasyonel Mantık Hatası";
        public const String AuthorizationExceptionTitle = "Yetkilendirme Hatası";
        public const String DatabaseExceptionTitle = "Veritabanı Hatası";
        public const String ValidationExceptionTitle = "Doğrulama Hatası";
    }
}
