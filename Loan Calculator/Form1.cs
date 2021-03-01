using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loan_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double LoanAmount = Double.Parse(txtLoanAmount.Text,
                           System.Globalization.NumberStyles.AllowCurrencySymbol | System.Globalization.NumberStyles.Number);
            double InterestRate = Convert.ToDouble(new String(txtInterestRate.Text.Where(Char.IsDigit).ToArray()));
            double LoanTerm = Convert.ToDouble(new String(txtLoanTerm.Text.Where(Char.IsDigit).ToArray())); 

            double months = LoanTerm * 12;
            double interestRatePerMonth = InterestRate / 100 / 12;

            double exponentiation = Math.Pow((1+ interestRatePerMonth), months);

            double monthlyPayment = Math.Round((LoanAmount * (interestRatePerMonth * exponentiation) / (exponentiation - 1)),2);

            double totalAmountOfPayments = Math.Round(Convert.ToDouble(monthlyPayment * months),3);
            double TotalAmountOfInterest = Math.Round(totalAmountOfPayments - LoanAmount,4);

            txtLoanAmount.Text = LoanAmount.ToString("c");
            txtInterestRate.Text = InterestRate.ToString() + "%"; ;
            txtLoanTerm.Text = LoanTerm.ToString() + " years";
            txtMonthlyPayment.Text = monthlyPayment.ToString("c");
            txtTotalAmountOfInterest.Text = TotalAmountOfInterest.ToString("c");
            txtTotalAmountOfPayments.Text = totalAmountOfPayments.ToString("c");

            txtLoanAmount.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLoanAmount.Text = "";
            txtInterestRate.Text = "";
            txtLoanTerm.Text = "";
            txtMonthlyPayment.Text = "";
            txtTotalAmountOfInterest.Text = "";
            txtTotalAmountOfPayments.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
       
    }
}
