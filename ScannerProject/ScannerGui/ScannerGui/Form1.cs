using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Scanner
{
   
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }


            string code;
            Scanner scanner = new Scanner();
            List<Token> tokens = new List<Token>();

            private void textBox1_TextChanged(object sender, EventArgs e)
            {
            
            }


        
            private void UpdateTable()
            {

                code = codeLinesTextBox.Text;
                tokens = scanner.getListOfTokens(code);

                foreach (Token token in tokens)
                {
                    DataGridView.Rows.Add(token.TokenType, token.tokenValue);
              
                }

            }

        private void ScanButton_Click(object sender, EventArgs e)
        {

          

            UpdateTable();
            if (scanner.bracesMismatchErrorCheck() == 1)
            {
                MessageBox.Show("Error UnMatched Braces", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (scanner.bracketsMismatchErrorCheck() == 1)
            {
                MessageBox.Show("Error UnMatched Brackets", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (scanner.quotationsMismatchErrorCheck() == 1)
            {
                MessageBox.Show("Error UnMatched Quotations", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if (scanner.isIllegal() == 1)
            {
                MessageBox.Show("Illegal Characters are entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (scanner.isNumberError() == 1)
            {
                MessageBox.Show("You cannot type a Number with a digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }


    }


   
