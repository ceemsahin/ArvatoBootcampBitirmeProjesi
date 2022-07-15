## Genres Endpointi
### 1-)GetListAllGenre metodunu var olan genreleri z->a þeklinde sýraladým ancak içerisine giremediðim için net bir sonuç alamadým.
### 2-)Genre iþlemlerine kolaylýk olsun diye Id'e göre film getirme iþlemi gerçekleþtirdim.
### 3-)AddGenre kýsmýnda ise ekleme iþlemi yaparken(film bazýnda) [{'id': 18, 'name': 'Drama'}] veya [{'id': 35, 'name': 'Comedy'}] gibi yazýp denersek sonuç verecektir.
### 4-)Yine film bazýnda genre silme ve güncelleme iþlemleri yapýlabilir.

##Movies Endpointi
### 1-)Burada her action sonuç verecektir.
### 2-)GetMovieDetailsById kýsmýnda redis ile bir increment++ özelliði baðlýdýr.Ayakta olan bir docker container ile çaðýrýldýðýnda bu özellik çalýþýyor olup.Get Id -- örn:get 1 -- ile terminalde çaðýrýldýðýnda, bir film id'si kaç defa çaðýrýlmýþ(görüntülenmiþ) görebiliriz.
### 3-)AddMovie kýsmý için önce boþ olan bir ID deðeri bulup(GetMovieById kýsmýný kullanabilirsiniz) daha sonra ekleme iþlemi gerçekleþtiriniz.ID alaný tablo'da identity olarak ayarlanmadýðý için böyle bir yöntem uyguluyoruz.
### 4-)GetMovieListGenre kýsmýnda ise  Genre'ye göre movie aramalarýný [{'id': 18, 'name': 'Drama'}] veya [{'id': 35, 'name': 'Comedy'}] gibi þekillerde yazýp çektiðinizde sonuç verecektir ve genresi o olan movieler gelecektir.
### 5-)Bu endpoint ile ilgili gerekli diðer açýklamalar actionlarýn veya metodlarýn yanýnda comment olarak verilmiþtir.
### 6-)Fazla veri getirmesi beklenen alanlar postman aracýlýðý ile hýzlý bir þekilde çaðýrýlabilir(Eðer deðer vermemiz gerekirse.Url kýsmýnýn sonuna /deðer yazabiliriz).Bazý alanlarda swagger aþýrý bekletmektedir.

##Trendings Endpointi
### 1-)Var olan tek action bize en çok oy alan 20 adet movie döndürür.

##Not:
### Proje ayaða kaldýrýldýktan sonra test edilebilmesi için  User Endpointinde Authentication iþlemi yapýlmasý gerekir.User ile ilgili bir model oluþturulmuþtur ve migration iþlemi ile Db'de user için bir tablo açýlmýþ olup kullanýcý adý ve þifresi kayýt edilmiþtir..(Model'e bakabilirsiniz).
### Bu iþlemden sonra alýnacak olan token ile üst tarafta bulunan Authorization alanýna,alýnan token girilir ve user aktif olur.Aksi takdirde 401 hatasý alýnýr.
### Custom middleware ile exception handling yazýmý mevcuttur. Hata aldýðýnda otomatik olarak çalýþacak ama bunun bizim tarafýmýzdan yakalanmayan hatalar olduðunu bilmeliyiz bu yüzden tyr catch metodlarý sýk kullanýlmamýþtýr. Handle edilmemiþ exception'larý yakalayacaktýr.Custom middleware ile ilgili detaylarý BLL alanýnda ve program.cs kýsmýnda görebilirsiniz.

##Kullanýlan teknolojiler
###Net 6
###Ef Core
###Web Api
###Postgresql
###Swagger
###Redis
####Proje katmanlý mimari üzerine inþa edilmiþtir.Teknolojilerin hepsine deðinilmeye çalýþýlmýþ olunup ,verilen detail alanýyla ilgili olarak da bir çoðu karþýlanmaya çalýþýlmýþtýr.

