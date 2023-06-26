using OdevApp1.Models;
using OdevApp1.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OdevApp1.Page;

public partial class Dram : ContentPage
{
    private readonly IFýlmService _fýlmService;
    public ObservableCollection<FýlmlerM> Filmler { get; set; }

    public Dram()
	{
		InitializeComponent();
        _fýlmService = new FýlmService();
        LoadFilmler();
    }
    private async void LoadFilmler()
    {
        var filmler = await _fýlmService.GetFýlmlerM();
        Filmler = new ObservableCollection<FýlmlerM>(filmler.Where(film => film.FýlmTur.Contains("Dram")).Take(16));
        collectionViewFilmler.ItemsSource = Filmler;

    }

    private async void AramaButton(object sender, EventArgs e)
    {
        string searchText = searchEntry.Text;
        var results = await _fýlmService.SearchFýlmler(searchText);
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
            var results = await _fýlmService.SearchFýlmler(searchText);
            resultsListView.ItemsSource = results;
        }
    }

    private async void AnasayfaButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OdevApp1.Page.Anasayfa());
    }

    private async void YerliFýlmButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OdevApp1.Page.YerliFýlmler());
    }
    private async void profilButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page.Profil());
    }

    private async void cýkýsButton(object sender, EventArgs e)
    {
        Giris girisPage = new Giris();
        await Navigation.PushModalAsync(new NavigationPage(girisPage) { BarBackgroundColor = Colors.Transparent, BarTextColor = Colors.White });
    }
    private async void VeriTýkla(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (FýlmlerM)buton.BindingContext;
        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "Dune: Çöl Gezegeni", typeof(Page.FýlmDetay.DuneSayfa) },
            { "1917", typeof(Page.FýlmDetay._1917) },
            { "Fakat Müzeyyen Bu Derin Bir Tutku", typeof(Page.FýlmDetay.MuzeyyenSayfa) },
            { "Ahlat Aðacý", typeof(Page.FýlmDetay.Ahlat) },
            { "Kader", typeof(Page.FýlmDetay.KaderSayfa) },
            { "Kýþ Uykusu", typeof(Page.FýlmDetay.KýsSayfa) },
            { "Whiplash", typeof(Page.FýlmDetay.WhiplashSayfa) },
            { "Kelebekler", typeof(Page.FýlmDetay.KelebeklerSayfa) },
            { "Okul Týraþý", typeof(Page.FýlmDetay.OkulSayfa) },
            { "Küçük Kadýnlar", typeof(Page.FýlmDetay.LitlleSayfa) },
            { "Batý Cephesinde Yeni Bir Þey Yok", typeof(Page.FýlmDetay.BatýSayfa) },
            { "Gemide", typeof(Page.FýlmDetay.GemideSayfa) },
            { "Kurak Günler", typeof(Page.FýlmDetay.KurakSayfa) },
            { "Sarmaþýk", typeof(Page.FýlmDetay.SarmasýkSayfa) },
            { "Dövüþ Kulübü", typeof(Page.FýlmDetay.DovusSayfa) },
            { "Louis Wain'in Renkli Dünyasý", typeof(Page.FýlmDetay.LouiseSayfa) }
        };

        if (filmPages.ContainsKey(film.FýlmAdý))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.FýlmAdý]));
        }

    }
}