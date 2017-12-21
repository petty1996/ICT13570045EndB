using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ICT13570045EndB
{
    public partial class ProductNewPage : ContentPage
    {
        public ProductNewPage()
        {
            InitializeComponent();

			this.product = product;

			titleLabel.Text = product == null ? "เพิ่มรถยนต์ใหม่" : "แก้ไขข้อมูลรถยนต์";

			saveButton.Clicked += SaveButton_Clicked;
			cancelButton.Clicked += CancelButton_Clicked;

			typePicker.Items.Add("รถยนต์");
			typePicker.Items.Add("รถบัส");
			typePicker.Items.Add("รถตู้");
			typePicker.Items.Add("รถบรรทุก");

			brandPicker.Items.Add("นิสสัน");
			brandPicker.Items.Add("ปอร์เช่");
			brandPicker.Items.Add("บีเอ็มดับเบิลยู");

			colourPicker.Items.Add("Red");
			colourPicker.Items.Add("Green");
			colourPicker.Items.Add("Blue");

			provincePicker.Items.Add("กรุงเทพ");
			provincePicker.Items.Add("ระยอง");
			provincePicker.Items.Add("ระนอง");
			provincePicker.Items.Add("ยะลา");
			provincePicker.Items.Add("เพชรบุรี");

			mySlider.ValueChanged += MySlider_ValueChanged;

			myStepper.ValueChanged += MyStepper_ValueChanged;

			if (product != null)
			{
				typePicker.SelectedItem = product.Type;
				brandPicker.SelectedItem = product.Brand;
				generationEntry.Text = product.Generation;
				yearLabel.Text = product.Year.ToString();
				mileLabel.Text = product.Mile.ToString();
				colourPicker.SelectedItem = product.Colour;
				dealerSwitch.IsToggled = product.Dealer;
				detailEditor.Text = product.Detail;
				priceEntry.Text = product.Price.ToString();
				provincePicker.SelectedItem = product.Province;
				phoneEntry.Text = product.Phone.ToString();
			}
		}

		async void SaveButton_Clicked(object sender, EventArgs e)
		{
			var isOK = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");

			if (isOK)
			{
				if (product == null)
				{
					product = new Product();

					product.Type = typePicker.SelectedItem.ToString();
					product.Brand = brandPicker.SelectedItem.ToString();
					product.Generation = generationEntry.Text;
					product.Year = int.Parse(yearLabel.Text);
					product.Mile = int.Parse(mileLabel.Text);
					product.Colour = colourPicker.SelectedItem.ToString();
					product.Dealer = dealerSwitch.IsToggled;
					product.Detail = detailEditor.Text;
					product.Price = int.Parse(priceEntry.Text);
					product.Province = provincePicker.SelectedItem.ToString();
					product.Phone = int.Parse(phoneEntry.Text);

					var id = App.DbHelper.AddProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
				}
				else
				{
					product.Type = typePicker.SelectedItem.ToString();
					product.Brand = brandPicker.SelectedItem.ToString();
					product.Generation = generationEntry.Text;
					product.Year = int.Parse(yearLabel.Text);
					product.Mile = int.Parse(mileLabel.Text);
					product.Colour = colourPicker.SelectedItem.ToString();
					product.Dealer = dealerSwitch.IsToggled;
					product.Detail = detailEditor.Text;
					product.Price = int.Parse(priceEntry.Text);
					product.Province = provincePicker.SelectedItem.ToString();
					product.Phone = int.Parse(phoneEntry.Text);
					var id = App.DbHelper.UpdateProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลรถยนต์เรียบร้อย", "ตกลง");
				}
				await Navigation.PopModalAsync();
			}
		}

		private void CancelButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}

		private void MyStepper_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			int value = (int)e.NewValue;
			yearLabel.Text = value.ToString();
		}

		private void MySlider_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			int value = (int)e.NewValue;
			mileLabel.Text = value.ToString();
		}
	}
}
