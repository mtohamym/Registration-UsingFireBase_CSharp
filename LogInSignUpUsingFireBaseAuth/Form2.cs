using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;


namespace LogInSignUpUsingFireBaseAuth
{
    public partial class Form2 : Form
    {


        public Form2()
        {
            InitializeComponent();
        }
        #region FireBase Config Def // here my BasePath to My real Time DataBase.
        IFirebaseConfig FBC = new FirebaseConfig()
        {
            AuthSecret = "1mlEgWo9bcQRhbViEvYl1IbQmwrTkFYfHEVLsfGw",
            BasePath = "https://signintotrack.firebaseio.com/",
        };
        #endregion 
        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        IFirebaseClient firebase;

        private void Form2_Load(object sender, EventArgs e)
        {

            try
            {
                firebase = new FireSharp.FirebaseClient(FBC);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No Internet Connection ", "Error");

            }


        }

        private void BunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SignUpbtn_Click(object sender, EventArgs e)
        {
            #region Conditions to Check Text Boxes Not Null 
            if (String.IsNullOrEmpty(tbFName.Text) &&
               String.IsNullOrEmpty(tbLName.Text) &&
               String.IsNullOrEmpty(tbEmail.Text) &&
               String.IsNullOrEmpty(tbConfirmPass.Text) &&
               String.IsNullOrEmpty(tbPasswordSignUp.Text) ||
               !tbConfirmPass.Text.Equals(tbPasswordSignUp.Text))
            {
                MessageBox.Show("Fill all data or passord not correct", "Error");
            } else
            {
                //Use UserModel to Store data to set this values to firebase.
                UserModel user = new UserModel(tbFName.Text, tbLName.Text,
                tbPasswordSignUp.Text, tbEmail.Text);

             //this path to set data to user.
            // EX : USERS -- > *FullName* --> *ALL Data About User*.
            SetResponse response = firebase.Set(@"Users/" + user.Email, user);

            MessageBox.Show("Sign Up Successfully", "Done");
                Home home = new Home();
                home.ShowDialog();
                this.Hide();


                
            }
            #endregion
           
           



        }

        private void TbFName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
