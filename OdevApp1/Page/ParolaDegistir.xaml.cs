using OdevApp1.Models;
using OdevApp1.Services;

namespace OdevApp1.Page;

public partial class ParolaDegistir : ContentPage
{
    private readonly IFılmService fılmService;

    public ParolaDegistir()
	{
        InitializeComponent();
        
        fılmService=new FılmService();
	}
    
    private async void Degistir(object sender, EventArgs e)
    {
        string ad = Giris.ad;
        string eskisifre = Giris.parola;
        string sifre = SifreEntry.Text;

        if (eskisifre == sifre)
        {
            await DisplayAlert("Hata", "Girmiş Olduğunuz Şifre Eski Şifrenizle Aynı Olamaz.", "Tamam");
            return;
        }
        if (sifre.Length < 4)
        {
            await DisplayAlert("Hata", "Şifre en az 4 karakter olmalıdır.", "Tamam");
            return;
        }
        List<KullanıcılarM> kullanıcılar = await fılmService.GetKullanıcılarMs();
        KullanıcılarM kullanici = kullanıcılar.FirstOrDefault(k => k.Parola == eskisifre && k.Name == ad);

        if (kullanici != null)
        {
            kullanici.Parola = sifre; // Yeni şifreyi güncelle

            await fılmService.Guncelle(kullanici);
            await DisplayAlert("Başarılı", "Şifre değiştirme işlemi başarıyla tamamlandı.", "Tamam");
            Giris girisPage = new Giris();
            await Navigation.PushModalAsync(new NavigationPage(girisPage) { BarBackgroundColor = Colors.Transparent, BarTextColor = Colors.White });
        }

    }

    private async void geriButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}