using Microsoft.VisualBasic;
using OdevApp1.Models;
using OdevApp1.Services;
using System.Collections.ObjectModel;

namespace OdevApp1.Page.FýlmDetay;

public partial class KaderSayfa : ContentPage
{
    private readonly IFýlmService _fýlmService;
    public ObservableCollection<FýlmlerM> Filmler { get; set; }


    public KaderSayfa()
	{
		InitializeComponent();
        _fýlmService=new FýlmService();
        LoadFilmler();

    }
    private async void LoadFilmler()
    {
        var filmler = await _fýlmService.GetFýlmlerM();
        Filmler = new ObservableCollection<FýlmlerM>(filmler.Where(x => x.FýlmAdý.Contains("Kader")));
        collectionAd.ItemsSource= Filmler;
        collectionBaslýk.ItemsSource= Filmler;
        collectionOzet.ItemsSource= Filmler;
        collectionOyuncular.ItemsSource= Filmler;
        collectionPuan.ItemsSource= Filmler;
        List<string> turListesi = new List<string>();
        foreach (var film in Filmler)
        {
            if (!string.IsNullOrEmpty(film.FýlmTur))
            {
                string[] turArray = film.FýlmTur.Split(',');

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
