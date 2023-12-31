using OdevApp1.Models;
using OdevApp1.Services;

namespace OdevApp1.Page;

public partial class Profil : ContentPage
{
    private readonly IFılmService fılmService;
    public Profil()
	{
        InitializeComponent();
        fılmService = new FılmService();
        string ad = Giris.ad;
        string sifre = Giris.parola;
        kullanıcıAdi.Text = ad;
        Sifre.Text = sifre;
        LoadBilgi();



    }
    private async void LoadBilgi()
    {


        List<KullanıcılarM> kullanıcılar = await fılmService.GetKullanıcılarMs();

        // Doğru kullanıcıyı bul
        KullanıcılarM kullanici = kullanıcılar.FirstOrDefault(k => k.Name == kullanıcıAdi.Text && k.Parola == Sifre.Text);

        if (kullanici != null)
        {
            // Kullanıcının doğum tarihi ve cinsiyet bilgilerini al
            string dogum = kullanici.DoğumTarihi.ToString("dd/MM/yyyy");
            string cins = kullanici.Cinsiyet ? "Erkek" : "Kadın";


            // Doğum tarihi ve cinsiyet bilgilerini ilgili Label kontrollerine yerleştir
            dogumTarihi.Text = dogum;
            cinsiyet.Text = cins;

            // Kullanıcının cinsiyet bilgisini veritabanından getir ve kullan

        }

    }
    private async void ParolaDegistir(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OdevApp1.Page.ParolaDegistir());

    }
    private async void HesapSil(object sender, EventArgs e)
    {
        List<KullanıcılarM> kullanıcılar = await fılmService.GetKullanıcılarMs();

        KullanıcılarM kullanici = kullanıcılar.FirstOrDefault(k => k.Name == kullanıcıAdi.Text && k.Parola == Sifre.Text);

        if (kullanici != null)
        {
            bool confirmed = await DisplayAlert("Onay", "Hesabınızı silmek istediğinize emin misiniz?", "Evet", "Hayır");

            if (confirmed)
            {
                await fılmService.Sil(kullanici.Id);
                Giris girisPage = new Giris();
                await Navigation.PushModalAsync(new NavigationPage(girisPage) { BarBackgroundColor = Colors.Transparent, BarTextColor = Colors.White });
            }
        }
        else
        {
            // Kullanıcı bulunamadıysa hata mesajı gösterme veya işlem yapma
        }
    }

    private async void geriButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}