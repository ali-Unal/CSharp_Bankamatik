using System.Collections.Concurrent;

namespace Bankamatik
{
    internal class Program
    {
        static void Main(string[] args)
        {
        START:
            string sifre = "ab18";
            double bakiye = 25000;
            int hataSayisi = 0;
            int geriSayim = 3;

        kart_islemleri:
            Console.Clear();
            Console.WriteLine("Hoşgeldiniz. Kartlı işlemler için 1, kartsız işlemler için 2'yi tuşlayın");
            int girdi = Convert.ToInt32(Console.ReadLine());

            if (girdi < 1 || girdi > 2) 
            {
                Console.Clear();
                Console.WriteLine("Lütfen geçerli bir tuşlama yapın");
                Thread.Sleep(2000);
                goto kart_islemleri;
            }
            else 
            {
               if (girdi == 1) 
               {
                    kartlı_sifre:
                    
                    Console.Clear();
                    Console.WriteLine("Şifrenizi giriniz.");
                    string password = Console.ReadLine();

                    if (password == sifre) 
                    {
                        kartlıMenu:
                        Console.Clear();
                        Console.WriteLine("Para çekmek için 1");
                        Console.WriteLine("Para yatırmak için 2");
                        Console.WriteLine("Para Transferi için 3");
                        Console.WriteLine("Eğitim ödemeleri için 4");
                        Console.WriteLine("Fatura ödemeleri için 5");
                        Console.WriteLine("Bilgi Güncellemek için 6'yı tuşlayın");
                        int kartli_menu = Convert.ToInt32(Console.ReadLine());

                        if (kartli_menu < 1 || kartli_menu > 6) 
                        {
                            Console.Clear();
                            Console.WriteLine("Lütfen 1 ile 6 arasında bir rakam tuşlayın");
                            Thread.Sleep(3000);
                            goto kartlıMenu;
                        }
                        else 
                        {
                           if (kartli_menu == 1)  //------------------------------SEÇİM 1-------------------------------------------------------------------
                           {
                            paraCekme:
                                Console.Clear();
                                Console.WriteLine($"Çekmek istediğiniz miktarı tuşlayın, mevcut bakiyeniz: {bakiye} TL.");
                                double cekilenMiktar = Convert.ToInt32(Console.ReadLine());

                                if (cekilenMiktar <= 0) 
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen geçerli bir tuşlama yapın");
                                    Thread.Sleep(2000);
                                    goto paraCekme;
                                }
                                else if (cekilenMiktar > bakiye) 
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Bakiyeniz bu işlem için yetersiz, mevcuz bakiyeniz: {bakiye} TL.");
                                    Thread.Sleep(3000);
                                    goto paraCekme;
                                }
                                else 
                                {
                                    Console.WriteLine("Lütfen bekleyin...");
                                    Thread.Sleep(2500);
                                    bakiye = bakiye - cekilenMiktar;
                                    Console.Clear();
                                    Console.WriteLine("...");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.WriteLine($"İşleminiz başarıyla gerçekleşmiştir, güncel bakiyeniz: {bakiye} TL.");
                                    paraCekmeMenu:
                                    Console.WriteLine("Ana menüye dönmek için 9, işlemi sonlardırmak için 0'ı tuşlayın.");
                                    int paraCekmeGirdi = Convert.ToInt32(Console.ReadLine());
                                    
                                    if (paraCekmeGirdi == 9)
                                    {
                                        goto kart_islemleri;
                                    }
                                    else if (paraCekmeGirdi == 0)
                                    {
                                    
                                    }
                                    else 
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Lütfen geçerli seçeneklerden birini tuşlayın");
                                        Thread.Sleep(2500);
                                        goto paraCekmeMenu;
                                    }
                                }
                           }
                           else if (kartli_menu == 2)   //------------------------------SEÇİM 2-------------------------------------------------------------------
                           {
                                paraYatırımıMenu:
                                Console.Clear();
                                Console.WriteLine("Kredi kartınıza para yatırmak için 1, kendi hesabınıza yatırmak için 2'yi tuşlayın");
                                Console.WriteLine(" ");
                                Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                int paraYatirimi = Convert.ToInt32(Console.ReadLine());

                                
                                if (paraYatirimi == 1) 
                                {
                                kartNo:
                                    Console.Clear();
                                    Console.WriteLine("12 haneli kart numaranızı girin:");
                                    long kartNo = Convert.ToInt64(Console.ReadLine());

                                    if (kartNo <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Hatalı veya eksik bir numara tuşladınız. Lütfen tekrar deneyin");
                                        Thread.Sleep(3000);
                                        goto kartNo;
                                    }
                                    else
                                    {
                                        string kartHane = Convert.ToString(kartNo);
                                        long kartHaneNo = kartHane.Length;

                                    yatırımHata:
                                        if ( kartHaneNo == 12)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Yatırmak istediğiniz miktarı tuşlayın:");
                                            double kartYatirilan = Convert.ToInt32(Console.ReadLine());

                                            if (kartYatirilan <= 0)
                                            {
                                                Console.Clear();
                                                Thread.Sleep(300);
                                                Console.WriteLine("Lütfen geçerli bir miktar tuşlayın");
                                                Thread.Sleep(2000);
                                                goto yatırımHata;
                                            }
                                            else if (kartYatirilan > bakiye)
                                            {
                                                Console.Clear();
                                                Thread.Sleep(300);
                                                Console.WriteLine($"Bakiyeniz bu işlem için yetersiz. Mevcut bakiyeniz: {bakiye} TL.");
                                                Thread.Sleep(2000);
                                                goto yatırımHata;
                                            }
                                            else
                                            {
                                                Thread.Sleep(500);
                                                Console.WriteLine("Lütfen bekleyin...");
                                                Thread.Sleep(2000);
                                                bakiye = bakiye - kartYatirilan;
                                                Console.Clear();
                                                Thread.Sleep(200);
                                                Console.WriteLine($"İşleminiz başarıyla gerçekleşmiştir. Güncel hesap bakiyeniz: {bakiye} TL.");
                                                Console.WriteLine(" ");
                                            yatırım_menu:
                                                Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                                int yatirimMenu = Convert.ToInt32(Console.ReadLine());

                                                if (yatirimMenu == 9)
                                                {
                                                    goto kart_islemleri;
                                                }
                                                else if (yatirimMenu == 0)
                                                {

                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Lütfen geçerli seçeneklerden birini tuşlayın");
                                                    Thread.Sleep(2500);
                                                    goto yatırım_menu;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Hatalı veya eksik bir numara tuşladınız. Lütfen tekrar deneyin");
                                            Thread.Sleep(3000);
                                            goto kartNo;
                                        }
                                    }
                                    
                                }
                                else if (paraYatirimi == 2)
                                {
                                    hesapYatanHata:
                                    Console.Clear();
                                    Thread.Sleep(500);
                                    Console.WriteLine("Hesabınıza yatırmak istediğiniz miktarı tuşlayın");
                                    double hesabaYatan = Convert.ToInt32(Console.ReadLine());

                                    if (hesabaYatan <= 0)
                                    {
                                        Console.Clear();
                                        Thread.Sleep(300);
                                        Console.WriteLine("Lütfen geçerli bir miktar tuşlayın");
                                        Thread.Sleep(2000);
                                        goto hesapYatanHata;
                                    }
                                    else
                                    {
                                        Thread.Sleep(500);
                                        Console.WriteLine("Lütfen bekleyin...");
                                        Thread.Sleep(2000);
                                        bakiye = bakiye + hesabaYatan;
                                        Console.Clear();
                                        Thread.Sleep(200);
                                        Console.WriteLine($"İşleminiz başarıyla gerçekleşmiştir. Güncel hesap bakiyeniz: {bakiye} TL.");
                                        Console.WriteLine(" ");
                                    yatırım_menu:
                                        Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                        int yatirimMenu = Convert.ToInt32(Console.ReadLine());

                                        if (yatirimMenu == 9)
                                        {
                                            goto kart_islemleri;
                                        }
                                        else if (yatirimMenu == 0)
                                        {

                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Lütfen geçerli seçeneklerden birini tuşlayın");
                                            Thread.Sleep(2500);
                                            goto yatırım_menu;
                                        }
                                    }
                                }
                                else if (paraYatirimi == 9)
                                {
                                    goto kart_islemleri;
                                }
                                else if (paraYatirimi == 0)
                                {

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen geçerli bir tuşlama yapın");
                                    Thread.Sleep(2000);
                                    goto paraYatırımıMenu;
                                }
                           }
                           else if (kartli_menu == 3)  //------------------------------SEÇİM 3-------------------------------------------------------------------
                           {
                                paraTransferMenu:
                                Console.Clear();
                                Console.WriteLine("Başka hesaba EFT için 1, Havale için 2'yi tuşlayın");
                                Console.WriteLine(" ");
                                Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                int paraTransfer = Convert.ToInt32(Console.ReadLine());

                                eftTrHata:
                                if (paraTransfer == 1)
                                {
                                    eft_menu:
                                    Console.Clear();
                                    Thread.Sleep(500);
                                    Console.WriteLine("Göndereceğiniz EFT numarasının başına 'TR' yazarak 12 haneli numarayı tuşlayın");
                                    string eftNumara = Console.ReadLine();
                                    string eftTR = eftNumara.Substring(0, 2).ToUpper();
                                    string TR = "TR";

                                    if (eftTR == TR)
                                    {
                                        eftNumara = eftNumara.ToUpper();
                                        eftNumara = eftNumara.TrimStart('T').TrimStart('R');
                                        long eftNo = eftNumara.Length;
                                        Console.WriteLine(eftNo);

                                        if (eftNo == 12)
                                        {
                                            string eft_numara_kontrol = eftNumara.Substring(2);
                                            if (double.TryParse(eft_numara_kontrol, out double EFT_rakam))
                                            {
                                            eft_giden:
                                                Console.Clear();
                                                Console.WriteLine("EFT olarak göndermek istediğiniz miktarı tuşlayın");
                                                double eftGiden = Convert.ToInt32(Console.ReadLine());

                                                if (eftGiden > bakiye)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine($"Bakiyeniz bu işlem için yetersiz. Mevcut bakiyeniz: {bakiye} TL.");
                                                    Thread.Sleep(3000);
                                                    goto eft_giden;
                                                }
                                                else if (eftGiden <= 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Lütfen geçerli bir miktar tuşlayın");
                                                    Thread.Sleep(3000);
                                                    goto eft_giden;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Lütfen bekleyin..."); Thread.Sleep(2000);
                                                    bakiye = bakiye - eftGiden;
                                                    Console.Clear(); Thread.Sleep(300);
                                                    Console.WriteLine($"İşleminiz başarıyla gerçekleşmiştir. Güncel bakiyeniz: {bakiye} TL.");
                                                    Console.WriteLine(" ");
                                                eft_son_menu:
                                                    Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                                    int eftAnaMenu = Convert.ToInt32(Console.ReadLine());

                                                    if (eftAnaMenu == 9)
                                                    {
                                                        goto kart_islemleri;
                                                    }
                                                    else if (eftAnaMenu == 0)
                                                    {

                                                    }
                                                    else
                                                    {
                                                    Console.Clear();
                                                    Console.WriteLine("Lütfen geçerli seçeneklerden birini tuşlayın");
                                                    Thread.Sleep(2500);
                                                    goto eft_son_menu;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Numarayı hatalı veya eksik tuşladınız. Lütfen 12 hanenin tamamını tuşlayın");
                                                Thread.Sleep(3500);
                                                goto eft_menu;
                                            }
                                           
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Numarayı hatalı veya eksik tuşladınız. Lütfen 12 hanenin tamamını tuşlayın");
                                            Thread.Sleep(3500);
                                            goto eft_menu;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Lütfen EFT numarasının başına 'TR' ifadesini yazın");
                                        Thread.Sleep(3000);
                                        goto eftTrHata;
                                    }

                                }
                                else if (paraTransfer == 2)
                                {
                                    havale_transfer:
                                    Console.Clear();
                                    Console.WriteLine("Havale göndermek istediğiniz hesabın 11 haneli numarasını girin");
                                    long havaleNo = Convert.ToInt64(Console.ReadLine());

                                    if (havaleNo <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Hatalı veya eksik bir numara tuşladınız.");
                                        Thread.Sleep(2000);
                                        goto havale_transfer;
                                    }
                                    else
                                    {
                                        string havaleNumara = Convert.ToString(havaleNo);
                                        long havaleUzunluk = havaleNumara.Length;

                                        if (havaleUzunluk == 11)
                                        {
                                        havale_giden:
                                            Console.Clear();
                                            Console.WriteLine("Lütfen havale olarak göndermek istediğiniz miktarı tuşlayın");
                                            double havaleGiden = Convert.ToInt32(Console.ReadLine());

                                            if (havaleGiden > bakiye)
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"Bakiyeniz bu işlem için yetersiz. Mevcut bakiyeniz: {bakiye} TL.");
                                                Thread.Sleep(3000);
                                                goto havale_giden;
                                            }
                                            else if (havaleGiden <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Lütfen geçerli bir miktar tuşlayın");
                                                Thread.Sleep(3000);
                                                goto havale_giden;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Lütfen bekleyin..."); Thread.Sleep(2000);
                                                bakiye = bakiye - havaleGiden;
                                                Console.Clear(); Thread.Sleep(300);
                                                Console.WriteLine($"İşleminiz başarıyla gerçekleşmiştir. Güncel bakiyeniz: {bakiye} TL.");
                                                Console.WriteLine(" ");
                                            havale_son_menu:
                                                Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                                int havaleAnaMenu = Convert.ToInt32(Console.ReadLine());

                                                if (havaleAnaMenu == 9)
                                                {
                                                    goto kart_islemleri;
                                                }
                                                else if (havaleAnaMenu == 0)
                                                {

                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Lütfen geçerli seçeneklerden birini tuşlayın");
                                                    Thread.Sleep(2500);
                                                    goto havale_son_menu;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Hatalı veya eksik bir numara tuşladınız. Lütfen tekrar deneyin");
                                            Thread.Sleep(3000);
                                            goto havale_transfer;
                                        }
                                    }
                                }
                                else if (paraTransfer == 9)
                                {
                                    goto kart_islemleri;
                                }
                                else if (paraTransfer == 0)
                                {

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen geçerli seçeneklerden birini tuşlayın");
                                    Thread.Sleep(2500);
                                    goto paraTransferMenu;
                                }

                           }
                           else if (kartli_menu == 4)  //------------------------------SEÇİM 4-------------------------------------------------------------------
                           {
                                Console.Clear();
                                Console.WriteLine("Eğitim ödeme sayfası geçiçi olarak arızalı. Lütfen başka bir işlem seçin");
                                egitim_alt_menu:
                                Console.WriteLine(" ");
                                Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                int egitimMenu = Convert.ToInt32(Console.ReadLine());

                                if (egitimMenu == 9)
                                {
                                    goto kart_islemleri;
                                }
                                else if (egitimMenu == 0)
                                {

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen geçerli bir seçenek tuşlayın");
                                    Thread.Sleep(2000);
                                    goto egitim_alt_menu;
                                }

                           }
                           else if (kartli_menu == 5)  //------------------------------SEÇİM 5-------------------------------------------------------------------
                           {
                                fatura_menu:
                                Console.Clear();
                                Console.WriteLine("Elektrik tafurası ödemesi için 1");
                                Console.WriteLine("Telefon faturası ödemesi için 2");
                                Console.WriteLine("İnternet faturası ödemesi için 3");
                                Console.WriteLine("Su faturası ödemesi için 4");
                                Console.WriteLine("OGS ödemeleri için 5'i tuşlayın");
                                int faturaSecim = Convert.ToInt32(Console.ReadLine());

                                if (faturaSecim < 1 || faturaSecim > 5)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen geçerli seçeneklerden birini tuşlayın");
                                    Thread.Sleep(2500);
                                    goto fatura_menu;
                                }
                                else
                                {
                                fatura_alt_menu:
                                    Console.Clear();
                                    Console.WriteLine("Ödemek istediğiniz fatura miktarını tuşlayın");
                                    double fatura = Convert.ToDouble(Console.ReadLine());

                                    if (fatura <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Lütfen geçerli bir miktar tuşlayın");
                                        Thread.Sleep(2500);
                                        goto fatura_alt_menu;
                                    }
                                    else if (fatura > bakiye)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Bakiyeniz bu işlem için yetersiz. Mevcut bakiyeniz: {bakiye} TL.");
                                        Thread.Sleep(2500);
                                        goto fatura_alt_menu;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Lütfen bekleyin...");
                                        Thread.Sleep(2000);
                                        bakiye = bakiye - fatura;
                                        Console.Clear();
                                        Console.WriteLine($"İşleminiz başarıyla gerçekleşmiştir. Güncel bakiyeniz: {bakiye} TL.");
                                        fatura_menuye_donme:
                                        Console.WriteLine(" ");
                                        Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                        int faturaMenuSecim = Convert.ToInt32(Console.ReadLine());

                                        if (faturaMenuSecim == 9)
                                        {
                                            goto kart_islemleri;
                                        }
                                        else if (faturaMenuSecim == 0)
                                        {

                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Lütfen geçerli seçeneklerden birini tuşlayın");
                                            Thread.Sleep(2500);
                                            goto fatura_menuye_donme;
                                        }
                                    }
                                }
                           }
                           else                        //------------------------------SEÇİM 6-------------------------------------------------------------------
                           {
                            sifre_degistirme:
                                Console.Clear();
                                Console.WriteLine("Mevcut şifrenizi girin:");
                                string girilen_sifre = Console.ReadLine();
                                
                                if (girilen_sifre == sifre)
                                {
                                yeni_sifre:
                                    Console.Clear();
                                    Console.WriteLine("Yeni şifrenizi girin:");
                                    string yeniSifre_1 = Console.ReadLine();
                                    Console.WriteLine("Onaylamak için yeni şifrenizi tekrar girin");
                                    string yeniSifre_2 = Console.ReadLine();

                                    if (yeniSifre_1 == yeniSifre_2)
                                    {
                                        sifre = yeniSifre_1;
                                        Console.Clear();
                                        Console.WriteLine("Şifreniz başarıyla değiştirilmiştir");
                                        sifre_Ana_Menu:
                                        Console.WriteLine(" ");
                                        Console.WriteLine("Ana menüye dönmek için 9, işlemi sonlandırmak için 0' tuşlayın");
                                        int sifreMenu = Convert.ToInt32(Console.ReadLine());

                                        if (sifreMenu == 9)
                                        {
                                            goto kart_islemleri;
                                        }
                                        else if (sifreMenu == 0)
                                        {

                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Lütfen geçerli bir tuşlama yapın");
                                            Thread.Sleep(2000);
                                            goto sifre_Ana_Menu;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(" ");
                                        Console.WriteLine("Yeni şifre uyumu hatalı. Lütfen tekrar deneyin");
                                        Thread.Sleep(2000);
                                        goto yeni_sifre;
                                    }
                                }
                                else
                                {
                                    hataSayisi++;
                                    geriSayim--;
                                    if (hataSayisi > 2)
                                    {
                                        int time = 3600;
                                    timer:
                                        if (time == 0)
                                        {
                                            goto sifre_degistirme;
                                        }
                                        else
                                        {
                                            time--;
                                            Console.Clear();
                                            Console.WriteLine($"Fazla hatalı giriş yaptınız. Tekrar işlem yapabileceğiniz süre: {time}");
                                            Thread.Sleep(1000);
                                            goto timer;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Hatalı giriş yaptınız. Lütfen tekrar deneyin. Kalan hakkınız: {geriSayim}");
                                        Thread.Sleep(4000);
                                        goto sifre_degistirme;
                                    }
                                }
                           }
                        }
                    }
                    else 
                    {
                        hataSayisi++;
                        geriSayim--;
                        if (hataSayisi > 2)
                        {
                            int time = 3600;
                        timer:
                            if (time == 0)
                            {
                                goto kartlı_sifre;
                            }
                            else
                            {
                                time--;
                                Console.Clear();
                                Console.WriteLine($"Fazla hatalı giriş yaptınız. Tekrar işlem yapabileceğiniz süre: {time}");
                                Thread.Sleep(1000);
                                goto timer;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Hatalı giriş yaptınız. Lütfen tekrar deneyin. Kalan hakkınız: {geriSayim}");
                            Thread.Sleep(4000);
                            goto kartlı_sifre;
                        }
                    }
               }
               
                
                //----------------------------------------ANA MENÜ 2 ----------------------------------------------------------------------------------------------------------------------------
                //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                
                
               else 
               {
                kartsızMenu:
                    Console.Clear();
                    Console.WriteLine("CepBank para çekmek için 1");
                    Console.WriteLine("Para yatırmak için 2");
                    Console.WriteLine("Kredi kartı ödemeleri için 3");
                    Console.WriteLine("Eğitim ödemeleri için 4");
                    Console.WriteLine("Fatura ödemeleri için 5'i tuşlayın");
                    int kartsizMenuSecim = Convert.ToInt32(Console.ReadLine());

                    if (kartsizMenuSecim < 1 || kartsizMenuSecim > 5)
                    {
                        Console.Clear();
                        Console.WriteLine("Lütfen geçerli bir tuşlama yapınız");
                        Thread.Sleep(2000);
                        goto kartsızMenu;
                    }
                    else
                    {
                        if (kartsizMenuSecim == 1)       //---------------SEÇİM 1--------------------------------------------------------------------------------------------
                        {
                            Console.Clear();
                            Console.WriteLine("CepBank para çekmek için TC kimlik numaranızı ve telefon numaranızı tuşlayın");
                        tc_no_girisi:
                            Console.WriteLine("TC kimlik numaranız:");
                            string TC = Console.ReadLine();
                            long TC_kontrol = Convert.ToInt64(TC);
                            int TC_uzunluk = TC.Length;

                            if ((TC_uzunluk == 11) && (double.TryParse(TC, out double tc2)) && (TC_kontrol > 0))
                            {
                                hataSayisi = 0;
                                geriSayim = 3;
                                Console.Clear();
                            tel_no_girisi:
                                Console.WriteLine("Telefon numaranızın başına 0 koymadan tuşlayın:");
                                string tel = Console.ReadLine();
                                long tel_kontrol = Convert.ToInt64(tel);
                                int tel_uzunluk = tel.Length;

                                if ((tel_uzunluk == 10) && (double.TryParse(tel, out double tel2)) && (tel.StartsWith('5')) && (tel_kontrol > 0))
                                {
                                    Console.WriteLine("Lütfen bekleyin...");
                                    int cekilen = 1000;
                                    bakiye = bakiye - cekilen;
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    Console.WriteLine($"Hesabınızdan başarıyla 1000 TL çekilmiştir. Güncel bakiyeniz: {bakiye}");
                                cepBank_secim:
                                    Console.WriteLine(" ");
                                    Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                    int cepBank_secim = Convert.ToInt32(Console.ReadLine());

                                    if (cepBank_secim == 9)
                                    {
                                        goto kart_islemleri;
                                    }
                                    else if (cepBank_secim == 0)
                                    {

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Lütfen geçerli bir tuşlama yapın");
                                        Thread.Sleep(3000);
                                        goto cepBank_secim;
                                    }
                                }
                                else
                                {
                                    hataSayisi++;
                                    geriSayim--;
                                    if (hataSayisi > 2)
                                    {
                                        int time = 3600;
                                    Timer:
                                        if (time < 1)
                                        {
                                            goto tc_no_girisi;
                                        }
                                        else
                                        {
                                            time--;
                                            Console.Clear();
                                            Console.WriteLine($"Fazla hatalı giriş yaptınız. tekrar işlem yapabileceğiniz süre: {time}");
                                            Thread.Sleep(1000);
                                            goto Timer;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Telefon numaranızı hatalı veya eksik tuşladınız. Lütfen tekrar deneyin. Kalan hakkınız: {geriSayim}");
                                        Thread.Sleep(4000);
                                        Console.Clear();
                                        goto tel_no_girisi;
                                    }
                                }
                            }
                            else
                            {
                                hataSayisi++;
                                geriSayim--;
                                if (hataSayisi > 2)
                                {
                                    int time = 3600;
                                Timer:
                                    if (time < 1)
                                    {
                                        goto tc_no_girisi;
                                    }
                                    else
                                    {
                                        time--;
                                        Console.Clear();
                                        Console.WriteLine($"Fazla hatalı giriş yaptınız. tekrar işlem yapabileceğiniz süre: {time}");
                                        Thread.Sleep(1000);
                                        goto Timer;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"TC kimlik numaranızı hatalı veya eksik tuşladınız. Lütfen tekrar deneyin. Kalan hakkınız: {geriSayim}");
                                    Thread.Sleep(4000);
                                    Console.Clear();
                                    goto tc_no_girisi;
                                }
                            }

                        }
                        else if (kartsizMenuSecim == 2)  //---------------SEÇİM 2--------------------------------------------------------------------------------------------
                        {
                        para_yatırma:
                            Console.Clear();
                            Console.WriteLine($"Nakit ödemek için 1, hesaptan ödeme yapmak için 2'yi tuşlayın. Mevcut hesap bakiyesi {bakiye}");
                            Console.WriteLine(" ");
                            Console.WriteLine("Ana menüye dönmek için 9, işlemi sonlandırmak için 0'ı tuşlayın");
                            int para_yatirma_secim = Convert.ToInt32(Console.ReadLine());

                            if (para_yatirma_secim == 1)
                            {
                            kredi_kartı_giris:
                                Console.Clear();
                                Console.WriteLine("Kredi kartınızın 12 haneli numarasını tuşlayın:");
                                string kart_numarasi = Console.ReadLine();
                                long kart_no = Convert.ToInt64(kart_numarasi);
                                long kart_no_uzunluk = kart_numarasi.Length;

                                if ((kart_no_uzunluk == 12) && (double.TryParse(kart_numarasi, out double kart_uzunluk)) && (kart_no > 0))
                                {
                                    Console.Clear();
                                tc_no_girisi:
                                    Console.WriteLine("11 haneli TC kimlik numaranızı tuşlayın:");
                                    string TC = Console.ReadLine();
                                    long TC_kontrol = Convert.ToInt64(TC);
                                    int TC_uzunluk = TC.Length;

                                    if ((TC_uzunluk == 11) && (double.TryParse(TC, out double tc2)) && (TC_kontrol > 0))
                                    {
                                    nakit_yatırılacak_miktar:
                                        Console.Clear();
                                        Console.WriteLine("Nakit olarak yatırmak istediğiniz miktarı tuşlayın:");
                                        int nakit_yatan = Convert.ToInt32(Console.ReadLine());

                                        if (nakit_yatan <= 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Lütfen geçerli bir miktar tuşlayın");
                                            Thread.Sleep(3000);
                                            goto nakit_yatırılacak_miktar;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Lütfen bekleyin...");
                                            Thread.Sleep(2000);
                                            bakiye = bakiye + nakit_yatan;
                                            Console.Clear();
                                        para_yatırma_menu:
                                            Console.WriteLine($"İşleminiz başarıyla gerçekleşmiştir. Güncel bakiyeniz: {bakiye} TL.");
                                            Console.WriteLine(" ");
                                            Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                            int para_yatirma_menu_secimi = Convert.ToInt32(Console.ReadLine());

                                            if (para_yatirma_menu_secimi == 9)
                                            {
                                                goto kart_islemleri;
                                            }
                                            else if (para_yatirma_menu_secimi == 0)
                                            {

                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Lütfen geçerli bir seçenek tuşlayın.");
                                                Thread.Sleep(2000);
                                                goto para_yatırma_menu;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("TC kimlik numaranızı hatalı veya eksik tuşladınız. Lütfen tekrar deneyin.");
                                        Thread.Sleep(3500);
                                        Console.Clear();
                                        goto tc_no_girisi;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Kart numaranızı hatalı veya eksik tuşladınız. Lütfen tekrar deneyin");
                                    Thread.Sleep(3000);
                                    goto kredi_kartı_giris;
                                }
                            }
                            else if (para_yatirma_secim == 2)
                            {
                            kredi_kart_girisi:
                                Console.Clear();
                                Console.WriteLine("Kredi kartınızın 12 haneli numarasını tuşlayın.");
                                string kart_numarasi = Console.ReadLine();
                                long kart_numarası_kontrol = Convert.ToInt64(kart_numarasi);
                                int kart_numarası_uzunluk = kart_numarasi.Length;

                                if ((kart_numarası_uzunluk == 12) && (double.TryParse(kart_numarasi, out double kart_num2)) && (kart_numarası_kontrol > 0))
                                {
                                hesap_no_girisi:
                                    Console.Clear();
                                    Console.WriteLine("Lütfen 8 haneli hesap numaranızı tuşlayın");
                                    string hesap_numarasi = Console.ReadLine();
                                    int hesap_numarası_kontrol = Convert.ToInt32(hesap_numarasi);
                                    int hesap_numarası_uzunluk = hesap_numarasi.Length;

                                    if ((hesap_numarası_uzunluk == 8) && (double.TryParse(hesap_numarasi, out double hesap_num2)) && (hesap_numarası_kontrol > 0))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Doğrulama başarılı");
                                    kredi_odemesi:
                                        Console.WriteLine("Kredi kartı için ödeyeceğiniz miktarı tuşlayın");
                                        int odenecek_miktar = Convert.ToInt32(Console.ReadLine());

                                        if (odenecek_miktar <= 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Lütfen geçerli bir değer tuşlayın");
                                            Thread.Sleep(2000);
                                            goto kredi_odemesi;
                                        }
                                        else if (odenecek_miktar > bakiye)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Bakiyeniz bu ödeme için yetersiz. Lütfen geçerli bir miktar tuşlayın. Mevcut bakiyeniz: {bakiye}");
                                            Thread.Sleep(3000);
                                            goto kredi_odemesi;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Lütfen bekleyin...");
                                            Thread.Sleep(1000);
                                            bakiye = bakiye - odenecek_miktar;
                                            Console.Clear();
                                            Console.WriteLine($"İşleminiz başarıyla gerçekleşmiştir. Güncel bakiyeniz: {bakiye}");
                                        kredi_ana_menuye_donus:
                                            Console.WriteLine(" ");
                                            Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                            int kredi_menu_secim = Convert.ToInt32(Console.ReadLine());

                                            if (kredi_menu_secim == 9)
                                            {
                                                goto kart_islemleri;
                                            }
                                            else if (kredi_menu_secim == 0)
                                            {

                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Lütfen geçerli bir seçenek tuşlayın");
                                                Thread.Sleep(2000);
                                                goto kredi_ana_menuye_donus;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Hesap numaranızı eksik veya hatalı tuşladınız. Lütfen tekrar deneyin");
                                        Thread.Sleep(3000);
                                        goto hesap_no_girisi;
                                    }

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Kart numaranızı eksik veya hatalı tuşladınız. Lütfen tekrar deneyin");
                                    Thread.Sleep(3000);
                                    goto kredi_kart_girisi;
                                }


                            }
                            else if (para_yatirma_secim == 9)
                            {
                                goto kart_islemleri;
                            }
                            else if (para_yatirma_secim == 0)
                            {

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen geçerli bir tuşlama yapın");
                                Thread.Sleep(1500);
                                goto para_yatırma;
                            }
                        }
                        else if (kartsizMenuSecim == 3)  //---------------SEÇİM 3--------------------------------------------------------------------------------------------
                        {
                        paraTransferMenu:
                            Console.Clear();
                            Console.WriteLine("Başka hesaba EFT için 1, Havale için 2'yi tuşlayın");
                            Console.WriteLine(" ");
                            Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                            int paraTransfer = Convert.ToInt32(Console.ReadLine());

                        eftTrHata:
                            if (paraTransfer == 1)
                            {
                            eft_menu:
                                Console.Clear();
                                Thread.Sleep(500);
                                Console.WriteLine("Göndereceğiniz EFT numarasının başına 'TR' yazarak 12 haneli numarayı tuşlayın");
                                string eftNumara = Console.ReadLine();
                                string eftTR = eftNumara.Substring(0, 2).ToUpper();
                                string TR = "TR";

                                if (eftTR == TR)
                                {
                                    eftNumara = eftNumara.ToUpper();
                                    eftNumara = eftNumara.TrimStart('T').TrimStart('R');
                                    long eftNo = eftNumara.Length;
                                    Console.WriteLine(eftNo);

                                    if (eftNo == 12)
                                    {
                                        string eft_numara_kontrol = eftNumara.Substring(2);
                                        if (double.TryParse(eft_numara_kontrol, out double EFT_rakam))
                                        {
                                        eft_giden:
                                            Console.Clear();
                                            Console.WriteLine("EFT olarak göndermek istediğiniz miktarı tuşlayın");
                                            double eftGiden = Convert.ToInt32(Console.ReadLine());

                                            if (eftGiden > bakiye)
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"Bakiyeniz bu işlem için yetersiz. Mevcut bakiyeniz: {bakiye} TL.");
                                                Thread.Sleep(3000);
                                                goto eft_giden;
                                            }
                                            else if (eftGiden <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Lütfen geçerli bir miktar tuşlayın");
                                                Thread.Sleep(3000);
                                                goto eft_giden;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Lütfen bekleyin..."); Thread.Sleep(2000);
                                                bakiye = bakiye - eftGiden;
                                                Console.Clear(); Thread.Sleep(300);
                                                Console.WriteLine($"İşleminiz başarıyla gerçekleşmiştir. Güncel bakiyeniz: {bakiye} TL.");
                                                Console.WriteLine(" ");
                                            eft_son_menu:
                                                Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                                int eftAnaMenu = Convert.ToInt32(Console.ReadLine());

                                                if (eftAnaMenu == 9)
                                                {
                                                    goto kart_islemleri;
                                                }
                                                else if (eftAnaMenu == 0)
                                                {

                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Lütfen geçerli seçeneklerden birini tuşlayın");
                                                    Thread.Sleep(2500);
                                                    goto eft_son_menu;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Numarayı hatalı veya eksik tuşladınız. Lütfen 12 hanenin tamamını tuşlayın");
                                            Thread.Sleep(3500);
                                            goto eft_menu;
                                        }

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Numarayı hatalı veya eksik tuşladınız. Lütfen 12 hanenin tamamını tuşlayın");
                                        Thread.Sleep(3500);
                                        goto eft_menu;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen EFT numarasının başına 'TR' ifadesini yazın");
                                    Thread.Sleep(3000);
                                    goto eftTrHata;
                                }

                            }
                            else if (paraTransfer == 2)
                            {
                            havale_transfer:
                                Console.Clear();
                                Console.WriteLine("Havale göndermek istediğiniz hesabın 11 haneli numarasını girin");
                                long havaleNo = Convert.ToInt64(Console.ReadLine());

                                if (havaleNo <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Hatalı veya eksik bir numara tuşladınız.");
                                    Thread.Sleep(2000);
                                    goto havale_transfer;
                                }
                                else
                                {
                                    string havaleNumara = Convert.ToString(havaleNo);
                                    long havaleUzunluk = havaleNumara.Length;

                                    if (havaleUzunluk == 11)
                                    {
                                    havale_giden:
                                        Console.Clear();
                                        Console.WriteLine("Lütfen havale olarak göndermek istediğiniz miktarı tuşlayın");
                                        double havaleGiden = Convert.ToInt32(Console.ReadLine());

                                        if (havaleGiden > bakiye)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Bakiyeniz bu işlem için yetersiz. Mevcut bakiyeniz: {bakiye} TL.");
                                            Thread.Sleep(3000);
                                            goto havale_giden;
                                        }
                                        else if (havaleGiden <= 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Lütfen geçerli bir miktar tuşlayın");
                                            Thread.Sleep(3000);
                                            goto havale_giden;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Lütfen bekleyin..."); Thread.Sleep(2000);
                                            bakiye = bakiye - havaleGiden;
                                            Console.Clear(); Thread.Sleep(300);
                                            Console.WriteLine($"İşleminiz başarıyla gerçekleşmiştir. Güncel bakiyeniz: {bakiye} TL.");
                                            Console.WriteLine(" ");
                                        havale_son_menu:
                                            Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                            int havaleAnaMenu = Convert.ToInt32(Console.ReadLine());

                                            if (havaleAnaMenu == 9)
                                            {
                                                goto kart_islemleri;
                                            }
                                            else if (havaleAnaMenu == 0)
                                            {

                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Lütfen geçerli seçeneklerden birini tuşlayın");
                                                Thread.Sleep(2500);
                                                goto havale_son_menu;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Hatalı veya eksik bir numara tuşladınız. Lütfen tekrar deneyin");
                                        Thread.Sleep(3000);
                                        goto havale_transfer;
                                    }
                                }
                            }
                            else if (paraTransfer == 9)
                            {
                                goto kart_islemleri;
                            }
                            else if (paraTransfer == 0)
                            {

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen geçerli seçeneklerden birini tuşlayın");
                                Thread.Sleep(2500);
                                goto paraTransferMenu;
                            }
                        }
                        else if (kartsizMenuSecim == 4)  //---------------SEÇİM 4--------------------------------------------------------------------------------------------
                        {
                            Console.Clear();
                            Console.WriteLine("Eğitim ödeme sayfası geçiçi olarak arızalı. Lütfen başka bir işlem seçin");
                        egitim_alt_menu:
                            Console.WriteLine(" ");
                            Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                            int egitimMenu = Convert.ToInt32(Console.ReadLine());

                            if (egitimMenu == 9)
                            {
                                goto kart_islemleri;
                            }
                            else if (egitimMenu == 0)
                            {

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen geçerli bir seçenek tuşlayın");
                                Thread.Sleep(2000);
                                goto egitim_alt_menu;
                            }
                        }
                        else                             //---------------SEÇİM 5--------------------------------------------------------------------------------------------
                        {
                        fatura_menu:
                            Console.Clear();
                            Console.WriteLine("Elektrik tafurası ödemesi için 1");
                            Console.WriteLine("Telefon faturası ödemesi için 2");
                            Console.WriteLine("İnternet faturası ödemesi için 3");
                            Console.WriteLine("Su faturası ödemesi için 4");
                            Console.WriteLine("OGS ödemeleri için 5'i tuşlayın");
                            int faturaSecim = Convert.ToInt32(Console.ReadLine());

                            if (faturaSecim < 1 || faturaSecim > 5)
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen geçerli seçeneklerden birini tuşlayın");
                                Thread.Sleep(2500);
                                goto fatura_menu;
                            }
                            else
                            {
                            fatura_alt_menu:
                                Console.Clear();
                                Console.WriteLine("Ödemek istediğiniz fatura miktarını tuşlayın");
                                double fatura = Convert.ToDouble(Console.ReadLine());

                                if (fatura <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen geçerli bir miktar tuşlayın");
                                    Thread.Sleep(2500);
                                    goto fatura_alt_menu;
                                }
                                else if (fatura > bakiye)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Bakiyeniz bu işlem için yetersiz. Mevcut bakiyeniz: {bakiye} TL.");
                                    Thread.Sleep(2500);
                                    goto fatura_alt_menu;
                                }
                                else
                                {
                                    Console.WriteLine("Lütfen bekleyin...");
                                    Thread.Sleep(2000);
                                    bakiye = bakiye - fatura;
                                    Console.Clear();
                                    Console.WriteLine($"İşleminiz başarıyla gerçekleşmiştir. Güncel bakiyeniz: {bakiye} TL.");
                                fatura_menuye_donme:
                                    Console.WriteLine(" ");
                                    Console.WriteLine("Ana menüye dönmek için 9, işlemi tamamlamak için 0'ı tuşlayın");
                                    int faturaMenuSecim = Convert.ToInt32(Console.ReadLine());

                                    if (faturaMenuSecim == 9)
                                    {
                                        goto kart_islemleri;
                                    }
                                    else if (faturaMenuSecim == 0)
                                    {

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Lütfen geçerli seçeneklerden birini tuşlayın");
                                        Thread.Sleep(2500);
                                        goto fatura_menuye_donme;
                                    }
                                }
                            }
                        }
                    }
               }
            }
        }
    }
}
