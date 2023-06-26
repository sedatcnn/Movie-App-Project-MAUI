using Microsoft.VisualBasic;
using OdevApp1.Models;
using OdevApp1.Services;
using System.Collections.ObjectModel;

namespace OdevApp1.Page.FılmDetay;

public partial class Ahlat : ContentPage
{
    private readonly IFılmService _fılmService;
    public ObservableCollection<FılmlerM> Filmler { get; set; }
    public Ahlat()
	{
		InitializeComponent();
        _fılmService = new FılmService();
        LoadFilmler();
    }
    private async void LoadFilmler()
    {
        var filmler = await _fılmService.GetFılmlerM();
        Filmler = new ObservableCollection<FılmlerM>(filmler.Where(x => x.FılmAdı.Contains("Ahlat Ağacı")));
        collectionAd.ItemsSource = Filmler;
        collectionBaslık.ItemsSource = Filmler;
        collectionOzet.ItemsSource = Filmler;
        collectionOyuncular.ItemsSource = Filmler;
        collectionPuan.ItemsSource = Filmler;
        collectionTur.ItemsSource = Filmler;
    }
    private async void geriButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}