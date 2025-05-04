Bu proje, kullanıcıların randevu alabileceği, düzenleyebileceği ve iptal edebileceği basit bir hastane randevu yönetim sistemidir.

Projeyi Çalıştırmak İçin Gerekli Adımlar

Gerekli NuGet paketlerini yükleyin:
dotnet restore

Aşağıdaki NuGet paketlerinin yüklü olduğundan emin olun:
Microsoft.EntityFrameworkCore 
Microsoft.EntityFrameworkCore.Design 
Microsoft.EntityFrameworkCore.Sqlite
Microsoft.EntityFrameworkCore.Tools

.NET 8.0 SDK yüklü olmalıdır.
Veritabanını oluşturmak için "dotnet ef database update" komutunu çalıştırmalısınız. 

Veritabanındaki verileri görüntülemek için https://sqlitestudio.pl/ kurulumu yapılabilir.

Kullanılan Teknolojiler

ASP.NET Core 8.0

Razor Pages

Entity Framework Core 

SQLite

Cookie Authentication

Bootstrap 5

FontAwesome

Varsayımlar ve Yaklaşımlar

User ve Admin olmak üzere 2 adet rol tanımlanmıştır.

User rolüne sahip kullanıcılar yalnızca kendi randevularını görüntüleyebilir, oluşturabilir, tarihlerini güncelleyebilir ve iptal edebilir.
Admin rolü, tüm kullanıcıların randevularını yalnızca görüntüleyebilir. Admin, yeni randevu oluşturamaz ancak kullanıcıların oluşturduğu randevuları onaylayabilir veya reddedebilir (Denied durumu).

Randevu silme işlemi doğrudan veritabanından fiziksel olarak silinmemekte, bunun yerine randevunun durumu Cancelled olarak güncellenmektedir. Bu sayede geçmiş işlemler izlenebilir hâlde tutulur . soft delete yaklaşımı benimsenmiştir.

Kullanıcıya ait bilgiler IUserService arayüzü üzerinden servis tabanlı olarak elde edilmekte ve ilgili Razor Page'lerde dependency injection ile kullanılmaktadır. Bu sayede kullanıcı bilgilerine erişim merkezi ve test edilebilir bir yapıda sağlanmıştır.

Mock e-posta bildirim sistemi tasarlanmıştır, ancak dış sistemlere e-posta gönderimi aktif değildir.

UI tarafında modern ve responsive bir tema tercih edilmiştir. Bootstrap 5 ve FontAwesome ikon kütüphanesi ile sade ve kullanıcı dostu bir arayüz oluşturulmuştur.

Gerekli tüm form alanlarına validasyonlar uygulanmıştır.

Projede Code First yaklaşımı kullanılmıştır. Tüm veritabanı tabloları ve ilişkiler, C# sınıfları üzerinden tanımlanmış, ardından Entity Framework Core ile migration işlemleri uygulanarak veritabanı oluşturulmuştur. Migrationlar ile yeni alanlar ya da mock datalar oluşturulmuşturç

Sayfa yönlendirme, form işleme ve veri gösterim işlemleri için ASP.NET Core Razor Pages mimarisi tercih edilmiştir. Razor Pages, özellikle küçük ve orta ölçekli uygulamalarda daha az yapılandırma ile hızlı geliştirme imkânı sağladığı için bu proje kapsamında uygun görülmüştür. Ayrıca sayfa-temelli yönetime olanak tanıyarak hem geliştirici hem de kullanıcı açısından daha okunabilir bir yapı sunmaktadır.

Giriş Bilgileri (Demo)

Admin hesabı:

Kullanıcı Adı: admin

Şifre: 123

Normal kullanıcı hesabı:

Kullanıcı Adı: testuser

Şifre: 456

