using MobileDeliveryGeneral.Data;
using MobileDeliveryGeneral.Utilities;
using MobileDeliveryMVVM.ViewModel;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDeliveryUI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CloseStopPage : ContentPage
    {
        //private Point[] points;
        List<OrderDetailsModelData> lstOrd;
        List<OrderDetailsModelData> lstBOrd;
        StopData sd;

        public CloseStopPage(StopData sd, List<OrderDetailsModelData> odlst, List<OrderDetailsModelData> bodlst)
        {
            this.sd = sd;
            lstOrd = odlst;
            lstBOrd = bodlst;
            InitializeComponent();
        }
        public CloseStopPage ()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            var vm = this.BindingContext as CloseStopVM;

            if (vm != null)
            {
                foreach (var or in lstOrd)
                    vm.ShippedOrderCollection.Add(or);
                foreach (var bord in lstBOrd)
                    vm.BackOrderCollection.Add(bord);
            }
            lblStopNo.Text = sd.DisplaySeq.ToString();
            lblManId.Text = sd.ManifestId.ToString();
            this.btnConfirmPOD.IsEnabled = false;
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var vm = (CloseStopVM)BindingContext; // Warning, the BindingContext View <-> ViewModel is already set

            vm.SignatureFromStream = async () =>
            {
                if (SignatureView.Points.Count() > 0)
                {
                    using (var stream = await SignatureView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png))
                    {
                        return await ImageConverter.ReadFully(stream);
                    }
                }
                return await Task.Run(() => (byte[])null);
            };
        }

        private void DismissButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void SaveImageClicked(object sender, EventArgs e)
        {
            //bool saved;
            //using (var bitmap = await SignatureView.GetImageStreamAsync(SignatureImageFormat.Png, Color.Black, Color.White, 1f))
            //{
            //    saved = await App.SaveSignature(bitmap, "signature.png");
            //}

            //if (saved)
            //    await DisplayAlert("Signature Pad", "Raster signature saved to the photo library.", "OK");
            //else
            //    await DisplayAlert("Signature Pad", "There was an error saving the signature.", "OK");
        }
        private void OnSave(object sender, EventArgs e)
        { }
        private void OnClear(object sender, EventArgs e)
        { }
        private void OrderSelected(object sender, ItemTappedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
                return;
            var ordData = (OrderMasterData)((ListView)sender).SelectedItem;
            var orderOptionsPage = new OrderOptions(ordData);
            ((ListView)sender).SelectedItem = null;
            //OPDetail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            //Navigation.PushAsync(orderDetailsPage);
            //Navigation.PopAsync(true);
            
            NavigationPage.SetBackButtonTitle(orderOptionsPage, "Close Stop Order Options for Order Number " + ordData.ORD_NO);
        }
        private void SignatureChanged(object sender, EventArgs e)
        {
            var vm = this.BindingContext as CloseStopVM;

            this.btnConfirmPOD.IsEnabled = true;
            // Stream bitmap1 = await SignatureView.GetImageStreamAsync(SignatureImageFormat.Png);
            Task.Run( () => copystreamtoVM(vm));
            //Task tsk = new Task(() => {

            //});

            //tsk.Start();
        }


        async void copystreamtoVM(CloseStopVM vm)
        {
            //Dispatcher.BeginInvokeOnMainThread((Action)(async () =>
            //{
            //    using (var bitmap = await SignatureView.GetImageStreamAsync(SignatureImageFormat.Png, Color.Black, Color.White, 1f))
            //    {
            //        MemoryStream signatureMemoryStream = new MemoryStream();
            //        bitmap.CopyToAsync(signatureMemoryStream, (int)bitmap.Length);
            //        vm.Signature = signatureMemoryStream.ToArray();
            //    }
            //})
            //);
            

           
        }
    }
}