using Xamarin.Forms;

namespace demo1
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new demo1Page();
			// NavigationPageを使用して最初のページを表示する
			MainPage = new NavigationPage(new MainPage())
			{
				// タイトルバーの背景色や文字色は、NavigationPageのプロパティをセットする
				BarBackgroundColor = Color.FromRgba(0.2, 0.6, 0.86, 1),
				BarTextColor = Color.White
			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}

	class MainPage : ContentPage
	{
		public MainPage()
		{
			// ページのタイトル
			Title = "MainPage";

			//ボタンを生成
			var button1 = new Button { Text = "NextPage" };

			//ボタンクリック時の処理
			button1.Clicked += async (sender, e) => {
				//ページを遷移する
				await Navigation.PushAsync(new NextPage());
			};

			Content = button1;

		}
	}

	//遷移後のページ
	class NextPage : ContentPage
	{
		public NextPage()
		{
			// ページのタイトル
			Title = "NextPage";
		}
	}
}
