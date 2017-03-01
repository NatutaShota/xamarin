using Xamarin.Forms;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

	class Data
	{
		public string Icon { get; set; }
		public string No { get; set; }
		public string Message { get; set; }
	}

	class MainPage : ContentPage
	{
		public MainPage()
		{
			// ページのタイトル
			Title = "MainPage";

			////ボタンを生成
			//var button1 = new Button { Text = "NextPage" };

			////ボタンクリック時の処理
			//button1.Clicked += async (sender, e) => {
			//	//ページを遷移する
			//	await Navigation.PushAsync(new NextPage());
			//};

			//Content = button1;


			//データの生成
			var ar = new List<Data>();
			// Listにデータを挿入...
			foreach (var n in Enumerable.Range(0, 100))
			{
				ar.Add(new Data { No = "No. " + n, Message = "Message-" + n, Icon = "icon.png" });
			}

			var listView = new ListView
			{
				ItemsSource = ar,//データソースの指定
				RowHeight = 60 // セルの高さ
			};
			listView.ItemTemplate = new DataTemplate(() =>
			{
				var icon = new Image();
				icon.SetBinding(Image.SourceProperty, "Icon");

				var no = new Label() { FontSize = 12 };
				no.SetBinding(Label.TextProperty, "No");

				var message = new Label() { FontSize = 20 };
				message.SetBinding(Label.TextProperty, "Message");

				//No Messageを縦に並べたテキストレイアウトを作成する
				var textLayout = new StackLayout
				{
					Children = { no, message }
				};

				return new ViewCell
				{
					View = new StackLayout
					{
						Orientation = StackOrientation.Horizontal,//Iconとテキストレイアウトを横に並べる
						Padding = new Thickness(20, 10, 0, 0),//パディング
						Spacing = 10,//スペース
						Children = { textLayout, icon }
					}
				};
			});

			listView.ItemTapped += async (sender, e) => {
				//ページを遷移する
				System.Diagnostics.Debug.WriteLine("sender：" + sender);
				System.Diagnostics.Debug.WriteLine("e：" + e);
				System.Diagnostics.Debug.WriteLine("this：" + this.Id);

				await Navigation.PushAsync(new NextPage());
			};

			//ListViewのみをコンテンツとして配置する
			Content = listView;
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
