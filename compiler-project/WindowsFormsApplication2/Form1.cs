using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        List<KeyValuePair<string, String>> arr = new List<KeyValuePair<string, String>>();
        public Form1()
        {
            InitializeComponent();
           textBox1.AppendText("$$$enter code here:");
           textBox1.AppendText(Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Scanner sc = new Scanner(textBox1.Text);
            var list = sc.getToken();
           
                foreach (var element in list)
                {
          
                 if (element.Value == Scanner.TokenType.Error) {
                    textBox2.AppendText(" Error in Token Text :" + element.Key);
                    textBox2.AppendText(Environment.NewLine);

                }
                else {
                    textBox2.AppendText(" Token Text : " + element.Key + " Token Type: " + element.Value.ToString());
                    textBox2.AppendText(Environment.NewLine);
                }
                       
                }
            textBox2.AppendText("--------------------------------------------------");
            textBox2.AppendText(Environment.NewLine);
            textBox2.AppendText("Total Number Of Errors : "+sc.numberOfErrors);
            textBox2.AppendText(Environment.NewLine);







        }

        class Scanner
        {
            private string CodeStr;
            public int numberOfErrors;
            public Scanner(string s)
            {
                CodeStr = s;
                numberOfErrors = 0;
                
            }
     
            private bool isLetter(char c) {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c == '_'))
                    return true;
                else
                    return false;
            }
            private bool isDigit(char c) {
                if (c >= '0' && c <= '9')
                    return true;
                else
                    return false;
            }
            private bool isSpecial(char c) {
                if (c == '+' || c == '-' || c == '/' || c == '*' || c == '&' || c == '|' || c == '~' || c == '=' || c == '>' || c == '<' || c == '!' || c == '(' || c == ')'
                    || c == '{' || c == '}' || c == '"' || c == '\'')
                    return true;
                else
                    return false;
            }
        
            //103,45
            int[,] table ={
               // {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46},
                //q0
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                //q1={0,2,8,9,14,17,19,25,26,....}
                {10,0,38,0,0,0,0,0,2,21,0,0,0,0,52,0,0,42,0,61,0,0,0,0,0,69,70,71,72,78,80,82,92,94,96,98,75,74,76,77,100,84,83,85,88,101},
                //q2={0,16}
                {3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                //q3={6}
                {0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                //q4={7}
                {0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                //q5
                {0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                //q6
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                //q7
                {0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                //q8
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                //q9
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                //q10
                 {0,17,0,0,0,0,18,0,0,0,0,0,0,11,0,0,28,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 //q11
                  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,12,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                  //q12
                  {0,0,0,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                  //q13
                   {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                   //q14
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    //q15
                     {0,0,0,0,0,16,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                     //q16
                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                      //q17
                       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                       //q18
                       {0,0,0,0,0,0,0,19,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                       //q19
                       {0,20,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                       //q20
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        //q21
                        {0,0,0,0,0,0,0,0,0,0,22,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        //q22
                        {0,0,0,26,0,0,0,0,0,0,0,23,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        //q23
                        {0,0,0,0,0,0,0,0,0,0,0,0,24,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        //q24
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,25,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        //q25
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        //q26
                        {0,0,0,0,0,0,27,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        //q27
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        //q28
                        {0,0,0,0,0,29,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        //q29
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,30,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        //q30
                        {0,0,0,0,0,0,0,0,0,0,0,31,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        //31-45
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,32,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,33,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,34,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,35,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,36,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,37,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,39,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,43,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,50,0,0,44,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,45,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,46,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //46-95
             {0,0,0,0,0,0,0,0,0,0,47,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,48,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,49,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,51,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,53,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,54,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,55,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,56,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,57,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,58,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,59,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,60,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,62,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,63,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,64,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,65,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,66,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,67,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,68,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,73,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,89,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,79,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,81,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,86,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,87,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,89,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,90,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,91,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,93,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,95,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //96-103
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,97,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,99,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,100,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,103,0,0,0,0,102},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,103,0,0,0,0,102},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,103,0,0,0,0,102}
            };
            public enum TokenType
            {
                Condetion,
                //dataType
                Integer, SInteger, Float, SFloat, Character, String, Void,
                Loop,
                Return,
                Break,
                Struct,
                ArithmeticOperation,
                Logicoperators,
                relationaloperators,
                Assignmentoperator,
                AccessOperator,
                Braces,
                //digits
                Constant,
                QuotationMark,
                Inclusion,
                Identifer,
                Comment,
                Error,
                EndOfFile,
                NULL,
                RESERVED_WORD
            };


            bool isDelimeter(char c) {
                if (c == ' ' || c == '\n' || c == '\t' || c == '\r' || c == ';')
                    return true;
                else
                    return false;
            }

            public List<KeyValuePair<string, TokenType>> getToken()
            {
                int current_State = 1;
                string current_Lex = "";
                TokenType current_Token = TokenType.NULL;
                int Lex_index = 0;
                var ListToPrint = new List<KeyValuePair<string, TokenType>>();
                bool save;

                       //   CodeStr = CodeStr.Replace(System.Environment.NewLine, "");
                while (Lex_index != CodeStr.Length)

                {
                    save = true;
                    switch (current_State)
                    {
                        case 1:

                            {
                                if (CodeStr[Lex_index] == 'I') current_State = table[current_State, 0];
                                else if (CodeStr[Lex_index] == 'E') current_State = table[current_State, 2];
                                else if (CodeStr[Lex_index] == 'S') current_State = table[current_State, 8];
                                else if (CodeStr[Lex_index] == 'C') current_State = table[current_State, 9];
                                else if (CodeStr[Lex_index] == 'W') current_State = table[current_State, 14];
                                else if (CodeStr[Lex_index] == 'L') current_State = table[current_State, 17];
                                else if (CodeStr[Lex_index] == 'T') current_State = table[current_State, 19];
                                else if (CodeStr[Lex_index] == '+') current_State = table[current_State, 25];
                                else if (CodeStr[Lex_index] == '-') current_State = table[current_State, 26];
                                else if (CodeStr[Lex_index] == '*') current_State = table[current_State, 27];
                                else if (CodeStr[Lex_index] == '/') { save = false; current_State = table[current_State, 28]; }
                                else if (CodeStr[Lex_index] == '&') current_State = table[current_State, 29];
                                else if (CodeStr[Lex_index] == '|') current_State = table[current_State, 30];
                                else if (CodeStr[Lex_index] == '~') current_State = table[current_State, 31];
                                else if (CodeStr[Lex_index] == '=') current_State = table[current_State, 32];
                                else if (CodeStr[Lex_index] == '>') current_State = table[current_State, 33];
                                else if (CodeStr[Lex_index] == '<') current_State = table[current_State, 34];
                                else if (CodeStr[Lex_index] == '!') current_State = table[current_State, 35];
                                else if (CodeStr[Lex_index] == '}') current_State = table[current_State, 36];
                                else if (CodeStr[Lex_index] == '{') current_State = table[current_State, 37];
                                else if (CodeStr[Lex_index] == '(') current_State = table[current_State, 38];
                                else if (CodeStr[Lex_index] == ')') current_State = table[current_State, 39];
                                else if (isDigit(CodeStr[Lex_index])) current_State = table[current_State, 40];
                                else if (CodeStr[Lex_index] == '\'') current_State = table[current_State, 41];
                                else if (CodeStr[Lex_index] == '"') current_State = table[current_State, 42];
                                else if (CodeStr[Lex_index] == '$') { save = false; current_State = table[current_State, 43]; }
                                else if (CodeStr[Lex_index] == '/') { save = false; current_State = table[current_State, 44]; }
                                else if (isLetter(CodeStr[Lex_index])) current_State = table[current_State, 45];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                { save = false; current_State = 1; }
                                else current_State = -1;
                                break;
                            }
                        case 2:
                            {
                                 
                                if (CodeStr[Lex_index] == 'I') current_State = table[current_State, 0];
                                else if (CodeStr[Lex_index] == 't') current_State = table[current_State, 16];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 3:
                            {
                                
                               if (CodeStr[Lex_index] == 'o') current_State = table[current_State, 6];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;

                            }

                        case 4:
                            {

                                if (CodeStr[Lex_index] == 'w') current_State = table[current_State, 7];
                                else if (isDelimeter(CodeStr[Lex_index])){
                                    current_State = 0; current_Token = TokenType.Identifer;
                                } else if( isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }


                        case 5:
                            {

                                if (CodeStr[Lex_index] == 'f') current_State = table[current_State, 1];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                { current_Token = TokenType.SInteger; current_State = 0; }
                                else if ((isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))) {
                                    current_State = 101; 
                                }
                                break;
                            }

                        case 6:
                            {
                                current_Token = TokenType.SFloat;
                                current_State = 0;
                                break;
                            }
                        case 7:
                            {
                                
                                if (CodeStr[Lex_index] == 'o') current_State = table[current_State, 6];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 8:
                            {
                                
                                 if (CodeStr[Lex_index] == 'p') current_State = table[current_State, 18];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 9:
                            {
                                current_Token = TokenType.Break;
                                current_State = 0;
                                break;
                            }

                        case 10:
                            {
                                
                                if (CodeStr[Lex_index] == 'f') current_State = table[current_State, 1];
                                else if (CodeStr[Lex_index] == 'o') current_State = table[current_State, 6];
                                else if (CodeStr[Lex_index] == 'n') current_State = table[current_State, 13];
                                else if (CodeStr[Lex_index] == 't') current_State = table[current_State, 16];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 11:
                            {
                                
                                if (CodeStr[Lex_index] == 'c') current_State = table[current_State, 22];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 12:
                            {
                               
                                 if (CodeStr[Lex_index] == 'l') current_State = table[current_State, 3];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 13:
                            {
                                
                                 if (CodeStr[Lex_index] == 'u') current_State = table[current_State, 20];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 14:
                            {
                               
                                 if (CodeStr[Lex_index] == 'd') current_State = table[current_State, 24];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 15:
                            {
                                
                                 if (CodeStr[Lex_index] == 'e') current_State = table[current_State, 5];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 16:
                            {
                                current_Token = TokenType.Inclusion;
                                current_State = 0;
                                break;
                            }
                        case 17:
                            {
                                current_Token = TokenType.Condetion;
                                current_State = 0;
                                break;
                            }
                        case 18:
                            {
                               
                                 if (CodeStr[Lex_index] == 'w') current_State = table[current_State, 7];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 19:
                            {
                                
                                 if (CodeStr[Lex_index] == 'f') current_State = table[current_State, 1];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }

                                break;
                            }
                        case 20:
                            {
                                current_Token = TokenType.Float;
                                current_State = 0;
                                break;
                            }
                        case 21:
                            {
                                
                                 if (CodeStr[Lex_index] == 'h') current_State = table[current_State, 10];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 22:
                            {
                               
                                if (CodeStr[Lex_index] == 'l') current_State = table[current_State, 3];
                                else if (CodeStr[Lex_index] == 'a') current_State = table[current_State, 11];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 23:
                            {
                                
                                 if (CodeStr[Lex_index] == 'i') current_State = table[current_State, 12];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 24:
                            {
                               
                                 if (CodeStr[Lex_index] == 'n') current_State = table[current_State, 13];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 25:
                            {
                                current_Token = TokenType.String;
                                current_State = 0;
                                break;
                            }
                        case 26:
                            {
                               
                                 if (CodeStr[Lex_index] == 'o') current_State = table[current_State, 6];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 27:
                            {
                                current_Token = TokenType.Character;
                                current_State = 0;
                                break;
                            }
                        case 28:
                            {
                               
                                 if (CodeStr[Lex_index] == 'e') current_State = table[current_State, 5];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 29:
                            {
                                
                                 if (CodeStr[Lex_index] == 'r') current_State = table[current_State, 15];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 30:
                            {
                             
                                 if (CodeStr[Lex_index] == 'a') current_State = table[current_State, 11];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 31:
                            {
                               
                                 if (CodeStr[Lex_index] == 't') current_State = table[current_State, 16];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 32:
                            {
                               
                                 if (CodeStr[Lex_index] == 'e') current_State = table[current_State, 5];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 33:
                            {
                               
                                 if (CodeStr[Lex_index] == 'w') current_State = table[current_State, 7];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 34:
                            {
                               
                                 if (CodeStr[Lex_index] == 'h') current_State = table[current_State, 10];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 35:
                            {
                               
                                 if (CodeStr[Lex_index] == 'e') current_State = table[current_State, 5];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 36:
                            {
                               
                                 if (CodeStr[Lex_index] == 'n') current_State = table[current_State, 13];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 37:
                            {
                                current_Token = TokenType.Loop;
                                current_State = 0;
                                break;
                            }
                        case 38:
                            {
                                
                                 if (CodeStr[Lex_index] == 'l') current_State = table[current_State, 3];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 39:
                            {
                               
                                 if (CodeStr[Lex_index] == 's') current_State = table[current_State, 4];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 40:
                            {
                               
                                 if (CodeStr[Lex_index] == 'e') current_State = table[current_State, 5];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 41:
                            {
                                current_Token = TokenType.Condetion;
                                current_State = 0;
                                break;
                            }
                        case 42:
                            {
                               
                                 if (CodeStr[Lex_index] == 'o') current_State = table[current_State, 6];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 43:
                            {
                                
                                 if (CodeStr[Lex_index] == 'l') current_State = table[current_State, 3];
                                else if (CodeStr[Lex_index] == 'o') current_State = table[current_State, 6];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 44:
                            {
                             
                                 if (CodeStr[Lex_index] == 'p') current_State = table[current_State, 18];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 45:
                            {
                                
                                 if (CodeStr[Lex_index] == 'w') current_State = table[current_State, 7];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 46:
                            {
                           
                                 if (CodeStr[Lex_index] == 'h') current_State = table[current_State, 10];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }

                        case 47:
                            {
                               
                                 if (CodeStr[Lex_index] == 'e') current_State = table[current_State, 5];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 48:
                            {
                            
                                 if (CodeStr[Lex_index] == 'n') current_State = table[current_State, 13];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 49:
                            {
                                current_Token = TokenType.Loop;
                                current_State = 0;
                                break;
                            }
                        case 50:
                            {
                             
                                 if (CodeStr[Lex_index] == 'i') current_State = table[current_State, 12];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 51:
                            {
                                current_Token = TokenType.Struct;
                                current_State = 0;
                                break;
                            }
                        case 52:
                            {
                              
                                 if (CodeStr[Lex_index] == 'o') current_State = table[current_State, 6];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 53:
                            {
                              
                                 if (CodeStr[Lex_index] == 'r') current_State = table[current_State, 15];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 54:
                            {
                             
                                 if (CodeStr[Lex_index] == 't') current_State = table[current_State, 16];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 55:
                            {
                              
                                 if (CodeStr[Lex_index] == 'h') current_State = table[current_State, 10];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 56:
                            {
                               
                                 if (CodeStr[Lex_index] == 'l') current_State = table[current_State, 3];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }

                        case 57:
                            {
                               
                                 if (CodeStr[Lex_index] == 'e') current_State = table[current_State, 5];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 58:
                            {
                               
                                 if (CodeStr[Lex_index] == 's') current_State = table[current_State, 4];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 59:
                            {
                             
                                 if (CodeStr[Lex_index] == 's') current_State = table[current_State, 4];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 60:
                            {
                                current_Token = TokenType.Void;
                                current_State = 0;
                                break;
                            }

                        case 61:
                            {
                              
                                 if (CodeStr[Lex_index] == 'u') current_State = table[current_State, 20];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 62:
                            {
                                
                                 if (CodeStr[Lex_index] == 'r') current_State = table[current_State, 15];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 63:
                            {
                               
                                 if (CodeStr[Lex_index] == 'n') current_State = table[current_State, 13];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 64:
                            {
                               
                                 if (CodeStr[Lex_index] == 'b') current_State = table[current_State, 21];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 65:
                            {
                                
                                 if (CodeStr[Lex_index] == 'a') current_State = table[current_State, 11];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 66:
                            {
                                
                                 if (CodeStr[Lex_index] == 'c') current_State = table[current_State, 22];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }

                        case 67:
                            {
                               
                                 if (CodeStr[Lex_index] == 'k') current_State = table[current_State, 23];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                {
                                    current_State = 0; current_Token = TokenType.Identifer;
                                }
                                else if (isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 101; }
                                break;
                            }
                        case 68:
                            {
                                current_Token = TokenType.Return;
                                current_State = 0;
                                break;
                            }
                        case 69:
                            {
                                current_Token = TokenType.ArithmeticOperation;
                                current_State = 0;
                                break;

                            }
                        case 70:
                            {
                               
                                 if (CodeStr[Lex_index] == '>') current_State = table[current_State, 33];
                                 else if (isDelimeter(CodeStr[Lex_index]) || isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_Token = TokenType.ArithmeticOperation; current_State = 0; }
                                break;
                            }
                        case 71:
                            {
                                current_Token = TokenType.ArithmeticOperation;
                                current_State = 0;
                                break;
                            }
                        case 72:
                            {
                                if (CodeStr[Lex_index] == '$') { save = false; current_State = table[current_State, 43]; }
                                else
                                {
                                   
                                    current_Token = TokenType.ArithmeticOperation;
                                    current_State = 0;
                                    Lex_index--;
                                }
                                break;
                            }
                        case 73:
                            {
                                current_Token = TokenType.AccessOperator;
                                current_State = 0;
                                break;
                            }
                        case 74:
                            {
                                current_Token = TokenType.Braces;
                                current_State = 0;
                                break;
                            }
                        case 75:
                            {
                                current_Token = TokenType.Braces;
                                current_State = 0;
                                break;
                            }
                        case 76:
                            {
                                current_Token = TokenType.Braces;
                                current_State = 0;
                                break;
                            }

                        case 77:
                            {
                                current_Token = TokenType.Braces;
                                current_State = 0;
                                break;
                            }
                        case 78:
                            {
                                
                                 if (CodeStr[Lex_index] == '&') current_State = table[current_State, 29];
                                 else if (isDelimeter(CodeStr[Lex_index]) || isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = -1; }
                                break;
                            }
                        case 79:
                            {
                                current_Token = TokenType.Logicoperators;
                                current_State = 0;
                                break;
                            }
                        case 80:
                            {
                                
                                 if (CodeStr[Lex_index] == '|') current_State = table[current_State, 30];
                                else if (isDelimeter(CodeStr[Lex_index]) || isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = -1; }
                                break;
                            }
                        case 81:
                            {
                                current_Token = TokenType.Logicoperators;
                                current_State = 0;
                                break;
                            }
                        case 82:
                            {
                                current_Token = TokenType.Logicoperators;
                                current_State = 0;
                                break;
                            }
                        case 83:
                            {
                                current_Token = TokenType.QuotationMark;
                                break;
                            }
                        case 84:
                            {
                                current_Token = TokenType.QuotationMark;
                                current_State = 0;
                                break;
                            }
                        case 85:
                            {
                                
                                 if (CodeStr[Lex_index] == '$') { save = false; current_State = table[current_State, 43];}
                                 else if (isDelimeter(CodeStr[Lex_index]) || isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = -1; }
                                break;
                            }
                        case 86:
                            {
                                
                                 if (CodeStr[Lex_index] == '$') { save = false; current_State = table[current_State, 43];}
                                else if (isDelimeter(CodeStr[Lex_index]) || isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = -1; }
                                break;
                            }
                        case 87:
                            {
                                if (CodeStr[Lex_index] != '\n')
                                {
                                    save = false;
                                }
                                else
                                    current_State = 1;
                                break;
                            }
                        case 88:
                            {
                            
                                if (CodeStr[Lex_index] == '$') { save = false; current_State = table[current_State, 43]; }
                                else
                                {
                                    current_Lex = "/";
                                    save = false;
                                    current_State = -1;
                                    Lex_index--;

                                }

                         

                                 break;
                            }
                        case 89:
                            {
          
                               if (CodeStr[Lex_index] == '$') { save = false; current_State = table[current_State, 43]; }
                                else { save = false;}
                                break;
                            }
                        case 90:
                            {

                                if (CodeStr[Lex_index] == '/') { save = false; current_State = table[current_State, 44]; }
                                else { save = false; current_State = 89; }

                               
                                break;
                            }
                        case 91:
                            {
                                current_State = 1;
                                break;
                            }
                        case 92:
                            {
                               
                                 if (CodeStr[Lex_index] == '=') current_State = table[current_State, 32];
                                 else if (CodeStr[Lex_index] == ' ' || CodeStr[Lex_index] == '\n' || CodeStr[Lex_index] == '\t' || CodeStr[Lex_index] == '\r' || CodeStr[Lex_index] == ';')
                                { current_State = 0; current_Token = TokenType.Assignmentoperator; }
                                break;
                            }
                        case 93:
                            {
                                current_Token = TokenType.relationaloperators;
                                current_State = 0;
                                break;
                            }
                        case 94:
                            {
                                 
                                 if (CodeStr[Lex_index] == '=') current_State = table[current_State, 32];
                                 else if (CodeStr[Lex_index] == ' ' || CodeStr[Lex_index] == '\n' || CodeStr[Lex_index] == '\t' || CodeStr[Lex_index] == '\r' || CodeStr[Lex_index] == ';')
                                { current_State = 0; current_Token = TokenType.relationaloperators; }

                                break;
                            }
                        case 95:
                            {
                                current_Token = TokenType.relationaloperators;
                                current_State = 0;
                                break;
                            }
                        case 96:
                            {
                              
                                 if (CodeStr[Lex_index] == '=') current_State = table[current_State, 32];
                                else if (isDelimeter(CodeStr[Lex_index]) || isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 0; current_Token = TokenType.relationaloperators; }

                                break;
                            }
                        case 97:
                            {
                                current_Token = TokenType.relationaloperators;
                                current_State = 0;
                                break;
                            }
                        case 98:
                            {
                               
                                 if (CodeStr[Lex_index] == '=') current_State = table[current_State, 32];
                                 else if (isDelimeter(CodeStr[Lex_index]) || isDigit(CodeStr[Lex_index]) || isLetter(CodeStr[Lex_index]))
                                { current_State = 0; current_Token = TokenType.relationaloperators; }

                                break;
                            }
                        case 99:
                            {
                                current_Token = TokenType.relationaloperators;
                                current_State = 0;
                                break;
                            }
                        case 100:
                            {
                                
                                 if (isDigit(CodeStr[Lex_index])) current_State = table[current_State, 40];
                                else if (isLetter(CodeStr[Lex_index])) {
                                    while (!isDelimeter(CodeStr[Lex_index])) {
                                        current_Lex += CodeStr[Lex_index];
                                        Lex_index++;
                                    }
                                    current_State = -1;}
                                else if (isDelimeter(CodeStr[Lex_index]))
                                { current_State = 0; current_Token = TokenType.Constant; }
                                break;
                            }
                        case 101:
                            {
                               
                                 if (isLetter(CodeStr[Lex_index])) current_State = table[current_State, 45];
                                else if (isDigit(CodeStr[Lex_index])) current_State = table[current_State, 40];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                { current_Token = TokenType.Identifer; current_State = 0; }

                                break;
                            }
                        case 102:
                            {
                               
                                 if (isLetter(CodeStr[Lex_index])) current_State = table[current_State, 45];
                                else if (isDigit(CodeStr[Lex_index])) current_State = table[current_State, 40];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                { current_State = 0; current_Token = TokenType.Identifer; }

                                break;
                            }
                        case 103:
                            {
                                
                                 if (isLetter(CodeStr[Lex_index])) current_State = table[current_State, 45];
                                else if (isDigit(CodeStr[Lex_index])) current_State = table[current_State, 40];
                                else if (isDelimeter(CodeStr[Lex_index]))
                                { current_State = 0; current_Token = TokenType.Identifer; }

                                break;
                            }
                        default:
                            current_Token = TokenType.Error;
                            numberOfErrors++;
                            current_State = 0;
                            break;

                    }
                    
                    if (save) { current_Lex += CodeStr[Lex_index]; }

                    if (current_State == 0)

                    {
                     

                        if (current_Token != TokenType.NULL) ListToPrint.Add(new KeyValuePair<string, TokenType>(current_Lex, current_Token));
                        current_Lex = "";
                        current_State = 1;
                        current_Token = TokenType.NULL;


                    }

                    Lex_index++;
                }

                if (current_Token != TokenType.NULL) ListToPrint.Add(new KeyValuePair<string, TokenType>(current_Lex, current_Token));

                return ListToPrint;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
