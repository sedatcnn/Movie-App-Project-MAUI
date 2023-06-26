using OdevApp1.Models;
using OdevApp1.Page;
using OdevApp1.Services;
using System.Reflection.Metadata;

namespace OdevApp1;

public partial class Giris : ContentPage
{
    private readonly IFılmService fılmService;
    public static string ad { get; set; }
    public static string parola { get; set; }


    public Giris()
    {
        InitializeComponent();
        fılmService = new FılmService();

    }

    private async void GirisYapButton_Clicked(object sender, EventArgs e)
    {
        ad = KullaniciAdiEntry.Text;
        parola = SifreEntry.Text;


        List<KullanıcılarM> kullanıcılar = await fılmService.GetKullanıcılarMs();

        KullanıcılarM kullanici = kullanıcılar.FirstOrDefault(k => k.Name == ad && k.Parola == parola);

        if (kullanici != null)
        {
          
            await Navigation.PushAsync(new OdevApp1.Page.Anasayfa());

        }
        else
        {
            await DisplayAlert("Hata", "Geçersiz kullanıcı adı veya şifre", "Tamam");
        }


    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OdevApp1.Page.Kayıt());
    }


}
