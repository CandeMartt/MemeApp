using MeMAUI.Models;
using MeMAUI.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MeMAUI.ViewModels
{
    internal class MainPageViewModel : BaseViewModel
    {
        HttpClient client = new HttpClient();
        private ObservableCollection<Meme> memes;
        public ObservableCollection<Meme> Memes
        {
            get => memes;
            set
            {
                memes = value;
                OnPropertyChanged();
            }
        }
        private Meme currentMeme;

        public Meme CurrentMeme
        {
            get => currentMeme;
            set
            {
                currentMeme = value;

                var page = new CreatorPage(currentMeme);
                Navigation.PushAsync(page);
            }
        }

        private INavigation Navigation;
        public MainPageViewModel(INavigation _navigation)
        {
            Navigation = _navigation;
            {
                Task.Run(async () =>
                {
                    var result = await client.GetStringAsync("https://api.imgflip.com/get_memes");
                    var collection =
                        JsonConvert.DeserializeObject<MemeData>(result);
                    if (collection.data != null)
                    {
                        Memes = new ObservableCollection<Meme>(collection.data.memes.Where(x => x.box_count == 2));
                    }
                });
            }
        }
    }
}
