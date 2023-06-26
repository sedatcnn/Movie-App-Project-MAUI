using OdevApp1.Models;
using OdevApp1.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OdevApp1.Page;

public partial class Dram : ContentPage
{
    private readonly IF�lmService _f�lmService;
    public ObservableCollection<F�lmlerM> Filmler { get; set; }

    public Dram()
	{
		InitializeComponent();
        _f�lmService = new F�lmService();
        LoadFilmler();
    }
    private async void LoadFilmler()
    {
        var filmler = await _f�lmService.GetF�lmlerM();
        Filmler = new ObservableCollection<F�lmlerM>(filmler.Where(film => film.F�lmTur.Contains("Dram")).Take(16));
        collectionViewFilmler.ItemsSource = Filmler;

    }

    private async void AramaButton(object sender, EventArgs e)
    {
        string searchText = searchEntry.Text;
        var results = await _f�lmService.SearchF�lmler(searchText);
        resultsListView.ItemsSource = results;


    }

    private async void searchEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue;

        if (string.IsNullOrEmpty(searchText))
        {
            resultsListView.ItemsSource = null;
        }
        else
        {
            var results = await _f�lmService.SearchF�lmler(searchText);
            resultsListView.ItemsSource = results;
        }
    }

    private async void AnasayfaButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OdevApp1.Page.Anasayfa());
    }

    private async void YerliF�lmButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OdevApp1.Page.YerliF�lmler());
    }
    private async void profilButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page.Profil());
    }

    private async void c�k�sButton(object sender, EventArgs e)
    {
        Giris girisPage = new Giris();
        await Navigation.PushModalAsync(new NavigationPage(girisPage) { BarBackgroundColor = Colors.Transparent, BarTextColor = Colors.White });
    }
    private async void VeriT�kla(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (F�lmlerM)buton.BindingContext;
        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "Dune: ��l Gezegeni", typeof(Page.F�lmDetay.DuneSayfa) },
            { "1917", typeof(Page.F�lmDetay._1917) },
            { "Fakat M�zeyyen Bu Derin Bir Tutku", typeof(Page.F�lmDetay.MuzeyyenSayfa) },
            { "Ahlat A�ac�", typeof(Page.F�lmDetay.Ahlat) },
            { "Kader", typeof(Page.F�lmDetay.KaderSayfa) },
            { "K�� Uykusu", typeof(Page.F�lmDetay.K�sSayfa) },
            { "Whiplash", typeof(Page.F�lmDetay.WhiplashSayfa) },
            { "Kelebekler", typeof(Page.F�lmDetay.KelebeklerSayfa) },
            { "Okul T�ra��", typeof(Page.F�lmDetay.OkulSayfa) },
            { "K���k Kad�nlar", typeof(Page.F�lmDetay.LitlleSayfa) },
            { "Bat� Cephesinde Yeni Bir �ey Yok", typeof(Page.F�lmDetay.Bat�Sayfa) },
            { "Gemide", typeof(Page.F�lmDetay.GemideSayfa) },
            { "Kurak G�nler", typeof(Page.F�lmDetay.KurakSayfa) },
            { "Sarma��k", typeof(Page.F�lmDetay.Sarmas�kSayfa) },
            { "D�v�� Kul�b�", typeof(Page.F�lmDetay.DovusSayfa) },
            { "Louis Wain'in Renkli D�nyas�", typeof(Page.F�lmDetay.LouiseSayfa) }
        };

        if (filmPages.ContainsKey(film.F�lmAd�))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.F�lmAd�]));
        }

    }
}