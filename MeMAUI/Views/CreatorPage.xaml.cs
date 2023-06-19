using MeMAUI.ViewModels;

namespace MeMAUI.Views;

public partial class CreatorPage : ContentPage
{
    public CreatorPage(object data)
    {
		InitializeComponent();
		BindingContext = new CreatorViewModel(data);
	}
}