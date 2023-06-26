using OdevApp1.Models;
using OdevApp1.Services;
using System.Collections.ObjectModel;

namespace OdevApp1.Page;

public partial class Anasayfa : ContentPage
{
    private readonly IFýlmService _fýlmService;
    public ObservableCollection<FýlmlerM> Filmler { get; set; }
    public ObservableCollection<FýlmlerM> Aksiyon { get; set; }
    public ObservableCollection<FýlmlerM> Gerilim { get; set; }
    public ObservableCollection<FýlmlerM> Biyografik { get; set; }
    public ObservableCollection<FýlmlerM> Komedi { get; set; }
    public ObservableCollection<FýlmlerM> Dram { get; set; }
    public ObservableCollection<FýlmlerM> Tarih { get; set; }
    public ObservableCollection<FýlmlerM> Animasyon { get; set; }


    public Anasayfa()
	{
        InitializeComponent();
        _fýlmService = new FýlmService();
        Filmler = new ObservableCollection<FýlmlerM>();
        Dram = new ObservableCollection<FýlmlerM>();
        LoadFilmler();
    }
    private async void LoadFilmler()
    {
        var filmler = await _fýlmService.GetFýlmlerM();
        Filmler = new ObservableCollection<FýlmlerM>(filmler.Take(5));
        Dram = new ObservableCollection<FýlmlerM>(filmler.Where(film => film.FýlmTur.Contains("Dram")).Take(5));
        Aksiyon = new ObservableCollection<FýlmlerM>(filmler.Where(film => film.FýlmTur.Split(',').Contains("Aksiyon")));
        Gerilim = new ObservableCollection<FýlmlerM>(filmler.Where(film => film.FýlmTur.Split(',').Contains("Gerilim")));
        Tarih = new ObservableCollection<FýlmlerM>(filmler.Where(film => film.FýlmTur.Contains("Tarih")));
        Komedi = new ObservableCollection<FýlmlerM>(filmler.Where(film => film.FýlmTur.Split(',').Contains("Komedi")));
        Animasyon = new ObservableCollection<FýlmlerM>(filmler.Where(film => film.FýlmTur.Split(',').Contains("Animasyon")));



        collectionViewFilmler.ItemsSource = Filmler;
        collectionViewDram.ItemsSource = Dram;
        collectionViewAksiyon.ItemsSource = Aksiyon;
        collectionViewAnimasyon.ItemsSource = Animasyon;
        collectionViewGerilim.ItemsSource = Gerilim;
        collectionViewTarih.ItemsSource = Tarih;
        collectionViewKomedi.ItemsSource = Komedi;

    }
    ////////////////////////////////////////////////


    ////////////////ARAMA\\\\\\\\\\\\\\\\\\\

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
    ////////////////////////////////////////////////

    private async void YabancýFýlmButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page.YabancýFýlmler());
    }

    private async void YerliFýlmButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page.YerliFýlmler());
    }

    private async void tumuButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page.Tumu());

    }
    private async void dramButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page.Dram());

    }

    private async void profilButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page.Profil());
    }

    private async void cýkýsButton(object sender, EventArgs e)
    {
        Giris girisPage =new Giris();
        await Navigation.PushModalAsync(new NavigationPage(girisPage) { BarBackgroundColor = Colors.Transparent, BarTextColor = Colors.White });
    }

    private async void oneCýkan(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (FýlmlerM)buton.BindingContext;

        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "Örümcek-Adam Eve Dönüþ Yok", typeof(Page.FýlmDetay.SpidermanSayfa) },
            { "Oppenheimer", typeof(Page.FýlmDetay.OppenheimerSayfa) },
            { "Dune: Çöl Gezegeni", typeof(Page.FýlmDetay.DuneSayfa) },
            { "1917", typeof(Page.FýlmDetay._1917) },
            { "Fakat Müzeyyen Bu Derin Bir Tutku", typeof(Page.FýlmDetay.MuzeyyenSayfa) }
        };

        if (filmPages.ContainsKey(film.FýlmAdý))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.FýlmAdý]));
        }

    }

    private async void dram(object sender, EventArgs e)
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
        };

        if (filmPages.ContainsKey(film.FýlmAdý))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.FýlmAdý]));
        }
    }

    private async void aksiyon(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (FýlmlerM)buton.BindingContext;

        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "Örümcek-Adam Eve Dönüþ Yok", typeof(Page.FýlmDetay.SpidermanSayfa) },
            { "Dune: Çöl Gezegeni", typeof(Page.FýlmDetay.DuneSayfa) },
            { "1917", typeof(Page.FýlmDetay._1917) },
            { "Spider-Man: Across The Spider-Verse", typeof(Page.FýlmDetay.AccrosSayfa) },
            { "Dövüþ Kulübü", typeof(Page.FýlmDetay.DovusSayfa) }
        };

        if (filmPages.ContainsKey(film.FýlmAdý))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.FýlmAdý]));
        }
    }

    private async void tarih(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (FýlmlerM)buton.BindingContext;

        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "Oppenheimer", typeof(Page.FýlmDetay.OppenheimerSayfa) },
            { "1917", typeof(Page.FýlmDetay._1917) },
            { "Batý Cephesinde Yeni Bir Þey Yok", typeof(Page.FýlmDetay.BatýSayfa) },
            { "Louis Wain'in Renkli Dünyasý", typeof(Page.FýlmDetay.LouiseSayfa) }
        };

        if (filmPages.ContainsKey(film.FýlmAdý))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.FýlmAdý]));
        }
    }

    private async void gerilim(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (FýlmlerM)buton.BindingContext;

        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "Oppenheimer", typeof(Page.FýlmDetay.OppenheimerSayfa) },
            { "Kurak Günler", typeof(Page.FýlmDetay.KurakSayfa) },
            { "Sarmaþýk", typeof(Page.FýlmDetay.SarmasýkSayfa) },
            { "Dövüþ Kulübü", typeof(Page.FýlmDetay.DovusSayfa) }
        };

        if (filmPages.ContainsKey(film.FýlmAdý))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.FýlmAdý]));
        }
    }

    private async void komedi(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (FýlmlerM)buton.BindingContext;

        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "Ölümlü Dünya", typeof(Page.FýlmDetay.OlumluSayfa) },
            { "Kelebekler", typeof(Page.FýlmDetay.KelebeklerSayfa) }
        };

        if (filmPages.ContainsKey(film.FýlmAdý))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.FýlmAdý]));
        }

    }

    private async void animasyon(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (FýlmlerM)buton.BindingContext;

        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "Spider-Man: Across The Spider-Verse", typeof(Page.FýlmDetay.AccrosSayfa) },
        };

        if (filmPages.ContainsKey(film.FýlmAdý))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.FýlmAdý]));
        }


    }

    
}