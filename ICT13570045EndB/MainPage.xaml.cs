using ICT13570045EndB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICT13570045EndB
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			newButton.Clicked += NewButton_Clicked;

		}

		protected override void OnAppearing()
		{
			LoadData();
		}

		void LoadData()
		{
			productListView.ItemsSource = App.DbHelper.GetProducts();
		}

		void NewButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new ProductPage());
		}

		void Edit_Clicked(object sender, EventArgs e)
		{
			var button = sender as MenuItem;
			var product = button.CommandParameter as Product;
			Navigation.PushModalAsync(new ProductPage(product));
		}

		async void Delete_Clicked(object sender, EventArgs e)
		{
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่หรือไม่", "ใช่", "ไม่ใช่");

			if (isOk)
			{
				var button = sender as MenuItem;
				var product = button.CommandParameter as Product;
				App.DbHelper.DeleteProduct(product);

				await DisplayAlert("ลบสำเร็จ", "ลบข้อมูลเรียบร้อย", "ตกลง");
				LoadData();
			}
		}
	}
}