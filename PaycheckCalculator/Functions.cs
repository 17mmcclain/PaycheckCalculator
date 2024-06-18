using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PaycheckCalculator
{
    public class Functions
    {
        private MainWindow window;
        decimal pretotal;
        decimal total;
        public Functions(MainWindow w)
            { this.window = w; }

        public decimal preHourlyTotal(decimal wage, decimal regHours, decimal otHours)
        {
            pretotal = wage * regHours + ((decimal.Multiply(wage, Convert.ToDecimal(1.5))) * otHours);
            return pretotal;
        }
        public decimal HourlyTotal(decimal wage, decimal regHours, decimal otHours)
        {

            total = preHourlyTotal(wage, regHours, otHours);

            if (window.InsuranceTextbox.Text != "")
            {
                if (window.InsuranceTextbox.Text.Substring(0, 1) != "$")
                {
                    total = total - Convert.ToDecimal(window.InsuranceTextbox.Text);
                }
                else
                {
                    total = total - Convert.ToDecimal((window.InsuranceTextbox.Text).Substring(1));
                }
            }

            if (window.RetirementTextbox.Text != "")
            {
                if (window.RetirementTextbox.Text.Substring(0, 1) != "$")
                {
                    total = total - Convert.ToDecimal(window.RetirementTextbox.Text);
                }
                else
                {
                    total = total - Convert.ToDecimal((window.RetirementTextbox.Text).Substring(1));
                }
            }

            if (window.HSAFSATextbox.Text != "")
            {
                if (window.HSAFSATextbox.Text.Substring(0, 1) != "$")
                {
                    total = total - Convert.ToDecimal(window.HSAFSATextbox.Text);
                }
                else
                {
                    total = total - Convert.ToDecimal((window.HSAFSATextbox.Text).Substring(1));
                }
            }

            return total;
        }

        public decimal preSalaryTotal(decimal wage)
        {
            total = Convert.ToDecimal(window.HourlyWageTextbox.Text);
            return total;
        }
        public decimal SalaryTotal (decimal wage)
        {
            total = preSalaryTotal(wage);

            if (window.InsuranceTextbox.Text != "")
            {
                if (window.InsuranceTextbox.Text.Substring(0, 1) != "$")
                {
                    total = total - Convert.ToDecimal(window.InsuranceTextbox.Text);
                }
                else
                {
                    total = total - Convert.ToDecimal((window.InsuranceTextbox.Text).Substring(1));
                }
            }

            if (window.RetirementTextbox.Text != "")
            {
                if (window.RetirementTextbox.Text.Substring(0, 1) != "$")
                {
                    total = total - Convert.ToDecimal(window.RetirementTextbox.Text);
                }
                else
                {
                    total = total - Convert.ToDecimal((window.RetirementTextbox.Text).Substring(1));
                }
            }

            if (window.HSAFSATextbox.Text != "")
            {
                if (window.HSAFSATextbox.Text.Substring(0, 1) != "$")
                {
                    total = total - Convert.ToDecimal(window.HSAFSATextbox.Text);
                }
                else
                {
                    total = total - Convert.ToDecimal((window.HSAFSATextbox.Text).Substring(1));
                }
            }

            return total;
        }

        public decimal SingleRadioButton(decimal total)
        {
            if (total > 0 && total <= 11600)
            {
                decimal tax = total * Convert.ToDecimal(0.10);
                return tax;
            }

            if (total > 11600 && total <= 47150)
            {
                decimal tax = total * Convert.ToDecimal(0.12);
                return tax;
            }

            if (total > 47150 && total <= 100525)
            {
                decimal tax = total * Convert.ToDecimal(0.22);
                return tax;
            }

            if (total > 100525 && total <= 191950)
            {
                decimal tax = total * Convert.ToDecimal(0.24);
                return tax;
            }

            if (total > 191950 && total <= 243725)
            {
                decimal tax = total * Convert.ToDecimal(0.32);
                return tax;
            }

            if (total > 243725 && total <= 609350)
            {
                decimal tax = total * Convert.ToDecimal(0.35);
                return tax;
            }

            if (total > 609350)
            {
                decimal tax = total * Convert.ToDecimal(0.37);
                return tax;
            }
            return 0;
        }

        public decimal MarriedRadioButton(decimal total)
        {
            if (total > 0 && total <= 23200)
            {
                decimal tax = total * Convert.ToDecimal(0.10);
                return tax;
            }

            if (total > 23200 && total <= 94300)
            {
                decimal tax = total * Convert.ToDecimal(0.12);
                return tax;
            }

            if (total > 94300 && total <= 201050)
            {
                decimal tax = total * Convert.ToDecimal(0.22);
                return tax;
            }

            if (total > 201050 && total <= 383900)
            {
                decimal tax = total * Convert.ToDecimal(0.24);
                return tax;
            }

            if (total > 383900 && total <= 487450)
            {
                decimal tax = total * Convert.ToDecimal(0.32);
                return tax;
            }

            if (total > 487450 && total <= 731200)
            {
                decimal tax = total * Convert.ToDecimal(0.35);
                return tax;
            }

            if (total > 731200)
            {
                decimal tax = total * Convert.ToDecimal(0.37);
                return tax;
            }
            return 0;
        }

        public decimal HOHRadioButton(decimal total)
        {
            if (total > 0 && total <= 16550)
            {
                decimal tax = total * Convert.ToDecimal(0.10);
                return tax;
            }

            if (total > 16550 && total <= 63100)
            {
                decimal tax = total * Convert.ToDecimal(0.12);
                return tax;
            }

            if (total > 63100 && total <= 100500)
            {
                decimal tax = total * Convert.ToDecimal(0.22);
                return tax;
            }

            if (total > 100500 && total <= 191950)
            {
                decimal tax = total * Convert.ToDecimal(0.24);
                return tax;
            }

            if (total > 191950 && total <= 243700)
            {
                decimal tax = total * Convert.ToDecimal(0.32);
                return tax;
            }

            if (total > 243700 && total <= 609350)
            {
                decimal tax = total * Convert.ToDecimal(0.35);
                return tax;
            }

            if (total > 609350)
            {
                decimal tax = total * Convert.ToDecimal(0.37);
                return tax;
            }
            return 0;
        }

        public decimal utahStateTax(decimal total)
        {
            total = total * Convert.ToDecimal(0.0465);
            return total;
        }

        public decimal payFrequency(decimal input)
        {
            
            if (window.WeeklyRButton.IsChecked == true)
            {
                decimal total = input/52;
                return total;
            }

            if (window.BiWeeklyRButton.IsChecked == true)
            {
                decimal total = input/26;
                return total;
            }

            if (window.SemiMonthlyRButton.IsChecked == true)
            {
                decimal total = input / 24;
                return total;
            }

            if (window.MonthlyRButton.IsChecked == true)
            {
                decimal total = input / 12;
                return total;
            }

            if (window.AnnualRButton.IsChecked == true)
            {
                decimal total = input;
                return total;
            }
            return 0;
        }

        public int payFrequencyDivisor()
        {
            if (window.WeeklyRButton.IsChecked == true)
            {
                return 52;
            }

            if (window.BiWeeklyRButton.IsChecked == true)
            {
                return 26;
            }

            if (window.SemiMonthlyRButton.IsChecked == true)
            {
                return 24;
            }

            if (window.MonthlyRButton.IsChecked == true)
            {
                return 12;
            }

            if (window.AnnualRButton.IsChecked == true)
            {
                return 1;
            }
            return 0;
        }

        public void preTaxDeductions()
        {
            if (window.InsuranceTextbox.Text == "")
            {
                window.InsuranceTextbox.Text = (Convert.ToDecimal(0)).ToString("C");
            }
            else if (window.InsuranceTextbox.Text.Substring(0, 1) != "$")
            {
                window.InsuranceTextbox.Text = (Convert.ToDecimal(window.InsuranceTextbox.Text)).ToString("C");
            }

            if (window.RetirementTextbox.Text == "")
            {
                window.RetirementTextbox.Text = (Convert.ToDecimal(0)).ToString("C");
            }
            else if (window.RetirementTextbox.Text.Substring(0, 1) != "$")
            {
                window.RetirementTextbox.Text = (Convert.ToDecimal(window.RetirementTextbox.Text)).ToString("C");
            }

            if (window.HSAFSATextbox.Text == "")
            {
                window.HSAFSATextbox.Text = (Convert.ToDecimal(0)).ToString("C");
            }
            else if (window.HSAFSATextbox.Text.Substring(0, 1) != "$")
            {
                window.HSAFSATextbox.Text = (Convert.ToDecimal(window.HSAFSATextbox.Text)).ToString("C");
            }
        }

        public void preTaxandGrossHourly()
        {
            window.PreTaxTextbox.Text = (Convert.ToDecimal((window.InsuranceTextbox.Text).Substring(1)) + Convert.ToDecimal((window.RetirementTextbox.Text).Substring(1)) + Convert.ToDecimal((window.HSAFSATextbox.Text).Substring(1))).ToString("C");
            window.GrossPayTextbox.Text = ((Convert.ToDecimal(window.HourlyWageTextbox.Text) * Convert.ToDecimal(window.HoursPerPeriodTextbox.Text)) + (Convert.ToDecimal(window.HourlyWageTextbox.Text) * Convert.ToDecimal(1.5) * Convert.ToDecimal(window.OTHoursPerPayPeriod.Text))).ToString("C");
        }

        public void preTaxandGrossSalary()
        {
            window.PreTaxTextbox.Text = (Convert.ToDecimal((window.InsuranceTextbox.Text).Substring(1)) + Convert.ToDecimal((window.RetirementTextbox.Text).Substring(1)) + Convert.ToDecimal((window.HSAFSATextbox.Text).Substring(1))).ToString("C");
            window.GrossPayTextbox.Text = (Convert.ToDecimal(window.HourlyWageTextbox.Text) / payFrequencyDivisor()).ToString("C");
        }
    }
}
