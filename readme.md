## Genres Endpointi
### 1-)GetListAllGenre metodunu var olan genreleri z->a �eklinde s�ralad�m ancak i�erisine giremedi�im i�in net bir sonu� alamad�m.
### 2-)Genre i�lemlerine kolayl�k olsun diye Id'e g�re film getirme i�lemi ger�ekle�tirdim.
### 3-)AddGenre k�sm�nda ise ekleme i�lemi yaparken(film baz�nda) [{'id': 18, 'name': 'Drama'}] veya [{'id': 35, 'name': 'Comedy'}] gibi yaz�p denersek sonu� verecektir.
### 4-)Yine film baz�nda genre silme ve g�ncelleme i�lemleri yap�labilir.

##Movies Endpointi
### 1-)Burada her action sonu� verecektir.
### 2-)GetMovieDetailsById k�sm�nda redis ile bir increment++ �zelli�i ba�l�d�r.Ayakta olan bir docker container ile �a��r�ld���nda bu �zellik �al���yor olup.Get Id -- �rn:get 1 -- ile terminalde �a��r�ld���nda, bir film id'si ka� defa �a��r�lm��(g�r�nt�lenmi�) g�rebiliriz.
### 3-)AddMovie k�sm� i�in �nce bo� olan bir ID de�eri bulup(GetMovieById k�sm�n� kullanabilirsiniz) daha sonra ekleme i�lemi ger�ekle�tiriniz.ID alan� tablo'da identity olarak ayarlanmad��� i�in b�yle bir y�ntem uyguluyoruz.
### 4-)GetMovieListGenre k�sm�nda ise  Genre'ye g�re movie aramalar�n� [{'id': 18, 'name': 'Drama'}] veya [{'id': 35, 'name': 'Comedy'}] gibi �ekillerde yaz�p �ekti�inizde sonu� verecektir ve genresi o olan movieler gelecektir.
### 5-)Bu endpoint ile ilgili gerekli di�er a��klamalar actionlar�n veya metodlar�n yan�nda comment olarak verilmi�tir.
### 6-)Fazla veri getirmesi beklenen alanlar postman arac�l��� ile h�zl� bir �ekilde �a��r�labilir(E�er de�er vermemiz gerekirse.Url k�sm�n�n sonuna /de�er yazabiliriz).Baz� alanlarda swagger a��r� bekletmektedir.

##Trendings Endpointi
### 1-)Var olan tek action bize en �ok oy alan 20 adet movie d�nd�r�r.

##Not:
### Proje aya�a kald�r�ld�ktan sonra test edilebilmesi i�in  User Endpointinde Authentication i�lemi yap�lmas� gerekir.User ile ilgili bir model olu�turulmu�tur ve migration i�lemi ile Db'de user i�in bir tablo a��lm�� olup kullan�c� ad� ve �ifresi kay�t edilmi�tir..(Model'e bakabilirsiniz).
### Bu i�lemden sonra al�nacak olan token ile �st tarafta bulunan Authorization alan�na,al�nan token girilir ve user aktif olur.Aksi takdirde 401 hatas� al�n�r.
### Custom middleware ile exception handling yaz�m� mevcuttur. Hata ald���nda otomatik olarak �al��acak ama bunun bizim taraf�m�zdan yakalanmayan hatalar oldu�unu bilmeliyiz bu y�zden tyr catch metodlar� s�k kullan�lmam��t�r. Handle edilmemi� exception'lar� yakalayacakt�r.Custom middleware ile ilgili detaylar� BLL alan�nda ve program.cs k�sm�nda g�rebilirsiniz.

##Kullan�lan teknolojiler
###Net 6
###Ef Core
###Web Api
###Postgresql
###Swagger
###Redis
####Proje katmanl� mimari �zerine in�a edilmi�tir.Teknolojilerin hepsine de�inilmeye �al���lm�� olunup ,verilen detail alan�yla ilgili olarak da bir �o�u kar��lanmaya �al���lm��t�r.

