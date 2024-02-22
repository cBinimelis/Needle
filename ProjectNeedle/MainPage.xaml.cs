using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace ProjectNeedle
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            folderBtn.Clicked += (s, e) => PickFolder();
            exitBtn.Clicked += (s, e) => Close();
        }


        async void PickFolder()
        {
            var result = await FolderPicker.PickAsync(default);
            if (result.IsSuccessful)
            {
                await Toast.Make($"The folder was picked: Name - {result.Folder.Name}, Path - {result.Folder.Path}").Show();
            }
            else
            {
                await Toast.Make($"The folder was not picked with error: {result.Exception.Message}").Show();
            }
        }

        void Close() => Application.Current.Quit();
    }

}
