using WebApplication1.EF;

namespace WebApplication1.Models
{
    public class YerliFılmler
    {
        public void Turk()
        {
            FılmContext context = new FılmContext();
            string[] secilenFilmTurleri = { "Romantik", "Dram" };
            string filmTurleri = string.Join(",", secilenFilmTurleri);

            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Türk Filmleri",
                FılmAdı = "Fakat Müzeyyen Bu Derin Bir Tutku",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "12 Aralık 2014",
                FılmTur = filmTurleri,
                KullanıcıPuanı = 6.6,
                Acıklama = "İlk kitabını yazmaya çalışan 'yazar' Arif, zamanının önemli bir kısmını kitabı üzerine kafa yorarak geçirir." +
                " Ona göre hayat başta kadınlar ve ilişkiler olmak üzere pek çok çözümsüz soruyu içermektedir." +
                " İlişkiler konusunda bir türlü dikişi tutturamayan Arif her daim kafasını kurcalayan bu soruların peşindedir." +
                " Fakat beklemediği bir anda Müzeyyen'in ortaya çıkmasıyla, o güne dek bildiği ya da öğrenmeye çalıştığı her şey bir anda tersyüz olur." +
                " Zira Müzeyyen'in cazibesine kapılmamak elinde değildir ve kendini bu ilişkinin akışına bırakır.",
                Yonetmen = "Çiğdem Vitrinel",
                Senarist = "Çiğdem Vitrinel, Ceyda Aşar",
                Oyuncular = "Erdal Beşikçioğlu, Sezin Akbaşoğulları, Erdinç Gülener",
                FotoUrl = "fakat_muzeyyen_bu_derin_bir_tutku.png",

            });
            string[] KaderTur = { "Dram" };
            string kaderTur = string.Join(",", KaderTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Türk Filmleri",
                FılmAdı = "Kader",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "17 Kasım 2006",
                FılmTur = kaderTur,
                KullanıcıPuanı = 7.8,
                Acıklama = "Bekir Uğur’a, Uğur Zagor’a, Zagor’da serseriliğe aşıktır. Karşılığını bulamayan kalplere tutkun bu üç insanın yolu, " +
                "tutkunun beslediği bir kaderle birbirine bağlanır. Uğur, Zagor’un hapisten çıktığı gece, mahallede işlenen bir cinayetin ardından ortadan kaybolur. " +
                "Bu kayboluş, ilk başta Bekir’in umutsuz aşkından kurtulması için bir umut olsa da," +
                " aylar sonra Zagor’un İzmir’de işlediği bir cinayet sonrası hapse girmesinin ardından Uğur’un mahalleye dönmesi ile Bekir için yıllar sürecek amansız bir kovalamaca başlayacaktır." +
                " Aşkının peşinde, kendini hiçe sayarak sürecek bu kovalamaca ile gururunu, benliğini, bütün kişiliğini yitirse de, bir tek şeyi, aşkın masumiyetini yitirmez.",
                Yonetmen = "Zeki Demirkubuz",
                Senarist = "Zeki Demirkubuz",
                Oyuncular = "Vildan Atasever, Ufuk Bayraktar, Ozan Bilen",
                FotoUrl = "kader.jpg",

            });
            string[] SarmasıkTur = { "Dram", "Gerilim" };
            string sarmasıkTur = string.Join(",", SarmasıkTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Türk Filmleri",
                FılmAdı = "Sarmaşık",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "14 Aralık 2015",
                FılmTur = sarmasıkTur,
                KullanıcıPuanı = 7.9,
                Acıklama = "Bir armatör iflas eder ve o sırada seferde olan gemisindek mürettebat gemide mahsur kalır." +
                " Zira deniz hukuku gereği gemide kalmak zorundadırlar ve hiçbir yere kıpırdayamazlar. " +
                "5 gemici ve bir de kaptandan oluşan mürettebat bu huzursuz bekleyişte hiyerarşik güç mücadelesine girecektir. ",
                Yonetmen = "Tolga Karaçelik",
                Senarist = "Tolga Karaçelik",
                Oyuncular = "Nadir Sarıbacak, Özgür Emre Yıldırım, Hakan Karsak",
                FotoUrl = "sarmasik.jpg",

            });
            string[] KısTur = { "Dram" };
            string kısTur = string.Join(",", KısTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Türk Filmleri",
                FılmAdı = "Kış Uykusu",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "13 Haziran 2014",
                FılmTur = kısTur,
                KullanıcıPuanı = 8.1,
                Acıklama = "Aydın emekli bir tiyatrocudur; oyunculuğu bıraktıktan sonra Kapadokya'ya babasından yadigar kalan butik oteli işletmek için geri döner." +
                " Aydın o günden sonra başlayan kış uykusu bu gözlerden ırak otelin içerisindeki gündelikleriyle," +
                " kah yerel bir gazeteye köşe yazıları yazarak kah her zaman niyetlendiği ancak bir türlü başlayamadığı tiyatro tarihi kitabını yazmayı düşünerek geçer. " +
                "Tüm bu süreçte hayatında iki kadın vardır: Kendisine her anlamda uzak ve soğuk davranan genç karısı Nihal ve boşandıktan sonra yanlarına taşınan kız kardeşi Necla... " +
                "Kışın bastırması ve artan kar yağışı bu küçük taşrada en çok Aydın'ın sinirlerine dokunur ve onu uzaklara gitmeye teşvik eder...",
                Yonetmen = "Nuri Bilge Ceylan",
                Senarist = "Nuri Bilge Ceylan, Ebru Ceylan",
                Oyuncular = "Haluk Bilginer, Melisa Sözen, Demet Akbağ",
                FotoUrl = "kis_uykusu.jpg",

            });
            string[] OkulTur = { "Dram" };
            string okulTur = string.Join(",", OkulTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Türk Filmleri",
                FılmAdı = "Okul Tıraşı",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "17 Haziran 2022 ",
                FılmTur = okulTur,
                KullanıcıPuanı = 7.4,
                Acıklama = "Okul Tıraşı, okulda hastalanan arkadaşını doktora götürmeye çalışan bir gencin hikayesini konu ediyor. " +
                "Bir yatılı okulda okuyan öğrenciler, okulda uygulanan baskı ve disiplinin altında ezilecek duruma gelmişlerdir." +
                " Bir gün öğrencilerden birinin rahatsızlanmasına kayıtsız kalamayan arkadaşı Yusuf, onu doktora götürmeye karar verir. " +
                "Ancak önünde bir dizi engelle karşılaşır. Yusuf, arkadaşını doktora götürmek için, okul bürokrasisini, idarenin takındığı vurdumduymaz tavrı," +
                " yaşadıkları yerin zor coğrafi koşulları ve daha birçok sorunla mücadele etmek zorunda kalır.",
                Yonetmen = "Ferit Karahan",
                Senarist = "Ferit Karahan, Gülistan Acet",
                Oyuncular = "Samet Yıldız, Ekin Koç, Mahir İpek",
                FotoUrl = "okul_tirası.jpg",

            });
            string[] KurakTur = { "Dram", "Gerilim" };
            string kurakTur = string.Join(",", KurakTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Türk Filmleri",
                FılmAdı = "Kurak Günler",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "9 Aralık 2022",
                FılmTur = kurakTur,
                KullanıcıPuanı = 7.8,
                Acıklama = "Çiçeği burnunda bir savcı olan Emre'nin tayini Yanıklar kasabasına çıkar." +
                " İşini büyük bir ciddiyetle yapmaya çalışan Emre, Belediye Başkanı Selim Bey ve kasaba halkı tarafından saygıyla karşılanır." +
                " Yer altı suyunun kullanılması çevre kurulları ve mahkemelerce yasaklanması kasabada ciddi bir sorun yaratır." +
                " Selim Bey de büyük borularla yer altı sularını kasabaya bağlayacak olan büyük projesini hayata geçirmeye çalışır." +
                " Ancak Selim, yerel bir gazete sahibi olan Murat başta olmak üzere ciddi bir muhalefetle karşı karşıya kalır." +
                " Murat, Emre'yi belediye başkanına karşı kışkırtmaya çalışsa da Emre olaylara temkinli yaklaşır." +
                " Kısa bir süre sonra yapılacak olan yerel seçimlerde taraf olmaktan kaçınmaya çalışan Emre, ona karşı yükselen sesler sonucu kendisini zor bir durumun içinde bulur. " +
                "Çok geçmeden Emre, bir kısır döngü içine hapsolur.",
                Yonetmen = "Emin Alper",
                Senarist = "Emin Alper",
                Oyuncular = "Selahattin Paşalı, Ekin Koç, Erol Babaoğlu",
                FotoUrl = "kis_uykusu.jpg",

            });
            string[] GemideTur = { "Dram" };
            string gemideTur = string.Join(",", GemideTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Türk Filmleri",
                FılmAdı = "Gemide",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "4 Aralık 1998",
                FılmTur = gemideTur,
                KullanıcıPuanı = 7.9,
                Acıklama = " Laleli'de parasını çaldıran boksörün gemi kaptanına durumu anlatması ile parayı istemeye giden kaptanın başından geçenlerin konu edildiği filmde," +
                " olaylar iyice karmaşık bir hal alır ve bir kız ile kafası betona çarpılarak öldürülmüş bir adam kalır ellerinde. " +
                "Gemiden gitmesi gereken kızın boksör tarafından saklanması ile daha da karışan olaylar sonucu kafası dumanlı olan esrarkeş kaptan ayılmaya başladıkça her şeyi yavaş yavaş hatırlamaya başlar.",
                Yonetmen = " Serdar Akar",
                Senarist = "Serdar Akar, Önder Çakar",
                Oyuncular = "Erkan Can, Ella Manea, Haldun Boysan",
                FotoUrl = "gemide.jpg",

            });
            string[] AhlatTur = { "Dram" };
            string ahlatTur = string.Join(",", AhlatTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Türk Filmleri",
                FılmAdı = "Ahlat Ağacı",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "1 Haziran 2018",
                FılmTur = ahlatTur,
                KullanıcıPuanı = 8.0,
                Acıklama = "Sinan oldum olası edebiyatla ilgili bir genç adamdır ve yazar olmak istemektedir." +
                " Anadolu'da doğduğu köye dönen genç adam kitabını bastıracak parayı bulmak için tüm enerjisini harcamaya başlar ancak babasının geçmişten kalan borçları başına dert olacaktır...",
                Yonetmen = "Nuri Bilge Ceylan",
                Senarist = "Ebru Ceylan, Nuri Bilge Ceylan",
                Oyuncular = "Doğu Demirkol, Murat Cemcir, Bennu Yıldırımlar",
                FotoUrl = "ahlat_agacı.jpg",

            });
            string[] OlumluTur = { "Komedi", "Aksion" };
            string olumluTur = string.Join(",", OlumluTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Türk Filmleri",
                FılmAdı = "Ölümlü Dünya",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "26 Ocak 2018",
                FılmTur = olumluTur,
                KullanıcıPuanı = 7.6,
                Acıklama = "Nesillerdir Haydarpaşa Garı’nda Anadolu Tat Lokantası’nı işleten Mermer Ailesi, 8 kişiden oluşan geniş bir ailedir." +
                " Kendi halinde, sade bir yaşamları olan bu insanlar dışarıdan oldukça sıradan bir hayat yaşamaktadır. Oysa gerçek hiç de öyle değildir. " +
                "Mermer ailesi nesilden nesile kiralık katildir ve dünya çapında etkin olan dev bir organizasyon için çalışmaktadır. " +
                "Ancak organizasyonun kimi kurallarının ihmal edilmesiyle birlikte işler karışır ve ailenin kimliği açığa çıkar. " +
                "Artık aile pılını pırtını toplayıp yola koyulmalı ve peşlerindeki dev örgütü atlatabilmelidir...",
                Yonetmen = "Ali Atay",
                Senarist = "Ali Atay, Aziz Kedi",
                Oyuncular = "Ahmet Mümtaz Taylan, Alper Kul, Sarp Apak,Feyyaz Yiğit",
                FotoUrl = "olumlu_dunya.jpg",

            });
            string[] KelebeklerTur = { "Dram", "Komedi" };
            string kelebekTur = string.Join(",", KelebeklerTur);
            context.Fılmlers.Add(new Models.Fılmler
            {
                Id = Guid.NewGuid(),
                Baslik = "Türk Filmleri",
                FılmAdı = "Kelebekler",
                EklenmeTarihi = DateTime.Now,
                YayınTarihi = "30 Mart 2018",
                FılmTur = kelebekTur,
                KullanıcıPuanı = 7.3,
                Acıklama = "Üç kardeşin yolları yıllar önce ayrılmıştır. Aradan geçen 30 yılın ardından babaları çocuklarını bir araya getirmek ister ve onları Hasanlar Köyü’ndeki evlerine geri çağırır." +
                " Kardeşlerden en büyüğü Cemal, onları alır ve nedenini bilmedikleri bir yolculuğa çıkar." +
                " Üç kardeş köye gittiklerinde ise babalarının öldüğünü öğrenirler. Babaları, köyün acayipliklerinden biri olan kelebeklerin gelişinde gömülmeyi vasiyet etmiştir." +
                " Birbirlerini çok az tanıyan kardeşler köyde kaldıkları süre boyunca yaşadıkları olaylarla kendilerini, birbirlerini ve babalarının kim olduğunu anlamaya çalışır.",
                Yonetmen = " Tolga Karaçelik",
                Senarist = "Tolga Karaçelik",
                Oyuncular = "Bartu Küçükçağlayan, Tuğçe Altuğ, Tolga Tekin",
                FotoUrl = "kelebekler.jpg",
            });


            context.SaveChanges();


        }
    }
}
