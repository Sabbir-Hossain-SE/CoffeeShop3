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
    struct Invoice
    {
        public string name;
        public string contact;
        public string address;
        public string orderItem;
        public int quantity;
        public int totalPrice;
        public int unitPrice;
    };
    public partial class CoffeeShop : Form
    {
        Invoice[] cusInvoice = new Invoice[100];
        string[] name_arr = new string[100];
        string[] contact_arr = new string[100];
        string[] address_arr = new string[100];
        string[] orderItem_arr = new string[100];
        int[] quantity_arr = new int[100];
        int[] totalPrice_arr = new int[100];
        int[] unitPrice_arr = new int[100];

        int index=0;
        
        public CoffeeShop()
        {
            InitializeComponent();
        }

        private void CoffeeShop_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] age = new int[10];
            string[] name1 = new string[] { "Ali", "Asif", "Kamal" };

            string name = cusNameTextBox.Text, contact = contactTextBox.Text, address = addressTextBox.Text, order = orderComboBox.Text, quantity1 = quantityTextBox.Text;
            int quantity =0, hotP = 90, regularP = 80, blackP = 120, coldP = 100, price;
            bool flagQuantity = Regex.IsMatch(quantity1, "[0-9]{1,}$"), flagContact = Regex.IsMatch(contact, "[0-9]{11,11}$"),pivCon=true,pivQuan=true;
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


                if (order.Equals("Black"))
                {
                    price = blackP * quantity;
                    cusInvoice[index].unitPrice = blackP;
                    unitPrice_arr[index] = blackP;
                }
                else if (order.Equals("Cold"))
                {
                    price = coldP * quantity;
                    cusInvoice[index].unitPrice = coldP;
                    unitPrice_arr[index] = coldP;

                }
                else if (order.Equals("Hot"))
                {
                    price = hotP * quantity;
                    cusInvoice[index].unitPrice = hotP;
                    unitPrice_arr[index] = hotP;

                }
                else
                {
                    price = regularP * quantity;
                    cusInvoice[index].unitPrice = regularP;
                    unitPrice_arr[index] = regularP;
                }
                cusInvoice[index].name = name;
                cusInvoice[index].contact = contact;
                cusInvoice[index].address = address;
                cusInvoice[index].orderItem = order;
                cusInvoice[index].quantity = quantity;
                cusInvoice[index].totalPrice = price;

                name_arr[index] = name;
                contact_arr[index] = contact;
                address_arr[index] = address;
                orderItem_arr[index] = order;
                quantity_arr[index] = quantity;
                totalPrice_arr[index] = price;

                //invoiceRichBox.Text += "\n\n\n\n\n  Name\t\t: " + cusInvoice[index].name + "\n  Contact Number  : " + cusInvoice[index].contact + "\n  Address\t\t: " + cusInvoice[index].address + "\n  Order Item\t   :\t" + cusInvoice[index].orderItem + "\n  Quantity\t\t:\t" + cusInvoice[index].quantity + "\n  Total Price  (" + cusInvoice[index].quantity + "*" + cusInvoice[index].unitPrice + "):\t\t" + cusInvoice[index].totalPrice;
                invoiceRichBox.Text += "\n\n\n\n\n  Name : " + name_arr[index] + "\n  Contact Number : " + contact_arr[index] + "\n  Address : " + address_arr[index] + "\n  Order Item : " + orderItem_arr[index] + "\n  Quantity : " + quantity_arr[index] + "\n  Total Price  (" + quantity_arr[index] + "*" + unitPrice_arr[index] + ") : " + totalPrice_arr[index];

                index++;
                cusNameTextBox.Text = contactTextBox.Text = addressTextBox.Text = orderComboBox.Text = quantityTextBox.Text = "";
            }
           
        }


    }
}



 