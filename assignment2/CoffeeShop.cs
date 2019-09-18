using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace assignment2
{

    public partial class CoffeeShop : Form
    {
        string fullMeggage;
        List<string> contacts = new List<string> { };
        List<string> customerInformations = new List<string> { };


        public CoffeeShop()
        {
            InitializeComponent();
        }

        private void CoffeeShop_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
          
            string name = cusNameTextBox.Text, contact = contactTextBox.Text, address = addressTextBox.Text, order = orderComboBox.Text, quantity1 = quantityTextBox.Text;
            int quantity =0, hotP = 90, regularP = 80, blackP = 120, coldP = 100, price,productPrice;
            bool flagQuantity = Regex.IsMatch(quantity1, "[0-9]{1,}$"), flagContact = Regex.IsMatch(contact, "[0-9]{11,11}$");
            if (name.Length==0|| contact.Length==0|| address.Length == 0 || order.Length == 0 || quantity1.Length == 0|| flagQuantity==false|| flagContact==false)
            {
                if (name.Length == 0)
                {
                    alertName.Text = "*Please input the name field.";
                }
                else
                {
                    alertName.Text = "";
                }
                if (contact.Length == 0)
                {
                    alertContact.Text = "*Please input the contact field, use number only.";

                }
                else
                {
                    if (flagContact == false && contact.Length != 0)
                    {
                        alertContact.Text = "*Input incorrect syntax, use number only & use just 11 digits.";
                       
                    }
                    else 
                    {
                        alertContact.Text = "";
                    }
                }

                if (address.Length == 0)
                {
                    alertAddress.Text = "*Please input the address field.";
                }
                else
                {
                    alertAddress.Text = "";
                }
                if (order.Length == 0)
                {
                    alertOrder.Text = "*Please input the name field";
                }
                else
                {
                    alertOrder.Text = "";
                }

                if (quantity1.Length == 0)
                {
                    alertQuantity.Text = "*Please input the Quantity field, use number only.";
                }
                else
                {
                    alertQuantity.Text = "";
                    if (flagQuantity == false && quantity1.Length != 0)
                    {
                        alertQuantity.Text = "*Input incorrect syntax, use number only.";
                    }
                    else
                    {
                        alertQuantity.Text = "";
                    }
                }
           
            }

            else
            {
                quantity = Convert.ToInt32(quantity1);

                alertName.Text = alertContact.Text = alertAddress.Text = alertOrder.Text = alertQuantity.Text = "";
                if (order.Equals("Black"))
                {
                    price = blackP * quantity;
                    productPrice = blackP;
                }
                else if (order.Equals("Cold"))
                {
                    price = coldP * quantity;
                    productPrice = coldP;

                }
                else if (order.Equals("Hot"))
                {
                    price = hotP * quantity;
                    productPrice = hotP;

                }
                else
                {
                    price = regularP * quantity;
                    productPrice = regularP;
                }

                contacts.Add(contact);
                string allInfo= "\n\n\n\n  Name : " + name + "\n  Contact Number : " + contact + "\n  Address : " + address + "\n  Order Item : " + order + "\n  Quantity : " + quantity + "\n  Total Price  (" + quantity + "*" + productPrice + ") : " + price;

                customerInformations.Add(allInfo);
                invoiceRichBox.Text =allInfo;

           
                cusNameTextBox.Text = contactTextBox.Text = addressTextBox.Text = orderComboBox.Text = quantityTextBox.Text = "";
            }
           
        }

        private void contactTextBox_TextChanged(object sender, EventArgs e)
        {
            int pivot=0;
            bool flagContact1 = Regex.IsMatch(contactTextBox.Text, "[0-9]{11,11}$");
            if (flagContact1)
            {
                foreach(string contact in contacts)
                {
                    if (contact.Equals(contactTextBox.Text))
                    {
                        pivot = 1;
                    }
                }
                if (pivot == 1)
                {
                    alertContact.Text = "*Invalid number! This number has already used.\nPlease try again with unique one.";
                    return;
                }
                else
                {
                    alertContact.Text = "";
                    return;
                }

            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            fullMeggage = "";
            foreach( string customerInformation in customerInformations)
            {
                fullMeggage  += customerInformation;
            }
            invoiceRichBox.Text = fullMeggage;
        }

    }
}



 