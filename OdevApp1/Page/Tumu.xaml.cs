using OdevApp1.Models;
using OdevApp1.Services;
using System.Collections.ObjectModel;

namespace OdevApp1.Page;

public partial class Tumu : ContentPage
{
    private readonly IFılmService _fılmService;
    public ObservableCollection<FılmlerM> Filmler { get; set; }

    public Tumu()
	{
		InitializeComponent();
        _fılmService = new FılmService();
        LoadFilmler();
    }
    private async void LoadFilmler()
    {
        var filmler = await _fılmService.GetFılmlerM();
        Filmler = new ObservableCollection<FılmlerM>(filmler.Take(20));
        collectionViewFilmler.ItemsSource = Filmler;

    }

    private async void AramaButton(object sender, EventArgs e)
    {
        string searchText = searchEntry.Text;
        var results = await _fılmService.SearchFılmler(searchText);
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
            var results = await _fılmService.SearchFılmler(searchText);
            resultsListView.ItemsSource = results;
        }
    }

    private async void AnasayfaButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OdevApp1.Page.Anasayfa());
    }

    private async void YerliFılmButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OdevApp1.Page.YerliFılmler());
    }
    private async void profilButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page.Profil());
    }

    private async void cıkısButton(object sender, EventArgs e)
    {
        Giris girisPage = new Giris();
        await Navigation.PushModalAsync(new NavigationPage(girisPage) { BarBackgroundColor = Colors.Transparent, BarTextColor = Colors.White });
    }
    private async void VeriTıkla(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (FılmlerM)buton.BindingContext;

        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "Örümcek-Adam Eve Dönüş Yok", typeof(Page.FılmDetay.SpidermanSayfa) },
            { "Oppenheimer", typeof(Page.FılmDetay.OppenheimerSayfa) },
            { "Dune: Çöl Gezegeni", typeof(Page.FılmDetay.DuneSayfa) },
            { "1917", typeof(Page.FılmDetay._1917) },
            { "Fakat Müzeyyen Bu Derin Bir Tutku", typeof(Page.FılmDetay.MuzeyyenSayfa) },
            { "Ahlat Ağacı", typeof(Page.FılmDetay.Ahlat) },
            { "Spider-Man: Across The Spider-Verse", typeof(Page.FılmDetay.AccrosSayfa) },
            { "Kader", typeof(Page.FılmDetay.KaderSayfa) },
            { "Kış Uykusu", typeof(Page.FılmDetay.KısSayfa) },
            { "Whiplash", typeof(Page.FılmDetay.WhiplashSayfa) },
            { "Ölümlü Dünya", typeof(Page.FılmDetay.OlumluSayfa) },
            { "Kelebekler", typeof(Page.FılmDetay.KelebeklerSayfa) },
            { "Okul Tıraşı", typeof(Page.FılmDetay.OkulSayfa) },
            { "Küçük Kadınlar", typeof(Page.FılmDetay.LitlleSayfa) },
            { "Batı Cephesinde Yeni Bir Şey Yok", typeof(Page.FılmDetay.BatıSayfa) },
            { "Gemide", typeof(Page.FılmDetay.GemideSayfa) },
            { "Kurak Günler", typeof(Page.FılmDetay.KurakSayfa) },
            { "Sarmaşık", typeof(Page.FılmDetay.SarmasıkSayfa) },
            { "Dövüş Kulübü", typeof(Page.FılmDetay.DovusSayfa) },
            { "Louis Wain'in Renkli Dünyası", typeof(Page.FılmDetay.LouiseSayfa) }
        };

        if (filmPages.ContainsKey(film.FılmAdı))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.FılmAdı]));
        }
    }
}