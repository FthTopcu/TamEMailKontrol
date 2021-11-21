using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emailOdev
{
    class Program
    {
        static void Main(string[] args)
        {

            string mailAdresi;
            bool dogru = false;

            List<string> mail = new List<string>();
            string mesaj = "Kardeşim anlamıyo musun yanlış dedik!!!!";
            mesaj = mesaj.ToUpper();
            string[] dizi = mesaj.Split(' ');
        yeniKayit:
            int yanlisSayisi = 0;
            do
            {
                Console.WriteLine("E posta adresini giriniz :");
                mailAdresi = Console.ReadLine();
                mailAdresi = mailAdresi.Trim();
                int eSayisi = 0;
                int ozelKarakterSayisi = 0;
                foreach (var item in mailAdresi)
                {
                    if (item == '@') eSayisi++;
                    if (item == 'Ş' || item == 'ş' || item == 'İ' || item == 'ı' || item == 'ö' || item == 'Ö' ||
                        item == 'ç' || item == 'Ç' || item == 'Ü' || item == 'ü' || item == 'ğ' || item == 'Ğ')
                    {
                        ozelKarakterSayisi++;
                    }
                }
                if (!(ozelKarakterSayisi > 0))
                {
                    if (!(eSayisi > 1))
                    {
                        if (!mailAdresi.StartsWith("@"))
                        {
                            if (mailAdresi.EndsWith("@hotmail.com") || mailAdresi.EndsWith("@gmail.com"))
                            {
                                if (!mailAdresi.Contains(" "))
                                {
                                    if (!mail.Contains(mailAdresi))
                                    {
                                        mail.Add(mailAdresi);
                                        dogru = true;
                                    }
                                    else Console.WriteLine("bu mail adresiyle daha önceden kayıt yapılmış!!");
                                }
                                else Console.WriteLine("mail adresi boşluk karakteri içeremez!!");
                            }
                            else Console.WriteLine("mail adresi @gmail.com veya @hotmail.com ile bitmelidir!!");
                        }
                        else Console.WriteLine("mail adresi @ ile başlayamaz!!");
                    }
                    else Console.WriteLine("Mail adresi @ içeremez!!");
                }
                else Console.WriteLine("Mail adresi özel karakter içeremez!!");
                yanlisSayisi++;
                if (yanlisSayisi == 3)
                {
                    for (int i = 0; i < dizi.Length; i++)
                    {
                        Console.WriteLine(dizi[i]);
                        yanlisSayisi = 0;
                    }
                }
            } while (!dogru);
            Console.WriteLine("kayıt yapıldı :" + mailAdresi);
            Console.Write("Yeni kayıt yapmak istiyor musunuz? E/H tuşlayınız :");
            string secim = Console.ReadLine();

            if (secim.ToLower() == "e")
                goto yeniKayit;
            else
                Console.WriteLine("İyi Günler Dileriz...");
            Console.ReadLine();
        }
    }
}
