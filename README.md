Furkan Ersöz
201816017
## Web Programlama Final Projesi

Uygulama bir kafenin menülerini gösteren, kullanıcının siparişlerini ve istek şarkılarını iletebildiği, kullanıcının kafenin iletişim bilgilerini ve konumunu görebildiği bir web uygulamasıdır. Bu uygulama ayrıca admin paneli içermektedir. Admin paneli ile kafe sahibi menü ve kategori ekleme,silme veya düzenleme işlemlerini kolaylıkla yapabilmektedir. Ayrıca verilen siparişleri ve istek şarkı önerilerini admin panelde görüntüleyebilmektedir. 
Ana sayfadaki footerdan kolaylıkla admin panele geçiş yapılabilmektedir. Admin login kısmında session kullandım, admin çıkış yap butonuna bastığında ise session bilgisi sıfırlanmaktadır. 

##### NOT:
admin panel giriş bilgileri ``` username:admin password:1234 ```

Veritabanı olarak MySQL tercih ettim. Projenin direkt olarak çalışabilmesi için veritabanı uzak bir sunucuda çalışmakta, bu nedenle herhangi bir yerel veritabanı oluşturmanıza gerek yoktur.

Katmanlı Mimari olarak ServicePrj olarak ikinci bir proje ekledim. Bu projede EF core çalışmakta. Bütün veritabanı modelleri bu proje içerisinde ayrıca veritabanından veri çekme veya ekleme işlemlerini bu proje içerisinde yer alan Classes/DatabaseService.cs class'ında yaptım. Veritabanı tablolarının modelleri haricinde 2 adet ViewModel oluşturdum bunlar Models/ViewModels klasörü içerisindedir. Menu içeriğini gösteren sayfalarda hem kategori hem menü tablolarına ihtiyaç duyduğum için MenuDetailViewModel.cs modelini oluşturdum. MenuViewModel.cs modelini ise birden fazla kategori ve tek menüye ihtiyaç duyduğum için oluşturdum. 

Veritabanı kısmında ise menüleri kategoriId(foreign key) ile birbirine bağladım. Menü ve kategori fotoğraflarını yüklediğimizde aşağıdaki kod çalışmaktadır:

```
public static string uploadImage(IFormFile file)
        {
            var localImageDir = $"wwwroot/images";
            var localImagePath = $"{localImageDir}/{file.FileName}";

            if (!Directory.Exists(Path.Combine(localImageDir)))
            {
                Directory.CreateDirectory(Path.Combine(localImageDir));
            }

            using (Stream fileStream = new FileStream(localImagePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            string modelsImagePath = Path.GetFileName(file.FileName).ToString();
            return modelsImagePath;
        }
```

Bu kod ile seçilen fotoğraf wwwroot/images klasörüne kopyalanır. Daha sonra dosyanın yolu kullanılmak üzere geri döndürülür. Geri dönen fotoğraf yolu ise ilgili tablonun imagePath sütununa eklenir. Böylelikle fotoğrafları değil sadece yolu veritabanına kaydedilir.


Server Problemi Olması Durumunda:
Veritabanı server'ında herhangi bir problem olması durumunda proje klasörüne veritabanının SQL scriptini ekledim. MySQL'de "mooncafedb" adında bir veritabanı oluşturup scriptten içeri aktardıktan sonra ServicePrj/Models/MooncafedbContext.cs class'ı içerisindeki UseMySql metoduna aşağıdaki stringi verebilirsiniz.
```
"server=localhost;port=3306;database=mooncafedb;user=root",Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb")
```
