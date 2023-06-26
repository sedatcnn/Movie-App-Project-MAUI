using Microsoft.VisualBasic;
using OdevApp1.Models;
using OdevApp1.Services;
using System.Collections.ObjectModel;

namespace OdevApp1.Page.F�lmDetay;

public partial class KaderSayfa : ContentPage
{
    private readonly IF�lmService _f�lmService;
    public ObservableCollection<F�lmlerM> Filmler { get; set; }


    public KaderSayfa()
	{
		InitializeComponent();
        _f�lmService=new F�lmService();
        LoadFilmler();

    }
    private async void LoadFilmler()
    {
        var filmler = await _f�lmService.GetF�lmlerM();
        Filmler = new ObservableCollection<F�lmlerM>(filmler.Where(x => x.F�lmAd�.Contains("Kader")));
        collectionAd.ItemsSource= Filmler;
        collectionBasl�k.ItemsSource= Filmler;
        collectionOzet.ItemsSource= Filmler;
        collectionOyuncular.ItemsSource= Filmler;
        collectionPuan.ItemsSource= Filmler;
        List<string> turListesi = new List<string>();
        foreach (var film in Filmler)
        {
            if (!string.IsNullOrEmpty(film.F�lmTur))
            {
                string[] turArray = film.F�lmTur.Split(',');

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
