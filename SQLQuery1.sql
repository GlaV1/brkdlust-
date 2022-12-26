DECLARE @Sayac TINYINT
SET @Sayac=0
WHILE(@Sayac<25)
BEGIN
	Insert into HizliUrun(barkod,urunAd,Fiyat) values('-','-',0)
	SELECT @Sayac=@Sayac+1
END