using OdevApp1.Models;
using OdevApp1.Services;
using System.Collections.ObjectModel;

namespace OdevApp1.Page;

public partial class Anasayfa : ContentPage
{
    private readonly IF�lmService _f�lmService;
    public ObservableCollection<F�lmlerM> Filmler { get; set; }
    public ObservableCollection<F�lmlerM> Aksiyon { get; set; }
    public ObservableCollection<F�lmlerM> Gerilim { get; set; }
    public ObservableCollection<F�lmlerM> Biyografik { get; set; }
    public ObservableCollection<F�lmlerM> Komedi { get; set; }
    public ObservableCollection<F�lmlerM> Dram { get; set; }
    public ObservableCollection<F�lmlerM> Tarih { get; set; }
    public ObservableCollection<F�lmlerM> Animasyon { get; set; }


    public Anasayfa()
	{
        InitializeComponent();
        _f�lmService = new F�lmService();
        Filmler = new ObservableCollection<F�lmlerM>();
        Dram = new ObservableCollection<F�lmlerM>();
        LoadFilmler();
    }
    private async void LoadFilmler()
    {
        var filmler = await _f�lmService.GetF�lmlerM();
        Filmler = new ObservableCollection<F�lmlerM>(filmler.Take(5));
        Dram = new ObservableCollection<F�lmlerM>(filmler.Where(film => film.F�lmTur.Contains("Dram")).Take(5));
        Aksiyon = new ObservableCollection<F�lmlerM>(filmler.Where(film => film.F�lmTur.Split(',').Contains("Aksiyon")));
        Gerilim = new ObservableCollection<F�lmlerM>(filmler.Where(film => film.F�lmTur.Split(',').Contains("Gerilim")));
        Tarih = new ObservableCollection<F�lmlerM>(filmler.Where(film => film.F�lmTur.Contains("Tarih")));
        Komedi = new ObservableCollection<F�lmlerM>(filmler.Where(film => film.F�lmTur.Split(',').Contains("Komedi")));
        Animasyon = new ObservableCollection<F�lmlerM>(filmler.Where(film => film.F�lmTur.Split(',').Contains("Animasyon")));



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
    ////////////////////////////////////////////////

    private async void Yabanc�F�lmButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page.Yabanc�F�lmler());
    }

    private async void YerliF�lmButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page.YerliF�lmler());
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

    private async void c�k�sButton(object sender, EventArgs e)
    {
        Giris girisPage =new Giris();
        await Navigation.PushModalAsync(new NavigationPage(girisPage) { BarBackgroundColor = Colors.Transparent, BarTextColor = Colors.White });
    }

    private async void oneC�kan(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (F�lmlerM)buton.BindingContext;

        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "�r�mcek-Adam Eve D�n�� Yok", typeof(Page.F�lmDetay.SpidermanSayfa) },
            { "Oppenheimer", typeof(Page.F�lmDetay.OppenheimerSayfa) },
            { "Dune: ��l Gezegeni", typeof(Page.F�lmDetay.DuneSayfa) },
            { "1917", typeof(Page.F�lmDetay._1917) },
            { "Fakat M�zeyyen Bu Derin Bir Tutku", typeof(Page.F�lmDetay.MuzeyyenSayfa) }
        };

        if (filmPages.ContainsKey(film.F�lmAd�))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.F�lmAd�]));
        }

    }

    private async void dram(object sender, EventArgs e)
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
        };

        if (filmPages.ContainsKey(film.F�lmAd�))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.F�lmAd�]));
        }
    }

    private async void aksiyon(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (F�lmlerM)buton.BindingContext;

        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "�r�mcek-Adam Eve D�n�� Yok", typeof(Page.F�lmDetay.SpidermanSayfa) },
            { "Dune: ��l Gezegeni", typeof(Page.F�lmDetay.DuneSayfa) },
            { "1917", typeof(Page.F�lmDetay._1917) },
            { "Spider-Man: Across The Spider-Verse", typeof(Page.F�lmDetay.AccrosSayfa) },
            { "D�v�� Kul�b�", typeof(Page.F�lmDetay.DovusSayfa) }
        };

        if (filmPages.ContainsKey(film.F�lmAd�))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.F�lmAd�]));
        }
    }

    private async void tarih(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (F�lmlerM)buton.BindingContext;

        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "Oppenheimer", typeof(Page.F�lmDetay.OppenheimerSayfa) },
            { "1917", typeof(Page.F�lmDetay._1917) },
            { "Bat� Cephesinde Yeni Bir �ey Yok", typeof(Page.F�lmDetay.Bat�Sayfa) },
            { "Louis Wain'in Renkli D�nyas�", typeof(Page.F�lmDetay.LouiseSayfa) }
        };

        if (filmPages.ContainsKey(film.F�lmAd�))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.F�lmAd�]));
        }
    }

    private async void gerilim(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (F�lmlerM)buton.BindingContext;

        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "Oppenheimer", typeof(Page.F�lmDetay.OppenheimerSayfa) },
            { "Kurak G�nler", typeof(Page.F�lmDetay.KurakSayfa) },
            { "Sarma��k", typeof(Page.F�lmDetay.Sarmas�kSayfa) },
            { "D�v�� Kul�b�", typeof(Page.F�lmDetay.DovusSayfa) }
        };

        if (filmPages.ContainsKey(film.F�lmAd�))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.F�lmAd�]));
        }
    }

    private async void komedi(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (F�lmlerM)buton.BindingContext;

        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "�l�ml� D�nya", typeof(Page.F�lmDetay.OlumluSayfa) },
            { "Kelebekler", typeof(Page.F�lmDetay.KelebeklerSayfa) }
        };

        if (filmPages.ContainsKey(film.F�lmAd�))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.F�lmAd�]));
        }

    }

    private async void animasyon(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var film = (F�lmlerM)buton.BindingContext;

        Dictionary<string, Type> filmPages = new Dictionary<string, Type>
        {
            { "Spider-Man: Across The Spider-Verse", typeof(Page.F�lmDetay.AccrosSayfa) },
        };

        if (filmPages.ContainsKey(film.F�lmAd�))
        {
            await Navigation.PushAsync((Microsoft.Maui.Controls.Page)Activator.CreateInstance(filmPages[film.F�lmAd�]));
        }


    }

    
}