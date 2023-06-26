using OdevApp1.Models;
using OdevApp1.Services;
using System.Collections.ObjectModel;

namespace OdevApp1.Page.FılmDetay;

public partial class OppenheimerSayfa : ContentPage
{
    private readonly IFılmService _fılmService;
    public ObservableCollection<FılmlerM> Filmler { get; set; }
    public OppenheimerSayfa()
	{
		InitializeComponent();
        _fılmService = new FılmService();
        LoadFilmler();

    }
    private async void LoadFilmler()
    {
        var filmler = await _fılmService.GetFılmlerM();
        Filmler = new ObservableCollection<FılmlerM>(filmler.Where(x => x.FılmAdı.Contains("Oppenheimer")));
        collectionAd.ItemsSource = Filmler;
        collectionBaslık.ItemsSource = Filmler;
        collectionOzet.ItemsSource = Filmler;
        collectionOyuncular.ItemsSource = Filmler;
        collectionPuan.ItemsSource = Filmler;
        List<string> turListesi = new List<string>();
        foreach (var film in Filmler)
        {
            if (!string.IsNullOrEmpty(film.FılmTur))
            {
                string[] turArray = film.FılmTur.Split(',');

                foreach (var tur in turArray)
                {
                    string trimmedTur = tur.Trim();
                    turListesi.Add(trimmedTur);
                }
            }
        }

        collectionTur.ItemsSource = turListesi;
    }
    private async void geriButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}