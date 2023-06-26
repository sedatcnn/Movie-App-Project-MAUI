using OdevApp1.Models;
using OdevApp1.Services;

namespace OdevApp1.Page;

public partial class Profil : ContentPage
{
    private readonly IF�lmService f�lmService;
    public Profil()
	{
        InitializeComponent();
        f�lmService = new F�lmService();
        string ad = Giris.ad;
        string sifre = Giris.parola;
        kullan�c�Adi.Text = ad;
        Sifre.Text = sifre;
        LoadBilgi();



    }
    private async void LoadBilgi()
    {


        List<Kullan�c�larM> kullan�c�lar = await f�lmService.GetKullan�c�larMs();

        // Do�ru kullan�c�y� bul
        Kullan�c�larM kullanici = kullan�c�lar.FirstOrDefault(k => k.Name == kullan�c�Adi.Text && k.Parola == Sifre.Text);

        if (kullanici != null)
        {
            // Kullan�c�n�n do�um tarihi ve cinsiyet bilgilerini al
            string dogum = kullanici.Do�umTarihi.ToString("dd/MM/yyyy");
            string cins = kullanici.Cinsiyet ? "Erkek" : "Kad�n";


            // Do�um tarihi ve cinsiyet bilgilerini ilgili Label kontrollerine yerle�tir
            dogumTarihi.Text = dogum;
            cinsiyet.Text = cins;

            // Kullan�c�n�n cinsiyet bilgisini veritaban�ndan getir ve kullan

        }

    }
    private async void ParolaDegistir(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OdevApp1.Page.ParolaDegistir());

    }
    private async void HesapSil(object sender, EventArgs e)
    {
        List<Kullan�c�larM> kullan�c�lar = await f�lmService.GetKullan�c�larMs();

        Kullan�c�larM kullanici = kullan�c�lar.FirstOrDefault(k => k.Name == kullan�c�Adi.Text && k.Parola == Sifre.Text);

        if (kullanici != null)
        {
            bool confirmed = await DisplayAlert("Onay", "Hesab�n�z� silmek istedi�inize emin misiniz?", "Evet", "Hay�r");

            if (confirmed)
            {
                await f�lmService.Sil(kullanici.Id);
                Giris girisPage = new Giris();
                await Navigation.PushModalAsync(new NavigationPage(girisPage) { BarBackgroundColor = Colors.Transparent, BarTextColor = Colors.White });
            }
        }
        else
        {
            // Kullan�c� bulunamad�ysa hata mesaj� g�sterme veya i�lem yapma
        }
    }

    private async void geriButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}