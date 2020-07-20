using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculatorForm
{
    public partial class Form1 : Form
    {
        private List<double> _valueList = new List<double>();//_valueList存用户输入的数字
        private List<string> _opertorList = new List<string>();//_opertorList存操作符
        private bool _plusFlag = false;//+按下
        private bool _minusFlag = false;//-按下
        private bool _multiFlag = false;//×按下
        private bool _divFlag = false;//÷按下
        private bool _resultFlag = false;//=按下
        private bool _canCalculateFlag = false; //可以计算
        //private bool _backSpaceFlag = false; //按下回撤
        public Form1()
        {
            InitializeComponent();
        }
        private void NumDown(string str)
        {

            if (_plusFlag || _minusFlag || _multiFlag || _divFlag)
            {
                TextBox1.Clear();
                _plusFlag = false;
                _minusFlag = false;
                _multiFlag = false;
                _divFlag = false;
                _resultFlag = false;
                _canCalculateFlag = true;
            }

            if ((str.Equals(".") && TextBox1.Text.IndexOf(".") < 0) || (!str.Equals(".")))
            {
                if (_resultFlag)
                {
                    TextBox1.Clear();
                    Label01.Text = TextBox1.Text;
                    _resultFlag = false;
                }
                TextBox1.Text += str;
                Label01.Text += str;
            }

        }

        private void btGroupBox1_Click(object sender, EventArgs e)
        {
            NumDown(((Button)sender).Text);
            //textBox1.Text = ((Button) sender).Text;
        }


        private void plus_Click(object sender, EventArgs e)
        {
            if ((!_plusFlag) && (!_minusFlag) && (!_multiFlag) && (!_divFlag) && (TextBox1.Text.Length > 0)&&(!TextBox1.Text.Equals(".")))
            {
                _resultFlag = false;
                _valueList.Add(double.Parse(TextBox1.Text));
                _opertorList.Add(((Button)sender).Text);
                Label01.Text += ((Button)sender).Text;
                _plusFlag = true;
                TextBox1.Clear();
                _canCalculateFlag = false;
            }
        }
        private void minus_Click(object sender, EventArgs e)
        {
            if ((!_plusFlag) && (!_minusFlag) && (!_multiFlag) && (!_divFlag)&&(TextBox1.Text.Length > 0) && (!TextBox1.Text.Equals(".")))
            {

                _resultFlag = false;
                _valueList.Add(double.Parse(TextBox1.Text));
                _opertorList.Add(((Button)sender).Text);
                Label01.Text += ((Button)sender).Text;
                _minusFlag = true;
                TextBox1.Clear();
                _canCalculateFlag = false;
            }
        }
        private void mul_Click(object sender, EventArgs e)
        {
            if ((!_plusFlag) && (!_minusFlag) && (!_multiFlag) && (!_divFlag) && (TextBox1.Text.Length > 0) && (!TextBox1.Text.Equals(".")))
            {
                _resultFlag = false;
                _valueList.Add(double.Parse(TextBox1.Text));
                _opertorList.Add(((Button)sender).Text);
                Label01.Text += ((Button)sender).Text;
                _multiFlag = true;
                TextBox1.Clear();
                _canCalculateFlag = false;
            }
        }
        private void div_Click(object sender, EventArgs e)
        {
            if ((!_plusFlag) && (!_minusFlag) && (!_multiFlag) && (!_divFlag) && (TextBox1.Text.Length > 0) && (!TextBox1.Text.Equals(".")))
            {
                _resultFlag = false;
                _valueList.Add(double.Parse(TextBox1.Text));
                _opertorList.Add(((Button)sender).Text);
                Label01.Text += ((Button)sender).Text;
                _divFlag = true;
                TextBox1.Clear();
                _canCalculateFlag = false;
            }
        }

        private void GetResult(object sender, EventArgs e)
        {
            if ((_valueList.Count() > 0) && (_opertorList.Count() > 0) && (_canCalculateFlag == true) && (!TextBox1.Text.Equals(".")))
            {
                _valueList.Add(double.Parse(TextBox1.Text));
                double Total = _valueList[0];
                for (int i = 0; i < _opertorList.Count(); i++)
                {
                    string _operator = _opertorList[i];
                    switch (_operator)
                    {
                        case "+":
                            Total += _valueList[i + 1];
                            break;
                        case "-":
                            Total -= _valueList[i + 1];
                            break;
                        case "*":
                            Total *= _valueList[i + 1];
                            break;
                        case "/":
                            {
                                if (_valueList[i + 1] == 0)
                                {
                                    TextBox1.Text = "0 can not be divisor!Please try again!";
                                    Label01.Text = "0 can not be divisor!Please try again!";
                                    _opertorList.Clear();
                                    _valueList.Clear();
                                    _resultFlag = true;
                                    return;
                                }
                                Total /= _valueList[i + 1];
                                break;
                            }
                        default:
                            break;
                    }

                }
                TextBox1.Text = Total.ToString();
                Label01.Text = Total.ToString();
                _opertorList.Clear();
                _valueList.Clear();
                _resultFlag = true;


            }
        }

        private void btClearAll(object sender, EventArgs e)
        {
            _valueList.Clear();
            _opertorList.Clear();
            TextBox1.Text = "";
            Label01.Text = "";
            _plusFlag = false;
            _minusFlag = false;
            _multiFlag = false;
            _divFlag = false;
            _resultFlag = false;
            _canCalculateFlag = false;
        }

        private void BackSpace(object sender, EventArgs e)
        {
            if (!_resultFlag && TextBox1.Text.Length>0)
            {   

                string TextBox1New = TextBox1.Text.Substring(0, TextBox1.Text.Length - 1);
                string Label01New = Label01.Text.Substring(0, Label01.Text.Length - 1);
                
                TextBox1.Text = TextBox1New;
                Label01.Text = Label01New;
                if (TextBox1.Text.Length == 0)
                {
                    _canCalculateFlag = false;

                }
                else
                {
                    _canCalculateFlag = true;
                }
                //_valueList.RemoveAt(_valueList.Count()-1);
                //_opertorList.RemoveAt(_opertorList.Count()-1);

                //List<double> _valueListNew = 
                //List<string> _opertorListNew = new List<string>();//_opertorList存操作符

            }
        }
    }
}
