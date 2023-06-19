using MeMAUI.ViewModels;

namespace MeMAUI;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel(this.Navigation);
	}

}

