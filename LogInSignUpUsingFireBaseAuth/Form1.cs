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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        #region FireBase Config Def // here my BasePath to My real Time DataBase.
        IFirebaseConfig Fbc = new FirebaseConfig()
        {
            AuthSecret = "1mlEgWo9bcQRhbViEvYl1IbQmwrTkFYfHEVLsfGw",
            BasePath = "https://signintotrack.firebaseio.com/",
        };
        #endregion
        IFirebaseClient Firebase;
        private void TbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            #region Conditions to Check Text Boxes Not Null 
            if (String.IsNullOrEmpty(tbUserName.Text) &&
               String.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Fill all data !!", "Error");
            }
            else
            {
              
                //this path to get data to user.
                // EX : USERS -- > *Email* --> *ALL Data About User*.
                FirebaseResponse response = Firebase.Get(@"Users/" + tbUserName.Text);
                UserModel UserFromFireBase = response.ResultAs<UserModel>();
                String Message = "Login Successfully";
                UserModel user = new UserModel(tbPassword.Text,tbUserName.Text);
                
                if (validating(user, UserFromFireBase, Message) == true)
                {
                    MessageBox.Show(Message, "Message");
                    WebSite webForm = new WebSite();
                   
                    webForm.ShowDialog();
                    this.Hide();
                    
                }

               
            }
            #endregion
        }

        private static Boolean validating(UserModel User , UserModel UserFromFireBase ,String Message)
        {
            if(User == null || UserFromFireBase == null)
            {
              
                return false;
            }
            if (User.FirstName != UserFromFireBase.FirstName)
            {
                MessageBox.Show("User Not Found");
                return false;
            } else if (User.Password!=UserFromFireBase.Password)
            {
                MessageBox.Show("Wrong Password");
                return false;
            }

            return true;
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            Form2 SignUp = new Form2();
            SignUp.Show();
            this.Hide();

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

 
        private void Home_Load(object sender, EventArgs e)
        {
            try
            {
                Firebase = new FireSharp.FirebaseClient(Fbc);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No Internet Connection ", "Error");

            }
        }
    }
}
