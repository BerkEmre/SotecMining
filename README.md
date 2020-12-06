# SotecMining

C# ile pazaryeri ürün bilgilerinin toplanması için yazılmış SQL Database, Windows Servis ve Admin Paneli uygulaması.

Kurulum:

1. SQL.sql ile SQL veritabanı ve örnek dataların kurulumu yapılır.
2. Config.xml ile SQL bağlantı string ve iki tur arası bekleme süresi milisecond olarak tanımlanır.
3. SotecAdmin.exe ile yönetim paneli açılır ve yeni ürün eklemeleri, örnek data gözlemi, pazaryeri ayarları ve test işlemleri yapılabilir.
4. SotecMining.exe servisi kurulumu yapılır.

Notlar:

- Yapılan değişiklikler her tur sonunda işleme konur.
- Servis kurulumu tamamlanmıyor ise Connection String yanlış yazılmış olabilir string yazılırken Windows Auth. kullanılmamalı kullanıcı ve şifre ile giriş yapılmalıdır.
- Hata alığı zaman kurulum yapılan klasör içinde tarihe göre log tutulmaktadır loglar incelenebilir.

Destek ve yardım için benimle iletişime geçebilirsiniz.

İyi eğlenceler...
