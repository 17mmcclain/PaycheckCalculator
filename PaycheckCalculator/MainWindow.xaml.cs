using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaycheckCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        decimal total;
        decimal initialTotal;
        decimal statetax;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {

            Functions newFunctions = new Functions(this);

            if (OTHoursPerPayPeriod.Text == "")
            {
                OTHoursPerPayPeriod.Text = "0";
            }

            if (HourlyRButton.IsChecked == true)
            {
                initialTotal = newFunctions.HourlyTotal(Convert.ToDecimal(HourlyWageTextbox.Text), Convert.ToDecimal(HoursPerPeriodTextbox.Text), Convert.ToDecimal(OTHoursPerPayPeriod.Text));
                statetax = newFunctions.utahStateTax(initialTotal);
            }
            else
            {
                initialTotal = newFunctions.SalaryTotal(Convert.ToDecimal(HourlyWageTextbox.Text));
                statetax = newFunctions.utahStateTax(initialTotal);
            }

            if (SingleRButton.IsChecked == true)
            {
                if (HourlyRButton.IsChecked == true)
                {
                    decimal federaltax = newFunctions.SingleRadioButton(initialTotal);
                    decimal singleTotal = initialTotal - statetax - federaltax;

                    PayTotalTextbox.Text = singleTotal.ToString("C");

                    FederalTaxTextbox.Text = (federaltax).ToString("C");
                    StateTaxTextbox.Text = (statetax).ToString("C");

                    newFunctions.preTaxDeductions();

                    newFunctions.preTaxandGrossHourly();
                }

                if (SalaryRButton.IsChecked == true)
                {
                    decimal federaltax = newFunctions.SingleRadioButton(initialTotal);
                    decimal singleTotal = initialTotal - statetax - federaltax;

                    decimal singleFinalTotal = newFunctions.payFrequency(singleTotal);

                    PayTotalTextbox.Text = singleFinalTotal.ToString("C");

                    FederalTaxTextbox.Text = (federaltax / newFunctions.payFrequencyDivisor()).ToString("C");
                    StateTaxTextbox.Text = (statetax / newFunctions.payFrequencyDivisor()).ToString("C");

                    newFunctions.preTaxDeductions();

                    newFunctions.preTaxandGrossSalary();
                }
            }

            if (MarriedRButton.IsChecked == true)
            {
                if (HourlyRButton.IsChecked == true)
                {
                    decimal federaltax = newFunctions.MarriedRadioButton(initialTotal);
                    decimal marriedTotal = initialTotal - statetax - federaltax;

                    PayTotalTextbox.Text = marriedTotal.ToString("C");

                    FederalTaxTextbox.Text = (federaltax).ToString("C");
                    StateTaxTextbox.Text = (statetax).ToString("C");

                    newFunctions.preTaxDeductions();

                    newFunctions.preTaxandGrossHourly();
                }

                if (SalaryRButton.IsChecked == true)
                {
                    decimal federaltax = newFunctions.MarriedRadioButton(initialTotal);
                    decimal marriedTotal = initialTotal - statetax - federaltax;

                    decimal marriedFinalTotal = newFunctions.payFrequency(marriedTotal);

                    PayTotalTextbox.Text = marriedFinalTotal.ToString("C");

                    FederalTaxTextbox.Text = (federaltax / newFunctions.payFrequencyDivisor()).ToString("C");
                    StateTaxTextbox.Text = (statetax / newFunctions.payFrequencyDivisor()).ToString("C");

                    newFunctions.preTaxDeductions();

                    newFunctions.preTaxandGrossSalary();
                }

            }

            if (HOHRButton.IsChecked == true)
            {
                if (HourlyRButton.IsChecked == true)
                {
                    decimal federaltax = newFunctions.HOHRadioButton(initialTotal);
                    decimal HOHTotal = initialTotal - statetax - federaltax;

                    PayTotalTextbox.Text = HOHTotal.ToString("C");

                    FederalTaxTextbox.Text = (federaltax).ToString("C");
                    StateTaxTextbox.Text = (statetax).ToString("C");

                    newFunctions.preTaxDeductions();

                    newFunctions.preTaxandGrossHourly();
                }

                if (SalaryRButton.IsChecked == true)
                {
                    decimal federaltax = newFunctions.HOHRadioButton(initialTotal);
                    decimal HOHTotal = initialTotal - statetax - federaltax;

                    decimal HOHFinalTotal = newFunctions.payFrequency(HOHTotal);

                    PayTotalTextbox.Text = HOHFinalTotal.ToString("C");

                    FederalTaxTextbox.Text = (federaltax / newFunctions.payFrequencyDivisor()).ToString("C");
                    StateTaxTextbox.Text = (statetax / newFunctions.payFrequencyDivisor()).ToString("C");

                    newFunctions.preTaxDeductions();

                    PreTaxTextbox.Text = (Convert.ToDecimal((InsuranceTextbox.Text).Substring(1)) + Convert.ToDecimal((RetirementTextbox.Text).Substring(1)) + Convert.ToDecimal((HSAFSATextbox.Text).Substring(1))).ToString("C");
                    GrossPayTextbox.Text = (Convert.ToDecimal(HourlyWageTextbox.Text) / newFunctions.payFrequencyDivisor()).ToString("C");
                }
            }


        }

        private void SalaryRButton_Checked(object sender, RoutedEventArgs e)
        {
            WeeklyRButton.IsEnabled = true;
            BiWeeklyRButton.IsEnabled = true;
            SemiMonthlyRButton.IsEnabled = true;
            MonthlyRButton.IsEnabled = true;
            AnnualRButton.IsEnabled = true;

            WageTypeLabel.Content = "Salary (yearly)";

            CalculateButton.IsEnabled = false;

            if (HourlyWageTextbox.Text != "")
            {
                if (WeeklyRButton.IsChecked == true || BiWeeklyRButton.IsChecked == true || SemiMonthlyRButton.IsChecked == true ||
                    MonthlyRButton.IsChecked == true || AnnualRButton.IsChecked == true)
                {
                    CalculateButton.IsEnabled = true;
                }
            }

        }

        private void HourlyRButton_Checked(object sender, RoutedEventArgs e)
        {
            WeeklyRButton.IsEnabled = false;
            BiWeeklyRButton.IsEnabled = false;
            SemiMonthlyRButton.IsEnabled = false;
            MonthlyRButton.IsEnabled = false;
            AnnualRButton.IsEnabled = false;

            WageTypeLabel.Content = "Hourly Wage";

            CalculateButton.IsEnabled = true;
        }

        private void HourlyWageTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SalaryRButton.IsChecked == true)
            {
                if (WeeklyRButton.IsChecked == true || BiWeeklyRButton.IsChecked == true || SemiMonthlyRButton.IsChecked == true ||
                    MonthlyRButton.IsChecked == true || AnnualRButton.IsChecked == true)
                {
                    CalculateButton.IsEnabled = true;
                }
            }
        }
    }
}