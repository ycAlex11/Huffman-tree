using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Collections;

namespace Asgn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtFreqTbl_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }

        private void txtCompressed_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        private void btnCompress_Click(object sender, RoutedEventArgs e)
        {
            /*the user should type sth in the plain text*/
            if (txtPlain.Text == "" && txtFreqTbl.Text == "" || txtPlain.Text == "")
            {
                MessageBox.Show("Please type something in the plain text ");
            }

            else if (txtFreqTbl.Text == "")
            {
                MessageBox.Show("Please click the Freq calc button first ");
            }
            else
            /*start parse the input*/
            {
                int value;
                /*get the input if the user input sth form the symbol table*/
                string inFreqTbl = txtFreqTbl.Text;
                var inDict = new Dictionary<char, int>();
                /*remove the whitesaper at the start or end*/
                string theFreqTbl = inFreqTbl.Trim();
                bool formatError = false;
               
                /*Loops for each new line in the symbol table box*/
                foreach (string aLine in theFreqTbl.Split('\n'))
                {
                    /*use the ":" to spilt every string*/
                    string[] a = aLine.Split(':');

                    char[] key = a[0].ToCharArray();
                   
                   /*when some incorrect type in the symbol table then show the message to user  */
                    try
                    {
                            if (key[0] == '\\')
                            {
                                key[0] = '\n';
                            }
                            int.TryParse(a[1], out value);
                            /*when the use type something in the symbol table should type a positive number and the format like a:5*/
                            double sqrt = Math.Sqrt(value);

                            if (sqrt.Equals(Double.NaN) || !int.TryParse(a[1], out value))
                                {
                                    throw (new Exception("Negative frequency "));
                                }

                            /*can not input duplicate key  */
                              inDict.Add(key[0], value);
                           
                      }
  
                    catch
                    {
                        MessageBox.Show("Incorrect input,can not type negative frequency or duplicate character, the format should like 'char:int'");
                        formatError = true;
                    }

                }


                if (!formatError)
                {
                    HuffmanTree tree = new HuffmanTree(inDict);


                    IDictionary<char, string> encodings = tree.CreateEncodings();

                    /* converts the characters in plain text to an array*/
                    char[] txtplain = txtPlain.Text.ToCharArray();

                    string huffstring = "";

                    string wrongSymbol = "";

                    bool error = false;

                    /*loop all the char in plaintext convert into its huffman code*/
                    foreach (char pChar in txtplain)
                    {
                        /*  Check the char in plaintext as a key in the huffman dictionary*/
                        bool correctkey = false;
                        if (encodings.ContainsKey(pChar))
                        {
                            correctkey = true;
                        }
                        else
                        /*//  the character does not have huffman code*/
                        {
                            error = true;
                            wrongSymbol += pChar + " ";
                        }
                        if (correctkey)
                        { 
                            huffstring += encodings[pChar];
                        }
                        

                    }
                    if (error)
                    {
                        MessageBox.Show(wrongSymbol + " can not compress this character, please try another one");
                    }


                    DAABitArray newBitArray = new DAABitArray();
                    int huffInt;

                    /*loops all bits in the huffstring to single ints that can add to the DAABitArray*/
                    foreach (char huffchar in huffstring)
                    {
                        huffInt = (int)Char.GetNumericValue(huffchar);
                        newBitArray.Append(huffInt);
                    }
                    /* Call the textInterpretation and output the result on compressed text*/
                    TextInterpretation newTextInter = new TextInterpretation();

                    txtCompressed.Text = newTextInter.Interpertation(newBitArray);



                }
            }
            
        }
        /*calcute the frequency for the characters */
        private void btnFreq_Click(object sender, RoutedEventArgs e)
        {
             /*tell the user has to type sth in the plain text*/
            if (txtPlain.Text == ""  )
            {
                MessageBox.Show("need type sth in the plain text");
            }
            else
            {
                var dict = new Dictionary<char, int>();
                string inText = txtPlain.Text;
                /*for each char adding new symbols to the dictionary*/
                /* If it is new symbol, value = 1, otherwise increase current value*/
               
                foreach (char c in inText)
                {
                    if (c != '\r')
                    /*plus 1 when the character appears once*/
                    {
                        if (dict.ContainsKey(c))
                            dict[c]++;
                        else
                            dict[c] = 1;
                    }
                }
                string output = "";
                /*out put the result to the UI,if just type enter that shows enter as '\n'*/
                foreach (var symbol in dict)
                {
                    if (symbol.Key == '\n')
                    {
                        output += "\\n" + ":" + symbol.Value + "\n";
 
                    }
                    else
                    {   /*i dont know why if  output +=+ symbol.Key + ":" + symbol.Value + "\n";then show the ASCII of the character   */
                        output += symbol.Key + ":" + symbol.Value + "\n";
                    }
                }
                txtFreqTbl.Text = output;
            
        
        }
        
        


            }

        private void btnDecompress_Click(object sender, RoutedEventArgs e)
        {
            
        }
        

        private void txtPlain_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
   
        
        
       
        
    }
}
