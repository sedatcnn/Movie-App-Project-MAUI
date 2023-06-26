using WebApplication1.EF;

namespace WebApplication1.Models
{
    public class YabancıFılmler
    {
        public void Yabancı()
        {
            FılmContext context = new FılmContext();
            string[] LouisTur = { "Biyografik", "Dram", "Tarih" };
            string louisTur = string.Join(",", LouisTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Filmler",
                FılmAdı = "Louis Wain'in Renkli Dünyası",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "31 Aralık 2021",
                FılmTur = louisTur,
                KullanıcıPuanı = 6.8,
                Acıklama = "Şakacı, saykodelik resimleri halkın kedi algısını sonsuza dek değiştiren eksantrik İngiliz sanatçı Louis Wain'in gerçek hikayesi. " +
                "1900'lerin başında geçen bu filmde, dünyanın 'elektriksel' gizemlerini çözmeye çalışan ve bunu yaparken de kendi hayatını ve " +
                "eşi Emily Richardson ile paylaştığı derin aşkı daha iyi anlamaya çalışan Wain'i takip ediyoruz.",
                Yonetmen = "Will Sharpe",
                Senarist = "Simon Stephenson, Will Sharpe",
                Oyuncular = "Benedict Cumberbatch,Claire Foy,Andrea Riseborough",
                FotoUrl = "louise_wan.jpg",

            });
            string[] DuneTur = { "Bilimkurgu", "Aksiyon", " Dram" };
            string duneTur = string.Join(",", DuneTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Filmler",
                FılmAdı = "Dune: Çöl Gezegeni",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "22 Ekim 2021",
                FılmTur = duneTur,
                KullanıcıPuanı = 8.0,
                Acıklama = "Uzak bir gelecekte geçen 'Dune', ailesi çöl gezegeni Arrakis’in kontrolüne sahip olan Paul Atreides’in hikayesini anlatıyor. " +
                "Galaksinin farklı noktalarındaki gezegenler, rakip feodal aileler tarafından yönetilmektedir." +
                " Çok değerli bir kaynağın tek üreticisi olan çöl gezegeni Arrakis'in kontrolü asil aileler arasında son derece talep görmektedir." +
                " 'Baharat' adı verilen bu kaynak, yüksek bilinç ve uzun bir yaşam süresi sunarken, beraberinde çok ciddi yan etkileri de getirmektedir. " +
                "Ayrıca yıldızlararası yollarda gezinmeye yardımcı olan kaynak da bu 'Baharat'tır." +
                " Bu kaynağı elde etmek isteyen feodal rakiplerden Harkonen ailesi tarafından Paul ve ailesine tuzak kurulur." +
                " Bu tuzağın sonucunda Paul'un ailesi darmadağın olarak firari hale gelir." +
                " Paul, ailesinin Arrakis kontrolünü yeniden kazanması için bir isyan başlatırken, tüm evrenin seyrini değiştirebilme ihtimalini yakalayacaktır.",
                Yonetmen = "Denis Villeneuve",
                Senarist = "Jon Spaihts, Denis Villeneuve",
                Oyuncular = "Timothée Chalamet,Rebecca Ferguson,Zendaya",
                FotoUrl = "dune.jpg",

            });
            string[] WhiplashTur = { "Dram", "Müzik" };
            string whiplashTurleri = string.Join(",", WhiplashTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Filmler",
                FılmAdı = "Whiplash",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "16 Ocak 2015",
                FılmTur = whiplashTurleri,
                KullanıcıPuanı = 8.5,
                Acıklama = "Whiplash, genç bir müzisyenin öykünü anlatıyor. Küçük yaşlardan itibaren bateri çalmaya başlayan Andrew, işinde tam anlamıyla bir usta olmak ister. " +
                "Üniversite tercihinde de ülkenin en iyi müzik okulu olarak gördüğü Shcarffer Konservatuarı'na girer. Henüz 19 yaşındadır ama dersler harici var gücüyle antrenman yapar. " +
                "Bir gün, okulun en sert hocalarından biri olan caz duayeni Terence Fletcher'ın dikkatini çeker. " +
                "Fletcher Andrew'ü okulun en parlak öğrencilerinin seçildiği ve sürekli yeni yarışmalara hazırlanan 'Studio Band'e seçer. " +
                "Başarısı kadar acımasızlığıyla da ün yapmış olan Fletcher, Andrew'un kapasitesinin sonuna kadar kullanmadan asla başarmış saymayacaktır. " +
                "Genç bateristin önünde sadece mesleki bir test değil, psikolojik bir sınav da vardır...",
                Yonetmen = "Damien Chazelle",
                Senarist = "Damien Chazelle",
                Oyuncular = "Miles Teller, J.K. Simmons, Paul Reiser",
                FotoUrl = "whiplash.jpg",

            });
            string[] DovusTur = { "Gerilim", "Aksiyon", "Dram" };
            string dovusTur = string.Join(",", DovusTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Filmler",
                FılmAdı = "Dövüş Kulübü",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "10 Aralık 1999",
                FılmTur = dovusTur,
                KullanıcıPuanı = 8.8,
                Acıklama = "Dövüş Kulübünün birinci kuralı: Asla Dövüş Kulübü hakkında konuşma... Dövüş Kulübünün ikinci kuralı: Asla ve asla dövüş kulübü hakkında konuşma..." +
                " Jack, hayatın sıradanlığına kapılmış bir sigorta memurudur. Uzun bir süredir 'insomnia' yani uykusuzluk hastalığından şikayetçidir. " +
                "Kendi psikolojik sıkıntılarından kurtulabilmek adına grup terapilerine katılmaktadır. Terapiler esnasında Marla adında bir kızla tanışır." +
                " Bir süre sonra da hayatını değiştirecek olan Tyler Durden ile... " +
                "Durden, Jack'in ulaşmak istediği tüm hedeflere ulaşmış olan bir adamdır ve Jack'i asla hakkında konuşulmaması gereken bir organizasyon olan 'Dövüş Kulübü' ile tanıştıracaktır.",
                Yonetmen = "David Fincher",
                Senarist = "Jim Uhls",
                Oyuncular = "Brad Pitt, Edward Norton, Helena Bonham Carter",
                FotoUrl = "fight_club_movie.jpg",

            });
            string[] PastTur = { "Tarih", "Aksiyon", "Dram" };
            string pastTur = string.Join(",", PastTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Filmler",
                FılmAdı = "1917",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "25 Aralık 2019 ",
                FılmTur = pastTur,
                KullanıcıPuanı = 8.2,
                Acıklama = "1917, I. Dünya Savaşı sırasında askerlerin hayatını etkileyecek önemde bir mesajı iletmekle görevlendirilen iki askerin hikayesini konu ediyor. konu ediyor. " +
                "I. Dünya Savaşı sırasında Britanya askeri olan Kıdemsiz Onbaşı Schofield ve Kıdemsiz Onbaşı Blake, gerçekleştirilmesi imkansız gibi görünen bir göreve atanır. " +
                "Görevleri, zamana karşı yarışırken düşman bölgesini geçerek yüzlerce askerin ölümünü engellemek üzere bir mesaj iletmektir." +
                " Blake'in kardeşi de kurtarılabilecek askerlerin arasındadır. Bu durumda Blake'i daha da fazla ciddiye alması gereken bir mücadele bekliyordur.",
                Yonetmen = "Sam Mendes",
                Senarist = "Sam Mendes, Krysty Wilson-Cairns",
                Oyuncular = "George MacKay, Dean-Charles Chapman, Mark Strong",
                FotoUrl = "dram.jpg",

            });
            string[] BatıTur = { "Dram", "Savaş", "Tarih " };
            string batıTur = string.Join(",", BatıTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Filmler",
                FılmAdı = "Batı Cephesinde Yeni Bir Şey Yok",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "28 Ekim 2022 ",
                FılmTur = batıTur,
                KullanıcıPuanı = 7.8,
                Acıklama = " Batı Cephesinde Yeni Bir Şey Yok, Birinci Dünya Savaşı sırasında Batı Cephesi'nde savaşan bir Alman askerinin hikayesini konu ediyor." +
                " Savaşın ilk günlerinde coşkuyla siperlerde yer alan Paul ve silah arkadaşları, savaş devam ettikçe kendilerini korku ve büyük bir çaresizliğin içinde bulur.",
                Yonetmen = "Edward Berger",
                Senarist = "Ian Stokell, Lesley Paterson",
                Oyuncular = "Felix Kammerer, Albrecht Schuch, Aaron Hilmer",
                FotoUrl = "bati_cephesi.jpg",

            });
            string[] KucukTur = { "Romantik", "Dram" };
            string kucukTur = string.Join(",", KucukTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Filmler",
                FılmAdı = "Küçük Kadınlar",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "15 Şubat 2020",
                KullanıcıPuanı = 7.8,
                FılmTur = kucukTur,
                Acıklama = "Küçük Kadınlar, İç Savaş sonrası Amerika'da yaşamlarını sürdürmeye çalışan dört kız kardeşin hikayesini anlatıyor." +
                " Meg, Jo, Beth ve Amy birbirinden tamamen farklı karaktere sahip dört kız kardeştir. " +
                "Çocukluk dönmelerini geride bırakıp kadınlığa geçiş süreçlerinde kardeşler türlü dertlerle boğuşur. " +
                "Babaları Amerikan İç Savaşı'na katılan dört genç kız, anneleri ile birlikte yaşam mücadelesi vermeye başlar. " +
                "Bu zorlu süreçte en büyük kazançları birbirlerinin yanında olmalarıdır. Her türlü zorluğu birlikte göğüsleyen kardeşler bu süreçte asıl mutluluğun sevgi olduğunu anlar.",
                Yonetmen = " Greta Gerwig",
                Senarist = "Greta Gerwig",
                Oyuncular = "Saoirse Ronan, Emma Watson, Florence Pugh",
                FotoUrl = "little_women.jpg",

            });
            string[] OpphenTur = { "Biyografik", "Tarih", "Gerilim" };
            string opphenTur = string.Join(",", OpphenTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Filmler",
                FılmAdı = "Oppenheimer",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "21 Temmuz 2023",
                FılmTur = opphenTur,
                KullanıcıPuanı = 8.8,
                Acıklama = "Oppenheimer, Amerikalı fizikçi Julius Robert Oppenheimer'ın hayatına odaklanıyor. Filmde Julius Robert Oppenheimer’ın, " +
                "İkinci Dünya Savaşı sırasında atım bombasının geliştirilme sürecindeki rolü gözler önüne seriliyor.",
                Yonetmen = "Christopher Nolan",
                Senarist = "Christopher Nolan",
                Oyuncular = " Cillian Murphy, Robert Downey Jr., Matt Damon",
                FotoUrl = "oppenheimer.jpg",

            });
            string[] SpiderTur = { "Aksiyon", "Macera", "Fantastik" };
            string spiderTur = string.Join(",", SpiderTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Filmler",
                FılmAdı = "Örümcek-Adam Eve Dönüş Yok",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "7 Aralık 2021",
                FılmTur = spiderTur,
                KullanıcıPuanı = 8.2,
                Acıklama = "Örümcek-Adam Eve Dönüş Yok, kimliği açığa Örümcek-Adam'ın, sırrını geri vermesi için Doktor Strange'den yardım istemesiyle birlikte yaşananları konu ediyor." +
                " Örümcek-Adam'ın kimliği ifşa edilerek onun ve sevdiklerinin hayatı, halkın gözü önüne serilir." +
                " Kendisini büyük bir kaosun ortasında bulan Peter, aynı zamanda suç ortakları olarak lanse edilen MJ ve Ned'in hayatının da olumsuz etkilenmesine şahit olur." +
                " Arkadaşların üniversiteye girme şanslarının yok olmasına seyirci kalmak istemeyen Peter, sırrını geri vermesi için Doktor Strange'den yardım ister." +
                " Peter'ın yakarışından etkilenip ona yardım etmeyi kabul eden Strange, Unutma Büyüsü'nü yapmaya başlar. " +
                "Ancak bu büyü, MJ, Ned, May ve Happy'nin de Örümcek-Adam'ın kim olduğunu unutmasına neden olacaktır. " +
                "Arkadaşlarının kim olduğunu hatırlamasını, diğer kişilerin unutmasını isteyen Peter, Strange büyüyü yaparken parametreleri değiştirir. " +
                "Ancak bu durum beklenmedik olaylara neden olur.",
                Yonetmen = "Jon Watts",
                Senarist = " Chris McKenna, Erik Sommers",
                Oyuncular = "Tom Holland, Zendaya, Benedict Cumberbatch",
                FotoUrl = "spiderman_no_way.jpg",

            });
            string[] AcrossTur = { "Animasyon", "Aksiyon", "Fantastik" };
            string acrossTur = string.Join(",", AcrossTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Filmler",
                FılmAdı = "Spider-Man: Across The Spider-Verse",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "2 Haziran 2023",
                FılmTur = acrossTur,
                KullanıcıPuanı = 8.5,
                Acıklama = "Spider-Man: Into the Spider-Verse, radyoaktif bir örümcek tarafından ısırılmasıyla bambaşka bir dünyaya adım atıp," +
                " özel yeteneklerle donanan Miles Morales'in maceralarını konu ediyor. Gwen Stacy ile yeniden bir araya gelen Miles, Çoklu Evrenleri geçer." +
                " Miles bu sırada ne olursa olsun orayı korumakla yükümlü olan Örümcek - İnsanlarla karşılaşır. Büyük bir tehdit ile karşı karşıya olan kahramanlar," +
                " ne yapacaklarını bilemeyince Miles, kendisini diğer Örümcekler’in karşısında bulur. Miles, en sevdiği insanları büyük bir tehdite karşı koruyabilmek için yeteneklerini kullanmak zorundadır.",
                Yonetmen = " Joaquim Dos Santos, Kemp Powers, Justin Thompson",
                Senarist = "Phil Lord, Christopher Miller",
                Oyuncular = "Shameik Moore, Hailee Steinfeld, Issa Rae",
                FotoUrl = "spiderman_acros.jpg",
            });

            context.SaveChanges();
        }
    }
}
