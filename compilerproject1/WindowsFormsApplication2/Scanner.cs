using System;
using System.IO;
using System.Text;
using WindowsFormsApplication2;
namespace WindowsFormsApplication2
{
    enum Tokens
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
        EndOfFile
    };
    public class Scanner
    {


        private StreamReader sr;
        Tokens CheckReserved(string s)
        {
            if (s == "Iow") return Tokens.Integer;
            else if (s == "SIow") return Tokens.SInteger;
            else if (s == "Iowf") return Tokens.Float;
            else if (s == "SIowf") return Tokens.SFloat;
            else if (s == "Chlo") return Tokens.Character;
            else if (s == "If") return Tokens.Condetion;
            else if (s == "Chain") return Tokens.String;
            else if (s == "Worthless") return Tokens.Void;
            else if (s == "Else") return Tokens.Condetion;
            else if (s == "Loopwhen") return Tokens.Loop;
            else if (s == "Iteratewhen") return Tokens.Loop;
            else if (s == "Turnback") return Tokens.Return;
            else if (s == "Stop") return Tokens.Break;
            else if (s == "Loli") return Tokens.Struct;
            else if (s == "Include") return Tokens.Inclusion;
            else return Tokens.Identifer;
        }
        Tokens getToken()
        {
            char ch;
            string s;
            int State = 0;
            int lines = 0;
            int i = 0;
            while (State >= 0 && State <= 11 && (s = sr.ReadLine()) != null)
            {
                switch (State)
                {
                    case 0:
                        ch = sr.ReadLine();
                        if (isSpace(ch[i])) { i++; State = 0; }
                        else if (ch[i] == "+" || ch[i] == "-" || ch[i] == "/" || ch[i] == "*") { i++; State = 1; }
                        else if (ch[i] == "&&" || ch[i] == "||" || ch[i] == "~") { i++; State = 2; }
                        else if (ch[i] == "!=" || ch[i] == "==" || ch[i] == "<" || ch[i] == ">" || ch[i] == ">=" || ch[i] == "<=") { i++; State = 3; }
                        else if (ch[i] == "=") { i++; State = 4; }
                        else if (ch[i] == "->") { i++; State = 5; }
                        // else if (ch == ";") State = 6;
                        else if (ch[i] == "'" || ch[i] == '"') { i++; State = 7; }
                        else if (ch[i] == "]" || ch[i] == "[" || ch[i] == "}" || ch[i] == "{") { i++; State = 8; }
                        else if (isDigit(ch[i])) { s = ch[i]; i++; State = 9; }
                        else if (isalpha(ch[i])) { s = ch[i]; i++; State = 10; }
                        else if ((s = sr.ReadLine()) == null) return Tokens.EndOfFile;
                        else State = 11;
                        break;
                    case 1: i++; return Tokens.ArithmeticOperation; break;
                    case 2: i++; return Tokens.Logicoperators; break;
                    case 3: i++; return Tokens.relationaloperators; break;
                    case 4: i++; return Tokens.Assignmentoperator; break;
                    case 5: i++; return Tokens.AccessOperator; break;
                    case 7: i++; return Tokens.QuotationMark; break;
                    case 8: i++; return Tokens.Braces; break;
                    case 9:
                        if (isDigit(ch[i])) { s += ch[i]; i++; State = 9; }
                        else { i--; return Tokens.Constant; }
                    case 10:
                        if (isalpha(ch[i])) { s += ch[i]; i++; State = 10; }
                        else { i--; return CheckReserved(s); }
                        break;
                    case 11: return Tokens.Error;
                }
            }
        }
        public void Display()
        {
            
            Tokens t;
            if (sr.ReadLine() == null) Console.WriteLine("end of file");
            while (sr.ReadLine() != null)
            {
                t = getToken();
                switch (t)
                {
                    case Tokens.Integer: Console.WriteLine("Integer"); break;
                    case Tokens.SInteger: Console.WriteLine("SInterger"); break;
                    case Tokens.Float: Console.WriteLine("Float"); break;
                    case Tokens.SFloat:  Console.WriteLine("SFloat"); break;
                    case Tokens.Character: Console.WriteLine("Chracter"); break;
                    case Tokens.String:  Console.WriteLine("Interger"); break;
                    case Tokens.EndOfFile: break;
                    case Tokens.ArithmeticOperation: Console.WriteLine("Arithmetic Operation"); break;
                    case Tokens.Assignmentoperator:  Console.WriteLine("Assignment operator"); break;
                    case Tokens.AccessOperator:  Console.WriteLine("AccessOperator"); break;
                    case Tokens.Braces:  Console.WriteLine("Braces"); break;
                    case Tokens.Condetion:  Console.WriteLine("Condation"); break;
                    case Tokens.Break:  Console.WriteLine("Break"); break;
                    case Tokens.Constant:  Console.WriteLine("Conistant"); break;
                    case Tokens.Identifer:  Console.WriteLine("Identifer"); break;
                    case Tokens.Inclusion:  Console.WriteLine("Inclusion"); break;
                    case Tokens.Error:  Console.WriteLine("Error"); break;
                    case Tokens.Logicoperators:  Console.WriteLine("Logic operators"); break;
                    case Tokens.Loop:  Console.WriteLine("Loop"); break;
                    case Tokens.QuotationMark:  Console.WriteLine("Quotation Mark"); break;
                    case Tokens.Return:  Console.WriteLine("Return"); break;
                    case Tokens.Void: Console.WriteLine("Void"); break;
                    case Tokens.Struct: Console.WriteLine("Struct"); break;
                }
            }
        }
        public Scanner(string fileName)
        {
            sr = new StreamReader(fileName);
        }
        public ~Scanner()
        {
            sr.Close();
        }
        public bool isSpace(char c)
        {
            if (c == "" || c == " " || c == "\t" || c == "\n" || c == ";")
                return true;
            else
                return false;
        }
        public bool isDigit(char c)
        {
            if (c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' || c == '0')
                return true;
            else
                return false;
        }
        public bool isalpha(char c)
        {
            if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c = '_')
                return true;
            else
                return false;
        }
        void main() {
            string Filename;
            Console.WriteLine("enter file path: ");
            Console.ReadKey();
            Scanner ln= new Scanner(Filename);
            ln.Display();
            ~Scanner();

        }
    }
}