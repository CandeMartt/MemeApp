using MeMAUI.Models;
using MeMAUI.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeMAUI.ViewModels
{
    internal class CreatorViewModel : BaseViewModel
    {
        private string currentImage = "https://i.imgflip.com/1g8my4.jpg";

        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public ICommand GenerateButton { get; set; }
        public ICommand DownloadButton { get; set; }
        public MemeResponse memeResponse { get; set; }
        public string CurrentImage
        {
            get => currentImage;
            set
            {
                currentImage = value;
                OnPropertyChanged();
            }
        }
        public CreatorViewModel(object model)
        {
            var meme = model as Meme;
            if (meme != null)
            {
                currentImage = meme.url;
            }

            GenerateButton = new Command(async () =>
            {
                MultipartFormDataContent multiContent = new MultipartFormDataContent();
                multiContent.Headers.ContentType.MediaType = "multipart/form-data";
                multiContent.Add(new StringContent(meme.id), "template_id");
                multiContent.Add(new StringContent("demos222"), "username");
                multiContent.Add(new StringContent("p@ssw0rd123"), "password");
                multiContent.Add(new StringContent(Text1), "boxes[0][text]");
                multiContent.Add(new StringContent(Text2), "boxes[1][text]");

                HttpClient client = new HttpClient();
                var response = await client.PostAsync("https://api.imgflip.com/caption_image", multiContent);
                var responsestr = response.Content.ReadAsStringAsync().Result;
                memeResponse = JsonConvert.DeserializeObject<MemeResponse>(responsestr);
                CurrentImage = memeResponse.data.url;
            });
        }
    }
}
