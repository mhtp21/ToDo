using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Seçiniz.");
            Console.WriteLine("**************************************");

            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");

            Surec(int.Parse(Console.ReadLine()));
        }

        static void Surec(int secim)
        {
            switch (secim)
            {
                case 1: PanoSureciListeleme(); break;
                case 2: PanoKartEkleme(); break;
                case 3: PanoKartSilme(); break;
                case 4: KartTasima(); break;
                default: Console.WriteLine("Hatalı İşlem."); 
                MainMenu(); 
                break;

            }
        }

        static void PanoSureciListeleme()
        {
            BoardManager boardManager = new BoardManager();
            var BoardTypes = boardManager.ListBoardTypes();

            PanoYapilacakListele(BoardTypes.Where(i => i.Status == StatusType.TODO).Select(i => new Card()
            {
                Title = i.Card.Title,
                Content = i.Card.Content,
                MemberId = i.Card.MemberId,
                Size = i.Card.Size
            }).ToList());

            PanoYapilacakListele(BoardTypes.Where(i => i.Status == StatusType.INPROGRESS).Select(i => new Card()
            {
                Title = i.Card.Title,
                Content = i.Card.Content,
                MemberId = i.Card.MemberId,
                Size = i.Card.Size
            }).ToList());

            PanoYapilacakListele(BoardTypes.Where(i => i.Status == StatusType.DONE).Select(i => new Card()
            {
                Title = i.Card.Title,
                Content = i.Card.Content,
                MemberId = i.Card.MemberId,
                Size = i.Card.Size
            }).ToList());

            MainMenu();
        }



        static void PanoYapilacakListele(List<Card> cards)
        {
            AssociateManager associateManager = new AssociateManager();

            Console.WriteLine("TODO Line");
            Console.WriteLine("*****************");

            foreach (var card in cards)
            {
                Console.WriteLine("Başlık : " + card.Title);
                Console.WriteLine("İçerik : " + card.Content);
                Console.WriteLine("Atanan Kişi : " + associateManager.FindAssocciate(card.MemberId).FullName);
                Console.WriteLine("Büyüklük : " + card.Size.ToString());
                Console.WriteLine("--------------------------------------------");
            }
        }

        private static void PanoİlerlemeListele(List<Card> cards)
        {
            AssociateManager associateManager = new AssociateManager();
            Console.WriteLine("IN PROGRESS Line");
            Console.WriteLine("*****************");

            foreach (var card in cards)
            {
                Console.WriteLine("Başlık : " + card.Title);
                Console.WriteLine("İçerik : " + card.Content);
                Console.WriteLine("Atanan Kişi : " + associateManager.FindAssocciate(card.MemberId).FullName);
                Console.WriteLine("Büyüklük : " + card.Size.ToString());
                Console.WriteLine("--------------------------------------------");
            }

        }

        private static void PanoTamamlananListele(List<Card> cards)
        {
            AssociateManager associateManager = new AssociateManager();
            Console.WriteLine("DONE Line");
            Console.WriteLine("*****************");

            foreach (var card in cards)
            {
                Console.WriteLine("Başlık : " + card.Title);
                Console.WriteLine("İçerik : " + card.Content);
                Console.WriteLine("Atanan Kişi : " + associateManager.FindAssocciate(card.MemberId).FullName);
                Console.WriteLine("Büyüklük : " + card.Size.ToString());
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void PanoKartEkleme()
        {
            Card card = new Card();
            AssociateManager associateManager = new AssociateManager();
            BoardManager boardManager = new BoardManager();

            Console.WriteLine("Başlık Giriniz");
            card.Title = Console.ReadLine();

            Console.WriteLine("İçerik Giriniz");
            card.Content = Console.ReadLine();

            Console.WriteLine("Büyüklük Giriniz => XS(1), S(2), M(3), L(4), XL(5)");
            card.Size = (SizeType)int.Parse(Console.ReadLine());

            Console.WriteLine("Kişi Numarası Giriniz");
            int memberId = int.Parse(Console.ReadLine());

            if(associateManager.FindAssocciate(memberId) == null)
            {
                Console.WriteLine("Girilen Numarada Kullanıcı Bulunamadı.");
                MainMenu();
            }

            card.MemberId = memberId;
            var result = boardManager.AddCardToBoard(card);

            if (result) { Console.WriteLine("Kart Başarıyla Board'a Eklendi."); }
            else { Console.WriteLine("Kart Board'a Eklenemedi."); }

            MainMenu();
        }

        static void PanoKartSilme()
        {
            Console.WriteLine("Öncelikle Silmek İstediğiniz Kartı Seçmeniz Gerekiyor.");
            Console.WriteLine("Lütfen Kart Başlığını Yazınız.");

            BoardManager boardManager = new BoardManager();
            var findBoardElement = boardManager.FindBoardElementByCard(Console.ReadLine());

            if (findBoardElement == null)
            {
                Console.WriteLine("Aradığınız Kart Bulunamadı.");
                Console.WriteLine("Ana Menüye Dön (1)");
                Console.WriteLine("Tekrar Dene (2)");

                int surectur = int.Parse(Console.ReadLine());

                if (surectur == 1)
                    MainMenu();
                else if (surectur == 2)
                    PanoKartSilme();
            }

            var result = boardManager.RemoveBoardTypes(findBoardElement);

            if (result)
                Console.WriteLine("Kart Başarıyla Board'dan Silindi.");
            else
                Console.WriteLine("Kart Board'dan Silinemedi.");

            MainMenu();

        }

        static void KartTasima()
        {
            Console.WriteLine("Öncelikle Taşımak İstediğiniz Kartı Seçmeniz Gerekiyor.");
            Console.WriteLine("Lütfen Kart Başlığını Yazınız.");

            BoardManager boardManager = new BoardManager();
            var findBoardElement = boardManager.FindBoardElementByCard(Console.ReadLine());

            if (findBoardElement == null)
            {
                Console.WriteLine("Aradığınız Kart Bulunamadı.");
                Console.WriteLine("Ana Menüye Dön (1)");
                Console.WriteLine("Tekrar Dene (2)");

                int surectur = int.Parse(Console.ReadLine());

                if (surectur == 1)
                    MainMenu();
                else if (surectur == 2)
                    KartTasima();
                else
                {
                    Console.WriteLine("Sayi girin");
                }
            }

            KartElemanAyrinti(findBoardElement);
            DegisenMetin();
            int satirDegeri = int.Parse(Console.ReadLine());

            if(satirDegeri <1 || satirDegeri > 3)
            {
                Console.WriteLine("Hatalı Seçim Yaptınız.");
                MainMenu();
            }

            findBoardElement.Status = (StatusType)satirDegeri;
            var result = boardManager.TransportCard(findBoardElement);

            if (result)
                Console.WriteLine("Kart Başarıyla Taşındı.");
            else
                Console.WriteLine("Kart Taşınamadı.");

            MainMenu();

        }

        static void KartElemanAyrinti(BoardTypes boardTypes)
        {
            AssociateManager associateManager = new AssociateManager();

            Console.WriteLine("Bulunan Kart Bilgileri");
            Console.WriteLine("************************************");
            Console.WriteLine("Başlık : " + boardTypes.Card.Title);
            Console.WriteLine("İçerik : " + boardTypes.Card.Content);
            Console.WriteLine("Atanan Kişi : " + associateManager.FindAssocciate(boardTypes.Card.MemberId).FullName);
            Console.WriteLine("Büyüklük : " + boardTypes.Card.Size.ToString());
            Console.WriteLine("Line : " + (boardTypes.Status.ToString()));
        }

        private static void DegisenMetin()
        {
            Console.WriteLine("Lütfen Taşımak İstediğiniz Line'ı Seçiniz.");
            Console.WriteLine("(1) TODO");
            Console.WriteLine("(2) IN PROGRESS");
            Console.WriteLine("(3) DONE");
        }
    }
}
