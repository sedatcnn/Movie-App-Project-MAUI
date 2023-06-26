using OdevApp1.Models;
using OdevApp1.Services;

namespace OdevApp1.Page;

public partial class Profil : ContentPage
{
    private readonly IFýlmService fýlmService;
    public Profil()
	{
        InitializeComponent();
        fýlmService = new FýlmService();
        string ad = Giris.ad;
        string sifre = Giris.parola;
        kullanýcýAdi.Text = ad;
        Sifre.Text = sifre;
        LoadBilgi();



    }
    private async void LoadBilgi()
    {


        List<KullanýcýlarM> kullanýcýlar = await fýlmService.GetKullanýcýlarMs();

        // Doðru kullanýcýyý bul
        KullanýcýlarM kullanici = kullanýcýlar.FirstOrDefault(k => k.Name == kullanýcýAdi.Text && k.Parola == Sifre.Text);

        if (kullanici != null)
        {
            // Kullanýcýnýn doðum tarihi ve cinsiyet bilgilerini al
            string dogum = kullanici.DoðumTarihi.ToString("dd/MM/yyyy");
            string cins = kullanici.Cinsiyet ? "Erkek" : "Kadýn";


            // Doðum tarihi ve cinsiyet bilgilerini ilgili Label kontrollerine yerleþtir
            dogumTarihi.Text = dogum;
            cinsiyet.Text = cins;

            // Kullanýcýnýn cinsiyet bilgisini veritabanýndan getir ve kullan

        }

    }
    private async void ParolaDegistir(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OdevApp1.Page.ParolaDegistir());

    }
    private async void HesapSil(object sender, EventArgs e)
    {
        List<KullanýcýlarM> kullanýcýlar = await fýlmService.GetKullanýcýlarMs();

        KullanýcýlarM kullanici = kullanýcýlar.FirstOrDefault(k => k.Name == kullanýcýAdi.Text && k.Parola == Sifre.Text);

        if (kullanici != null)
        {
            bool confirmed = await DisplayAlert("Onay", "Hesabýnýzý silmek istediðinize emin misiniz?", "Evet", "Hayýr");

            if (confirmed)
            {
                await fýlmService.Sil(kullanici.Id);
                Giris girisPage = new Giris();
                await Navigation.PushModalAsync(new NavigationPage(girisPage) { BarBackgroundColor = Colors.Transparent, BarTextColor = Colors.White });
            }
        }
        else
        {
            // Kullanýcý bulunamadýysa hata mesajý gösterme veya iþlem yapma
        }
    }

    private async void geriButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}