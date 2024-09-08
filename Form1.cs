using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InsuranceApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private class RegisterInsurancePolicy
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string ID { get; set; }
            public RadioButton Gender { get; set; }
            public string PhoneNumber { get; set; }

            private int Price;

            public RegisterInsurancePolicy(string firstName, string lastName, DateTime dateOfBirth, string id, RadioButton gender, string phoneNumber, int price)
            {
                FirstName = firstName;
                LastName = lastName;
                DateOfBirth = dateOfBirth;
                ID = id;
                Gender = gender;
                PhoneNumber = phoneNumber;
                Price = price;
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = tb_firstName.Text;
                string lastName = tb_lastName.Text;
                DateTime dateOfBirth = DateTime.Parse(dt_dateOfBirth.Text);
                string id = tb_id.Text;
                RadioButton gender = rbtn_male.Checked ? rbtn_male : rbtn_female;
                string phoneNumber = tb_phoneNumber.Text;
                int age = DateTime.Now.Year - dateOfBirth.Year;
                int price = 4000;

                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                {
                    MessageBox.Show("First name or last name is empty.");
                }
                else if (id.ToString().Length != 13)
                {
                    MessageBox.Show("ID should only contain 13 characters");
                }
                else if (phoneNumber.ToString().Length != 10)
                {
                    MessageBox.Show("Phone Number should only contain 10 digits only");
                }
                else if (age < 18)
                {
                    MessageBox.Show("You must be at least 18 years old.");
                }
                else if (!rbtn_male.Checked && !rbtn_female.Checked)
                {
                    MessageBox.Show("Please select a gender.");
                }
                else
                {
                    if (cb_doYouSmoke.SelectedItem != null && cb_doYouSmoke.SelectedItem.ToString() == "Yes")
                    {
                        price += 1000;
                    }
                    if(cb_doYouExercise.SelectedItem != null && cb_doYouExercise.SelectedItem.ToString() == "Yes")
                    {
                        price -= 500;
                    } 
                    if (cb_doYouPlaySport.SelectedItem != null && cb_doYouPlaySport.SelectedItem.ToString() == "Yes")
                    {
                        price += 500;
                    }

                    MessageBox.Show($"{firstName} {lastName}, Your insurance price\n\a " +
                        $"Sums up to \n\a" +
                        $"R {price}");

                    RegisterInsurancePolicy policy = new RegisterInsurancePolicy(firstName, lastName, dateOfBirth, id, gender, phoneNumber, price);
                }
            }
            catch
            {
                MessageBox.Show("Please complete the form...");
            }
            







            

            
        }
    }
}

