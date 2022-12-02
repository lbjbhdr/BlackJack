using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deste
{
    internal class Program
    {

        static int hesapla(List<string> liste)
        {
            int acount = 0;

            int toplam = 0;
            for (int i = 0; i < liste.Count; i++)
            {
                if (liste[i].EndsWith("11") || liste[i].EndsWith("12") || liste[i].EndsWith("13"))
                {
                    toplam += 10;
                }
                else if (liste[i].EndsWith("1"))
                {
                    acount++;
                }
                else
                {
                    toplam += Convert.ToInt32(liste[i].Remove(0, 2));
                }
            }
            if (acount == 1 && toplam == 10)
            {
                //blackjack
                toplam += 11;
            }
            else if (acount == 1 && toplam > 11)
            {
                toplam += 1;
            }
            else if (acount == 1 && toplam < 10)
            {
                Console.WriteLine("toplam= " + (toplam + 1).ToString() + "toplam=" + (toplam + 11).ToString());
            }
            return toplam;
        }

        static List<string> deste = new List<string>();
        
        private static string KartCek()
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(1, deste.Count);
            string cekilenkart = deste[sayi];
            deste.RemoveAt(sayi);
            return cekilenkart; 
        }

        

        /// <summary>
        /// Fonksiyon birinci liste büyükk ise 1 ikinci liste büytük ise -1 eşit ise 0 döndürür.
        /// </summary>
        /// <param name="kullanici"></param>
        /// <param name="kasa"></param>
        /// <returns></returns>
        private static int Kıyasla(List<string> kullanici,List<string> kasa)
        {
            int kullanıiciPuan = hesapla(kullanici);
            int kasaPuan = hesapla(kasa);
            

            
            if (kullanıiciPuan > kasaPuan)
            {
                return 1;
            }
            else if (kullanıiciPuan < kasaPuan)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }


        private static int GamePlay()
        {

            string ilkkart = "Ku";
            int i;
            for (int k = 1; k <= 7; k++)
            {
                for (i = 1; i <= 13; i++)
                {
                    ilkkart += i;
                    deste.Add(ilkkart);
                    ilkkart = "Ku";
                }
                ilkkart = "Ka";
                for (i = 1; i <= 13; i++)
                {
                    ilkkart = ilkkart + i;
                    deste.Add(ilkkart);
                    ilkkart = "Ka";
                }
                ilkkart = "Ma";
                for (i = 1; i <= 13; i++)
                {
                    ilkkart = ilkkart + i;
                    deste.Add(ilkkart);
                    ilkkart = "Ma";
                }
                ilkkart = "Si";
                for (i = 1; i <= 13; i++)
                {
                    ilkkart = ilkkart + i;
                    deste.Add(ilkkart);
                    ilkkart = "Si";
                }
            }
            //for (int j = 0; j < deste.Count; j++)
            //{
            //    Console.WriteLine(deste[j]);
            //}
            //BURAAAAAAAAAk
            //kart çekme ve desteden azaltma çekilen kartı




            List<string> kasaList = new List<string>();
            List<string> kullanıcıList = new List<string>();
            Console.WriteLine("BLACKJACK'A HOŞGELDİNİZ");
            //eklenecek kartlar
            string kasakart = KartCek();

            //kart çekme func
            Console.WriteLine("Kasa gelen kart : {0}", kasakart);
            kasaList.Add(kasakart);
            //kasa 2. yi çeker ama göstermez 
            kasakart = KartCek();
            kasaList.Add(kasakart);
            string kullanıcıkart = KartCek();
            kullanıcıList.Add(kullanıcıkart);
            kullanıcıkart = KartCek();
            kullanıcıList.Add(kullanıcıkart);
            Console.WriteLine("Size gelen kartlar : ");
            kullanıcıList.ForEach(c => { Console.Write(c); });
            Console.WriteLine("");

            int kullanıcıSayi = hesapla(kullanıcıList);

            //bu evrede blackjack var mı diye kontrol edilir blackjack değil ise devam edilir
            Console.WriteLine("Toplam : {0}\nKart çekmek ister misiniz ? \t Evet ise : e      Hayır ise : h ", kullanıcıSayi);

            char evet = 'e', hayır = 'h', cevap;
            //evet der ise kart çekme / hayır der ise hesaplama 
            //evet;
            int flag = 0;
            while (flag == 0)
            {

                cevap = Convert.ToChar(Console.ReadLine());

                try
                {
                    if (evet == cevap)
                    {
                        kullanıcıList.Add(KartCek());

                        flag++;
                        Console.WriteLine("Size gelen kartlar : ");
                        kullanıcıList.ForEach(c => { Console.Write(c); });
                        Console.WriteLine("");
                        hesapla(kullanıcıList);
                        if (hesapla(kullanıcıList) == 21)
                        {
                            Console.WriteLine("************Blackjack***********");
                        }
                        else if (hesapla(kullanıcıList) < 21)
                        {
                            flag = 0;
                            while (flag == 0)
                            {

                                cevap = Convert.ToChar(Console.ReadLine());

                                try
                                {
                                    if (evet == cevap)
                                    {
                                        kullanıcıList.Add(KartCek());

                                        flag++;
                                    }
                                    else if (hayır == cevap)
                                    {
                                        flag++;
                                    }
                                    else
                                        Console.WriteLine("yanlış karakter girişi yaptınız");


                                }
                                catch (Exception)
                                {

                                    Console.WriteLine("Adam akıllı oyna oyunu e yada h yazacan");
                                }
                            }
                        }
                    }
                    else if (hayır == cevap)
                    {
                        flag++;
                    }
                    else
                        Console.WriteLine("yanlış karakter girişi yaptınız");


                }
                catch (Exception)
                {

                    Console.WriteLine("Adam akıllı oyna oyunu e yada h yazacan");
                }
            }

            //Console.WriteLine("Çektiğiniz kart : {0}", kullanıcıkart);

            //bj mi 21 den büyük mü hesapla /21 den küçük veya bj değil ise tekrar sor kart istiyor mu diye 
            //Hayır dediğinde kasa ile kıyaslama başlar

            while (hesapla(kasaList) < 17)
            {
                kasaList.Add(KartCek());
                Console.WriteLine("Kasanın Çektiği kart : {0}", kasaList.Last());
            }
            Console.WriteLine("Kasanın kartları : ");
            kasaList.ForEach(c => { Console.Write(c); });
            Console.WriteLine("");
            int sonuc = Kıyasla(kullanıcıList, kasaList);
            if (sonuc == 1 || (hesapla(kasaList) > 21 && hesapla(kullanıcıList) < 21))
            {
                Console.WriteLine("Tebrikler kazandınız \t Siz: {0}    Kasa: {1}", hesapla(kullanıcıList), hesapla(kasaList));
            }
            else if (sonuc == -1)
            {
                Console.WriteLine("Üzgünüz Kasa kazandı \t Siz:  \"{0}\"    Kasa: {1} \"", hesapla(kullanıcıList), hesapla(kasaList));
            }
            else
                Console.WriteLine("Berabere");


            cevap = 'e';
            char[] cevaplar = { 'e', 'h' };
            
            while (cevaplar.Contains(cevap))
            {
                
                Console.WriteLine("///////////////////////GAME OVER////////////////////////////");

                Console.WriteLine("////////////////////////////////////////////////////////////");
                Console.WriteLine("Tekrar oynamak ister misiniz Evet ise : e      Hayır ise : h");
                Console.WriteLine("////////////////////////////////////////////////////////////");
                
                cevap = Convert.ToChar(Console.ReadLine());
                
                try
                {
                    if (evet == cevap)
                    {
                        return 0;
                    }
                    else 
                        return -1;
                }
                catch
                {

                    Console.WriteLine("Tekrar oynamak ister misiniz Evet ise : e      Hayır ise : h");
                    cevap = Convert.ToChar(Console.ReadLine());
                }
            }
            return -1;
                    


        }


        static void Main(string[] args)
        {


            int durum = 0;
            //durum = Convert.ToChar(Console.ReadLine());
            while (durum == 0)
            {
                durum = GamePlay();
            }

            Console.ReadLine();
        }
    }
}
