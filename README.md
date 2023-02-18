# Ball Game API

C# .NET 6.0 ile oluşturulmuş bir Web Api projesidir.

## Dosya Yapısı

Çözümü başlatan asıl proje API projesidir. Diğer katmanlar 'Class Library' projesi olarak oluşturulmuştur. Böylece tek yerde yazılan kod birçok yerde modül şeklinde kullanılabilmektedir.

## Projeyi Çalıştırma

```python
# önce bu dosya yoluna gidilmelidir
cd /API

# komut ile calıstırılır
dotnet run
```

## Açıklama

Proje clone'lanıp başlatıldıktan sonra, tarayıcıdan, 
<http://localhost:5000/swagger>  adresine giderek projenin swagger dökümantasyonuna ulaşabilirsiniz.

Son olarak burada gelen, ```/Players/Play``` endpointine, oyuncu sayısı inputunu girerek, istek atabilirsiniz. İstek sonucu size oyunda son kalarak kazanan numarayı verecektir.
##
