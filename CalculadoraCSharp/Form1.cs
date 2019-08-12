using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraCSharp
{
    public partial class fm_Calculadora : Form
    {
        string operador = "";
        string armazena_Operador = "";        
        double num_Anterior = 0;
        double valor = 0;
        double primeiro_Numero = 0;
        bool   primeira_Tecla = true;
        bool   tecla_Igual = false;    

        public fm_Calculadora()
        {
            InitializeComponent();           
        }

        private void bt_numerador_Click(object sender, EventArgs e)
        {            
            Button tecla = (Button)sender;            

            if (tecla_Igual == true)
            {
                tx_result.Text = "";
                tecla_Igual = false;
            }
            
            if (armazena_Operador == "")
            {
                if (primeira_Tecla == true)                
                    primeiro_Numero = Convert.ToDouble(tx_result.Text + tecla.Text);                                    

                tx_result.Text = tx_result.Text + tecla.Text;                               
            }
            else
            {
                tx_result.Text = tecla.Text;
            }

            armazena_Operador = "";            
        }

        private void bt_limpa_Click(object sender, EventArgs e)
        {            
            lb_concatena_result.Text = "";
            tx_result.Text = "";
            operador = "";
            num_Anterior = 0;
            valor = 0;
            armazena_Operador = "";
            primeiro_Numero = 0;
            primeira_Tecla = true;
        }

        private void bt_soma_Click(object sender, EventArgs e)
        {
            lb_concatena_result.Text = lb_concatena_result.Text + tx_result.Text + "+";            
            chama_Oepracao();
            operador = "+";
            armazena_Operador = operador;
            primeira_Tecla = false;
        }

        private void bt_subt_Click(object sender, EventArgs e)
        {
            lb_concatena_result.Text = lb_concatena_result.Text + tx_result.Text + "-";
            chama_Oepracao();
            operador = "-";
            armazena_Operador = operador;
            primeira_Tecla = false;
        }

        private void bt_multi_Click(object sender, EventArgs e)
        {
            lb_concatena_result.Text = lb_concatena_result.Text + tx_result.Text + "*";
            chama_Oepracao();
            operador = "*";
            armazena_Operador = operador;
            primeira_Tecla = false;
        }

        private void bt_div_Click(object sender, EventArgs e)
        {
            lb_concatena_result.Text = lb_concatena_result.Text + tx_result.Text + "/";
            chama_Oepracao();
            operador = "/";
            armazena_Operador = operador;
            primeira_Tecla = false;
        }

        private void bt_igual_Click(object sender, EventArgs e)
        {
            if (num_Anterior > 0 && Convert.ToDouble(tx_result.Text) > 0)
            {
                double vl_igual = operacao(operador, num_Anterior, Convert.ToDouble(tx_result.Text));
                tx_result.Text = Convert.ToString(vl_igual);
            }
           
            lb_concatena_result.Text = ""; 
            operador = "";
            num_Anterior = 0;
            valor = 0;
            armazena_Operador = "";
            primeiro_Numero = 0;
            primeira_Tecla = true;
            tecla_Igual = true;
        }

        private void bt_porcent_Click(object sender, EventArgs e)
        {
            if (operador != "")
            {
                if (valor == 0)
                {
                    tx_result.Text = Convert.ToString(primeiro_Numero * Convert.ToDouble(tx_result.Text) / 100);
                    lb_concatena_result.Text = lb_concatena_result.Text + tx_result.Text;
                }
                else
                {
                    tx_result.Text = Convert.ToString(valor * Convert.ToDouble(tx_result.Text) / 100);
                    lb_concatena_result.Text = lb_concatena_result.Text + tx_result.Text;
                }                
            }
        }

        private void bt_virgula_Click(object sender, EventArgs e)
        {
            Button tecla = (Button)sender;

            if (tx_result.Text.IndexOf(",") < 0)            
                tx_result.Text = tx_result.Text + tecla.Text;            
        }

        private void chama_Oepracao()
        {
            if (operador != "")
            {
                valor = operacao(operador, num_Anterior, Convert.ToDouble(tx_result.Text));
                tx_result.Text = Convert.ToString(valor);
            }

            num_Anterior = Convert.ToDouble(tx_result.Text);
        }

        private static double operacao(string oper, double valor_A, double valor_B)
        {
            switch (oper)
            {
                case "+": return valor_A + valor_B;
                case "-": return valor_A - valor_B;
                case "*": return valor_A * valor_B;
                case "/": return valor_A / valor_B;
            }

            return 0;
        }

        private void fm_Calculadora_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (e.KeyChar == 27) //ESC           
                bt_limpa_Click(sender, e);            

            if (e.KeyChar == 8) //BACKSPACE           
                tx_result.Text = tx_result.Text.Remove(tx_result.Text.Length - 1);            

            switch (e.KeyChar.ToString())
            {
                case "0":
                    bt_zero.PerformClick();
                    break;
                case "1":
                    bt_um.PerformClick();
                    break;
                case "2":
                    bt_dois.PerformClick();
                    break;
                case "3":
                    bt_tres.PerformClick();
                    break;
                case "4":
                    bt_quatro.PerformClick();
                    break;
                case "5":
                    bt_cinco.PerformClick();
                    break;
                case "6":
                    bt_seis.PerformClick();
                    break;
                case "7":
                    bt_sete.PerformClick();
                    break;
                case "8":
                    bt_oito.PerformClick();
                    break;
                case "9":
                    bt_nove.PerformClick();
                    break;
                case "+":
                    bt_soma.PerformClick();
                    break;
                case "-":
                    bt_subt.PerformClick();
                    break;
                case "*":
                    bt_multi.PerformClick();
                    break;
                case "/":
                    bt_div.PerformClick();
                    break;
                case "%":
                    bt_porcent.PerformClick();
                    break;
                case "C":
                    bt_limpa.PerformClick();
                    break;
                case ",":
                    bt_virgula.PerformClick();
                    break;
                case "=": //Não está vinculado ao ENTER
                    bt_igual.PerformClick();
                    break;
                default: 
                    break;
            }            
        }       
    }
}