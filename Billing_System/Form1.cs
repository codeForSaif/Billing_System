using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System
{
    public partial class Form1 : Form
    {
        Double firstnum;
        Double secondnum;
        Double answer;
        String operation;

        Double mcSubTotal;
        Double mcTotal;
        Double cCARPET_PRICE = 2.4;
        Double cFABRIC_PRICE = 3.3;
        Double cBLINDS_PRICE = 4.6;
        Double cDELIVERY_PRICE = 2.10;
        Double cMILAGE_PRICE = 2.3;
        Double mcTAX_RATE = 0.25;

        Double cPrice;
        Double ItemPrice;
        Double ItemCost;
        Double ItemLengthC;
        Double ItemLengthF;
        Double ItemLengthB;
        Double ItemDelivery;
        Double ItemMilage;
        Double AmountCostC;
        Double AmountCostF;
        Double AmountCostB;
        Double AmountCostT;

        Double iDelivery;
        Double TotalMilage;
        Double cTax;
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (labelClac.Text == "0")
                labelClac.Text = num.Text;
            else
                labelClac.Text = (labelClac.Text + num.Text);
        }

        private void Arithmetic_Function(object sender, EventArgs e)
        {
            Button ops = (Button)sender;
            firstnum = Double.Parse(labelClac.Text);
            labelClac.Text = "";
            operation = ops.Text;
            labelCalc2.Text = System.Convert.ToString(firstnum) + " " + operation;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            secondnum = Double.Parse(labelClac.Text);
            labelCalc2.Text = "";
            switch (operation)
            {
                case "+":
                    answer = (firstnum + secondnum);
                    labelClac.Text = System.Convert.ToString(answer);
                    break;
                case "-":
                    answer = (firstnum - secondnum);
                    labelClac.Text = System.Convert.ToString(answer);
                    break;
                case "*":
                    answer = (firstnum * secondnum);
                    labelClac.Text = System.Convert.ToString(answer);
                    break;
                case "/":
                    if (secondnum != 0)
                    {
                        answer = (firstnum / secondnum);
                        labelClac.Text = System.Convert.ToString(answer);
                        break;
                    }
                    else
                        break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (labelClac.Text.Length > 0)
                labelClac.Text = labelClac.Text.Remove(labelClac.Text.Length - 1, 1);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelClac.Text = "0";
            labelCalc2.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if(num.Text==".")
            {
                if (!labelClac.Text.Contains("."))
                    labelClac.Text = labelClac.Text + num.Text;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxCarpet.Text = "";
            textBoxFabric.Text = "";
            textBoxHomeDelivery.Text = "";
            textBoxMilage.Text = "";
            textBoxBlinds.Text = "";

            lblCDelivery.Text = "";
            lblCItems.Text = "";
            lblCMileage.Text = "";
            lblSubTotal.Text = "";
            lblTax.Text = "";
            lblTotalAmnt.Text = "";

            checkBoxTax.Checked = false;
            checkBoxBlinds.Checked = false;
            checkBoxFabric.Checked = false;
            checkBoxCarpet.Checked = false;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (checkBoxCarpet.Checked == true)
            {
                cPrice = cCARPET_PRICE;
            }
            if(checkBoxBlinds.Checked == true)
            {
                ItemPrice = cBLINDS_PRICE;
            } 
            if(checkBoxFabric.Checked == true)
            {
                ItemCost = cFABRIC_PRICE;
            }
            int isNumeric;

            if(int.TryParse(textBoxCarpet.Text, out isNumeric))
            {
                ItemLengthC = System.Convert.ToInt32(textBoxCarpet.Text);
                AmountCostF = cPrice * ItemLengthC;
                AmountCostC = AmountCostB + AmountCostF + AmountCostT;
            }
            if(int.TryParse(textBoxBlinds.Text,out isNumeric))
            {
                ItemLengthB = System.Convert.ToInt32(textBoxBlinds.Text);
                AmountCostB = ItemPrice * ItemLengthB;
                AmountCostC = AmountCostB + AmountCostF + AmountCostT; 
            }
            if(int.TryParse(textBoxFabric.Text, out isNumeric))
            {
                ItemLengthF = System.Convert.ToInt32(textBoxFabric.Text);
                AmountCostF = ItemCost * ItemLengthF;
                AmountCostC = AmountCostB + AmountCostF + AmountCostT;
            }
            if(checkBoxBlinds.Checked==true || checkBoxCarpet.Checked == true || checkBoxFabric.Checked== true)
            { }
            else
            {
                MessageBox.Show("Select any of the items");
            }
            if(int.TryParse(textBoxHomeDelivery.Text, out isNumeric))
            {
                ItemDelivery = System.Convert.ToInt32(textBoxHomeDelivery.Text);
                iDelivery = cDELIVERY_PRICE * ItemDelivery;
            }
            else
            {
                MessageBox.Show("Please enter required hours of labour");
                textBoxHomeDelivery.Focus();
            }
            if (int.TryParse(textBoxMilage.Text, out isNumeric))
            {
                ItemMilage = System.Convert.ToInt32(textBoxMilage.Text);
                TotalMilage = cMILAGE_PRICE*ItemMilage;
            }
            else
            {
                MessageBox.Show("Please enter required miles of travel");
                textBoxMilage.Focus();
            }
            if(checkBoxTax.Checked)
            {
                cTax = (((AmountCostC * mcTAX_RATE)));
            }
            mcSubTotal = AmountCostC + iDelivery + TotalMilage;
            mcTotal = mcSubTotal + cTax;

            lblCItems.Text = String.Format("{0:C}", Convert.ToInt32(AmountCostC + cTax));
            lblCDelivery.Text = String.Format("{0:C}", Convert.ToInt32(iDelivery));
            lblCMileage.Text = String.Format("{0:C}", Convert.ToInt32(TotalMilage));
            lblSubTotal.Text = String.Format("{0:C}", Convert.ToInt32(mcSubTotal));
            lblTax.Text = String.Format("{0:C}", Convert.ToInt32(cTax));
            lblTotalAmnt.Text = String.Format("{0:C}", Convert.ToInt32(mcTotal));

            DateTime SaveTime = DateTime.Now;

            textBoxReciept.Text = "";

            textBoxReciept.AppendText(" " + Environment.NewLine);
            textBoxReciept.AppendText("                BILLING SYSTEM" + Environment.NewLine);
            textBoxReciept.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = =" + Environment.NewLine);
            textBoxReciept.AppendText("Welcome to abc services : The best there is "+Environment.NewLine);
            textBoxReciept.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = ="+ Environment.NewLine);
            textBoxReciept.AppendText(" "+Environment.NewLine);

            textBoxReciept.AppendText(" " + Environment.NewLine);
            textBoxReciept.AppendText(" "+"Sub total:"+lblSubTotal.Text + Environment.NewLine);
            textBoxReciept.AppendText(" "+"Tax:"+lblTax.Text + Environment.NewLine);
            textBoxReciept.AppendText(" " + "Total:" + lblTotalAmnt.Text + Environment.NewLine);
            textBoxReciept.AppendText(" " + Environment.NewLine);
            textBoxReciept.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = =" + Environment.NewLine);

            textBoxReciept.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = =" + Environment.NewLine);
            textBoxReciept.AppendText(" " + Environment.NewLine);
            textBoxReciept.AppendText("            "+SaveTime+Environment.NewLine);
            textBoxReciept.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = =" + Environment.NewLine);
            textBoxReciept.AppendText("             THANKS FOR SHOPPING" + Environment.NewLine);
            textBoxReciept.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = =" + Environment.NewLine);
           
        }

        
    }
}
