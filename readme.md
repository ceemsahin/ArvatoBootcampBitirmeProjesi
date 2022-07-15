## Genres Endpointi
### 1-)GetListAllGenre metodunu var olan genreleri z->a şeklinde sıraladım ancak içerisine giremediğim için net bir sonuç alamadım.
### 2-)Genre işlemlerine kolaylık olsun diye Id'e göre film getirme işlemi gerçekleştirdim.
### 3-)AddGenre kısmında ise ekleme işlemi yaparken(film bazında) [{'id': 18, 'name': 'Drama'}] veya [{'id': 35, 'name': 'Comedy'}] gibi yazıp denersek sonuç verecektir.
### 4-)Yine film bazında genre silme ve güncelleme işlemleri yapılabilir.

## Movies Endpointi
### 1-)Burada her action sonuç verecektir.
### 2-)GetMovieDetailsById kısmında redis ile bir increment++ özelliği bağlıdır.Ayakta olan bir docker container ile çağırıldığında bu özellik çalışıyor olup.Get Id -- örn:get 1 -- ile terminalde çağırıldığında, bir film id'si kaç defa çağırılmış(görüntülenmiş) görebiliriz.
### 3-)AddMovie kısmı için önce boş olan bir ID değeri bulup(GetMovieById kısmını kullanabilirsiniz) daha sonra ekleme işlemi gerçekleştiriniz.ID alanı tablo'da identity olarak ayarlanmadığı için böyle bir yöntem uyguluyoruz.
### 4-)GetMovieListGenre kısmında ise  Genre'ye göre movie aramalarını [{'id': 18, 'name': 'Drama'}] veya [{'id': 35, 'name': 'Comedy'}] gibi şekillerde yazıp çektiğinizde sonuç verecektir ve genresi o olan movieler gelecektir.
### 5-)Bu endpoint ile ilgili gerekli diğer açıklamalar actionların veya metodların yanında comment olarak verilmiştir.
### 6-)Fazla veri getirmesi beklenen alanlar postman aracılığı ile hızlı bir şekilde çağırılabilir(Eğer değer vermemiz gerekirse.Url kısmının sonuna /değer yazabiliriz).Bazı alanlarda swagger aşırı bekletmektedir.

## Trendings Endpointi
### 1-)Var olan tek action bize en çok oy alan 20 adet movie döndürür.

## NOT
### Proje ayağa kaldırıldıktan sonra test edilebilmesi için  User Endpointinde Authentication işlemi yapılması gerekir.User ile ilgili bir model oluşturulmuştur ve migration işlemi ile Db'de user için bir tablo açılmış olup kullanıcı adı ve şifresi kayıt edilmiştir..(Model'e bakabilirsiniz).
### Bu işlemden sonra alınacak olan token ile üst tarafta bulunan Authorization alanına,alınan token girilir ve user aktif olur.Aksi takdirde 401 hatası alınır.
### Custom middleware ile exception handling yazımı mevcuttur. Hata aldığında otomatik olarak çalışacak ama bunun bizim tarafımızdan yakalanmayan hatalar olduğunu bilmeliyiz bu yüzden tyr catch metodları sık kullanılmamıştır. Handle edilmemiş exception'ları yakalayacaktır.Custom middleware ile ilgili detayları BLL alanında ve program.cs kısmında görebilirsiniz.

## Kullanılan teknolojiler
### Net 6
### Ef Core
### Web Api
### Postgresql
### Swagger
### Redis
#### Proje katmanlı mimari üzerine inşa edilmiştir.Teknolojilerin hepsine değinilmeye çalışılmış olunup ,verilen detail alanıyla ilgili olarak da bir çoğu karşılanmaya çalışılmıştır.

