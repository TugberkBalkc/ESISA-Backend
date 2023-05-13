using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Constants.Response
{
    public static class ResponseMessages
    {
        public const String Vote = "Oy";

        public const String NotFound = "Bulunamadı.";
        public const String NothingFoundAccordingToFilter = "Aradığınız Filtreye Uygun Sonuç Bulunamadı.";
        public const String AlreadyExists = "Zaten Mevcut.";
        public const String ValidationError = "Doğrulama Hatası.";

        public const String AdvertVoted = "İlan Başarıyla Oylandı.";
        public const String DealerVoted = "Satıcı Başarıyla Oylandı.";
        public const String AdvertDownVoted = "İlan Aşşağı Oylandı";
        public const String DealerDownVoted = "Satıcı Aşşağı Oylandı";
        public const String DealerUpVoted = "Satıcı Yukarı Oylandı";
        public const String AdvertUpVoted = "İlan Yukarı Oylandı";
        public const String VoteDeleted = "Oy Silindi.";
      
        public const String PriceUpdated = "Fiyat Güncellendi.";
        public const String PriceRaised = "Fiyat Arttırıldı.";
        public const String PriceReduced = "Fiyat Düşürüldü.";

        public const String AdvertMarkedAsSold = "İlan Satıldı Olarak İşaretlendi.";
        public const String AdvertMarkedAsUnsold = "İlan Satışa Geri Açıldı.";
        public const String RelatedAdvertSold = "Satılmış İlan Üzerinde Düzenleme Yapılamaz.";
        public const String RelatedAdvertAlreadyMarkedSold = "İlan Zaten Satıldı Olarak İşaretlenmiş.";
        public const String PhotoAddedToAdvert = "İlana Fotoğraf Eklendi.";
        public const String PhotoDeletedInAdvert = "Fotoğraf İlandan Silindi.";
        public const String AdvertMarkedAsOutOfStock = "İlan Tedarik Edilemiyor Olarak İşaretlendi.";
        public const String StockUpdated = "Stok Güncellendi.";

        public const String IndividualAdvertCreated = "Bireysel İlan Oluşturuldu.";
        public const String IndividualAdvertUpdated = "Bireysel İlan Güncellendi.";
        public const String InidividualAdvertDeleted = "Bireysel İlan Silindi.";
        public const String IndividualAdvertsListed = "Bireysel İlanlar Listelendi.";

        public const String CorporateAdvertCreated = "Kurumsal İlan Oluşturuldu.";
        public const String CorporateAdvertUpdated = "Kurumsal İlan Güncellendi.";
        public const String CorporateAdvertDeleted = "Kurumsal İlan Silindi.";
        public const String CorporateAdvertAlreadyOutOfStock = "Stok Zaten Mevcut Değil.";
        public const String CorporateAdvertAlreadyNotOutOfStock = "Stok Zaten Mevcut.";

        public const String SwapAdvertCreated = "Takas İlanı Oluşturuldu.";
        public const String SwapAdvertDeleted = "Takas İlanı Silindi.";
        public const String SwapAdvertUpdate = "Takas İlanı Güncellendi.";
        public const String SwapAdvertsListed = "Takas İlanları Listelendi.";
        public const String SwapAdvertNoActive = "Takas İlanı Aktif Değil.";
        public const String CategoryAddedToSwappableList = "Kategori Takaslanabilirler Listesine Eklendi.";
        public const String CategoryDeletedInSwappableList = "Kategori Takaslanabilirler Listesinden Kaldırıldı.";
        public const String ProductAddedToSwappableList = "Ürün Takaslanabilirler Listesine Eklendi.";
        public const String ProductDeletedInSwappableList = "Ürün Takaslanabilirler Listesinden Kaldırıldı.";

        public const String ProductCreated = "Ürün Başarıyla Oluşturuldu.";
        public const String ProductDeleted = "Ürün Başarıyla Silindi.";
        public const String ProductsDeleted = "Ürünler Başarıyla Silindi.";
        public const String ProductUpdated = "Ürün Başarıyla Güncellendi.";
        public const String ProductsListed = "Ürünler Başarıyla Listelendi.";
        public const String ProductListed = "Ürün Başarıyla Listelendi.";

        public const String CategoryCreated = "Kategori Başarıyla Oluşturuldu.";
        public const String CategoryDeleted = "Kategori Başarıyla Silindi.";
        public const String CategoriesDeleted = "Kategoriler Başarıyla Silindi.";
        public const String CategoryUpdated = "Kategori Başarıyla Güncellendi.";

        public const String SubCategoryCreated = "Alt Kategori Başarıyla Oluşturuldu.";
        public const String SubCategoryDeleted = "Alt Kategori Başarıyla Silindi.";
        public const String SubCategoriesDeleted = "Alt Kategoriler Başarıyla Silindi.";
        public const String SubCategoryUpdated = "Alt Kategori Başarıyla Güncellendi.";

        public const String BrandCreated = "Marka Başarıyla Oluşturuldu.";
        public const String BrandDeleted = "Marka Başarıyla Silindi.";
        public const String BrandsDeleted = "Markalar Başarıyla Silindi.";
        public const String BrandUpdated = "Marka Başarıyla Güncellendi.";

        public const String RoleCreated = "Rol Başarıyla Oluşturuldu.";
        public const String RoleDeleted = "Rol Başarıyla Silindi.";
        public const String RolesDeleted = "Roller Başarıyla Silindi.";
        public const String RoleUpdated = "Rol Başarıyla Güncellendi.";

        public const String OperationClaimCreated = "Yetki Başarıyla Oluşturuldu.";
        public const String OperationClaimDeleted = "Yetki Başarıyla Silindi.";
        public const String OperationClaimsDeleted = "Yetkiler Başarıyla Silindi.";
        public const String OperationClaimUpdated = "Yetki Başarıyla Güncellendi.";

        public const String RoleOperationClaimNotFound = "Role Kayıtlı Böyle Bir Yetki Bulunamadı";
        public const String RoleOperationClaimAlreadyExists = "Rol Zaten Bu Yetkiye Sahip";
        public const String RoleOperationClaimCreated = "Role Yetki Başarıyla Eklendi.";
        public const String RoleOperationCalimDeleted = "Rolden Yetki Başarıyla Silindi.";
        public const String RoleOperationCalimsDeleted = "Rolden Yetkiler Başarıyla Silindi.";

        public const String DemandSent = "Talebiniz Alınmıştır.";
        public const String DemandDeleted = "Talep Başarıyla Silindi.";
        public const String DemandsDeleted = "Talepler Başarıyla Silindi.";
        public const String OtherUsersSentDemand = "Farklı Kullanıcılar Tarafından Bildirim Sağlanmıştır.";

        public const String AddressesListed = "Adresler Başarıyla Listelendi.";

        public const String Registered = "Başarıyla Kayıt Oldunuz.";
    }
}
