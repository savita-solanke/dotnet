using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Xml;
using System.ComponentModel;
using System.Diagnostics;

namespace RecordKeys
{
   
    public partial class Form1 : Form
    {
        private String path = "D\\Log.txt";
        int cTab = 0, cChar = 0, cBack = 0, cDel = 0,cDigit=0,cEnter=0,cOther=0 ,cSpace=0,cCtrC=0,cCtrV=0,cCtrX=0;
        string sCut=null,sCopy = null, sChar = null, sBack = null, sDel = null, sDigit = null, sPaste = null, sOther = null, sSpace = null;
        // Sentense s;
        [DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ToUnicodeEx(
            uint wVirtKey,
            uint wScanCode,
            Keys[] lpKeyState,
            StringBuilder pwszBuff,
            int cchBuff,
            uint wFlags,
            IntPtr dwhkl);

        [DllImport("user32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetKeyboardLayout(uint threadId);

        [DllImport("user32.dll", ExactSpelling = true)]
        internal static extern bool GetKeyboardState(Keys[] keyStates);

        [DllImport("user32.dll", ExactSpelling = true)]
        internal static extern uint GetWindowThreadProcessId(IntPtr hwindow, out uint processId);
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
         

        }

        string prevStr = null;
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {


        }

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        StreamWriter file = new StreamWriter(Application.StartupPath+"\\Logs.txt", true);
       
      
        public Form1()
        {
            InitializeComponent();
            file.Write("{      \"Sentense\": [");


         //   File.SetAttributes(path, FileAttributes.Hidden);
    }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyValue == 67)
            {
                // MessageBox.Show(Clipboard.GetText());
                cCtrC++;
                sCopy = sCopy + "," + Clipboard.GetText();

            }
            else if (e.Control && e.KeyValue == 86)
            {
                cCtrV++;
                sPaste = sPaste + "," + Clipboard.GetText();


                // MessageBox.Show(Clipboard.GetText());
            }
            if (e.Control && e.KeyValue == 88)
            {
                sCut = sCut + "," + Clipboard.GetText();

                cCtrX++;
            }

            for (int i = 0; i < 255; i++)
            {
                int key = GetAsyncKeyState(i);
                if (key == 1 || key == -32767)
                {
                    file.Write("Sentence:" + richTextBox1.Text + " - " + verifyKey(i) + "\n");
                    break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "मुख्यमंत्री उद्धव ठाकरे आज मराठा आरक्षण, न्यायालयाचा निकाल यावर निवेदन";
        }
        private void start()
        {
          
        }

        private String verifyKey(int code)
        {
            String key = "";

            if (code == 8) { key = "[Back]"; cBack++;
               // int pos = richTextBox1.getSelectionStart();
               // if (pos > 0)
                 // sBack = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd   );
                // String text = richTextBox1.getText().delete(pos - 1, pos).toString();
          } 
            else if (code == 9) { key = "[TAB]"; cTab++; }
            else if (code == 13) { key = "[Enter]"; cEnter++; }
            else if (code == 19) { key = "[Pause]"; cOther++; }
            else if (code == 20) { key = "[Caps Lock]"; cOther++; }
            else if (code == 27) { key = "[Esc]"; cOther++; }
            else if (code == 32) { key = "[Space]"; cSpace++; }
            else if (code == 33) { key = "[Page Up]"; cOther++; }
            else if (code == 34) { key = "[Page Down]"; cOther++; }
            else if (code == 35) { key = "[End]"; cOther++; }
            else if (code == 36) { key = "[Home]"; cOther++; }
            else if (code == 37) { key = "[Left]"; cOther++; }
            else if (code == 38) { key = "[Up]"; cOther++; }
            else if (code == 39) { key = "[Right]"; cOther++; }
            else if (code == 40) { key = "[Down]"; cOther++; }
            else if (code == 44) { key = "[Print Screen]"; cOther++; }
            else if (code == 45) { key = "[Insert]"; cOther++; }
            else if (code == 46) { key = "[Delete]"; cDel++; }
            else if (code == 48) { key = CodeToString(code); ; cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 49) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 50) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 51) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 52) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 53) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 54) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 55) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 56) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 57) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 65) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 66) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 67) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 68) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 69) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 70) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 71) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 72) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 73) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 74) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 75) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 76) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 77) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 78) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 79) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 80) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 81) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 82) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 83) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 84) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 85) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 86) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 87) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 88) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 89) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 90) { key = CodeToString(code); cChar++; sChar = sChar+"," + key; }
            else if (code == 91) { key = "[Windows]"; cOther++; }
            else if (code == 92) { key = "[Windows]"; cOther++; }
            else if (code == 93) { key = "[List]"; cOther++; }
            else if (code == 96) { key = CodeToString(code);  cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 97) { key = CodeToString(code);  cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 98) { key = CodeToString(code);  cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 99) { key = CodeToString(code);  cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 100) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 101) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 102) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 103) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 104) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 105) { key = CodeToString(code); cDigit++; sDigit = sDigit +","+ key; }
            else if (code == 106) { key = CodeToString(code); cOther++;  }
            else if (code == 107) { key = CodeToString(code); cOther++;  }
            else if (code == 109) { key = CodeToString(code); cOther++;  }
            else if (code == 110) { key = CodeToString(code); cOther++;  }
            else if (code == 111) { key = "/"; cOther++;  }
            else if (code == 112) { key = "[F1]"; cOther++; }
            else if (code == 113) { key = "[F2]"; cOther++; }
            else if (code == 114) { key = "[F3]"; cOther++; }
            else if (code == 115) { key = "[F4]"; cOther++; }
            else if (code == 116) { key = "[F5]"; cOther++; }
            else if (code == 117) { key = "[F6]"; cOther++; }
            else if (code == 118) { key = "[F7]"; cOther++; }
            else if (code == 119) { key = "[F8]"; cOther++; }
            else if (code == 120) { key = "[F9]"; cOther++; }
            else if (code == 121) { key = "[F10]"; cOther++; }
            else if (code == 122) { key = "[F11]"; cOther++; }
            else if (code == 123) { key = "[F12]"; cOther++; }
            else if (code == 144) { key = "[Num Lock]"; cOther++; }
            else if (code == 145) { key = "[Scroll Lock]"; cOther++; }
            else if (code == 160) { key = "[Shift]"; cOther++; }
            else if (code == 161) { key = "[Shift]"; cOther++; }
            else if (code == 162) { key = "[Ctrl]"; cOther++; }
            else if (code == 163) { key = "[Ctrl]"; cOther++; }
            else if (code == 164) { key = "[Alt]"; cOther++; }
            else if (code == 165) { key = "[Alt]"; cOther++; }
            else if (code == 187) { key = "="; cOther++; }
            else if (code == 186) { key = "ç"; cOther++; }
            else if (code == 188) { key = ","; cOther++; }
            else if (code == 189) { key = "-"; cOther++; }
            else if (code == 190) { key = "."; cOther++; }
            else if (code == 192) { key = "'"; cOther++; }
            else if (code == 191) { key = ";"; cOther++; }
            else if (code == 193) { key = "/"; cOther++; }
            else if (code == 194) { key = "."; cOther++; }
            else if (code == 219) { key = "´"; cOther++; }
            else if (code == 220) { key = "]"; cOther++; }
            else if (code == 221) { key = "["; cOther++; }
            else if (code == 226) { key = "\\"; cOther++; }
            else  key = "[" + code + "]"; 
                     return key;
             }

        private void button1_Click(object sender, EventArgs e)
        {
            //s.noofBackSpace.Add("Count" +cChar + "CharList:"  + sChar);
            file.Write("\n" + "no.of BackSpace: " + cBack + "\n" + //+ " BackedSpacedCharList: " +sBack +"\n" +
                "no.of Deletion:" + cDel + " DeletedCharList: " + "\n" +//sDel+ "\n" +
                "no.of Char Enter:" + cChar + " CharList :" + sChar + "\n" +
                "no.of Digit Enter:" + cDigit + "DigitList:" + sDigit + "\n" +
                "no.of Space Enter:" + cSpace + "\n" +
                "Other Char: " + cOther + "\n" +
                "copy-keys: " + cCtrC + " " + " CopyList: " + sCopy + "\n" +
                "paste-Key: " + cCtrV + " Pastelist: " + sPaste + "\n" +
                "Cut-Key: " + cCtrX + " Cutlist: " + sCut + "\n");
                //"}]" + "});");
            file.Close();

            MessageBox.Show("Successfully Write File");
           // File.WriteAllText("D:\\myobjects.json", JsonConvert.SerializeObject(s));
        }
        public  string CodeToString(int scanCode)
        {
            //  return scanCode.ToString();
            uint procId;

            uint thread = GetWindowThreadProcessId(Process.GetCurrentProcess().MainWindowHandle, out procId);
            IntPtr hkl = GetKeyboardLayout(thread);

            if (hkl == IntPtr.Zero)
            {
                Console.WriteLine("Sorry, that keyboard does not seem to be valid.");
                return string.Empty;
            }

            Keys[] keyStates = new Keys[256];
            if (!GetKeyboardState(keyStates))
                return string.Empty;

            StringBuilder sb = new StringBuilder(10);
            int rc = ToUnicodeEx((uint)scanCode, (uint)scanCode, keyStates, sb, sb.Capacity, 0, hkl);
            return sb.ToString();
        }
    }
}
