using OdevApp1.Models;
using OdevApp1.Services;

namespace OdevApp1.Page;

public partial class Kayıt : ContentPage
{
	private readonly IFılmService _service;
    private bool selectedGender;

    public Kayıt()
	{
		InitializeComponent();
		_service=new FılmService();


}

    private async void GirisYap(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OdevApp1.Giris());
    }

    

    private async void Kayit(object sender, EventArgs e)
    {
        string kullaniciAdi = KullaniciAdiEntry.Text;
        string sifre = SifreEntry.Text;
        bool cinsiyet = selectedGender;
      
        List<KullanıcılarM> kullanıcılar = await _service.GetKullanıcılarMs();

        // Doğru kullanıcıyı bul
        KullanıcılarM kullanici = kullanıcılar.FirstOrDefault(k => k.Name == kullaniciAdi);

        if (kullanici != null)
        {
            await DisplayAlert("Hata", "Kullanıcı adı zaten mevcut.", "Tamam");
            return;
        }
        DateTime selectedDate = datePicker.Date;
       
        if (kullaniciAdi.Length < 4)
        {
            await DisplayAlert("Hata", "Kullanıcı adı en az 4 karakter olmalıdır.", "Tamam");
            return;
        }

        if (sifre.Length < 4)
        {
            await DisplayAlert("Hata", "Şifre en az 4 karakter olmalıdır.", "Tamam");
            return;
        }

        KullanıcılarM yeniKullanici = new KullanıcılarM()
        {
            Id = Guid.NewGuid(),
            Name = kullaniciAdi,
            Parola = sifre,
            Cinsiyet = cinsiyet,
            DoğumTarihi = selectedDate,
        };

        await _service.Ekle(yeniKullanici);

        await Navigation.PushAsync(new Giris());
    }


    private void genderPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex == 1) // Erkek seçildiyse
        {
            selectedGender = true;
        }
        else if (selectedIndex == 0) // Kadın seçildiyse
        {
            selectedGender = false;
        }
    }
  

}