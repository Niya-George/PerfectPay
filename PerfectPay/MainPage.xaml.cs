namespace PerfectPay
{
    public partial class MainPage : ContentPage
    {
        decimal bill; //total of the bill
        int tip;     //percentage going to tip
        int noPeople = 1; //min no of ppl needed

        public MainPage()
        {
            InitializeComponent();
        }

        private void txtBill_Completed(object sender, EventArgs e)
        {
            bill = decimal.Parse(txtBill.Text);  //string converted to decimal
            CalculateTotal();
        }

        private void CalculateTotal()


        {
           
            var totaltip = (bill * tip) / 100; //total tip amount
            var tipbyperson = (totaltip/noPeople);  //tip by person
            lblTip1.Text= $"{tipbyperson:C}";

            var subtotal = (bill / noPeople);
            lblSubtotal.Text = $"{subtotal:C}";

            var totalbyperson = (bill+totaltip)/noPeople;
            lblTotal.Text = $"{totalbyperson:C}";
        }

        private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)sldTip.Value;   //conversion to integer type
            lblTip2.Text = $"Tip : {tip}%" ;
            CalculateTotal();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                var btn=(Button)sender;
                var percentage = int.Parse(btn.Text.Replace("%", ""));
                sldTip.Value =percentage;
            }
        }

        private void btnminus_Clicked(object sender, EventArgs e)
        {
            if (noPeople > 0)
            {
                noPeople--;
            }
                lblnopeople.Text= noPeople.ToString();
                CalculateTotal();
            
        }

        private void btnplus_Clicked(object sender, EventArgs e)
        {
            if (noPeople > 0)
            {
                noPeople++;
            }
                lblnopeople.Text = noPeople.ToString();
                CalculateTotal();
            
        }
    }

}
