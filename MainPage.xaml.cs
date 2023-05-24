using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculadoraTaller2
{
    public partial class MainPage : ContentPage
    {
        private string operador = null;    // operador seleccionado
        private double valor1 = 0;         // primer valor para la operación
        private bool valor2EnProceso = false;  // indica si se está ingresando el segundo valor

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string texto = button.Text;

            if (texto == "C")   // Limpiar la calculadora
            {
                resultadoLabel.Text = "0";
                operador = null;
                valor1 = 0;
                valor2EnProceso = false;
            }
            else if (texto == "+" || texto == "-" || texto == "*" || texto == "/") // Seleccionar operador
            {
                operador = texto;
                valor1 = double.Parse(resultadoLabel.Text);
                valor2EnProceso = true;
            }
            else if (texto == "=")  // Realizar la operación
            {
                

                double valor2 = double.Parse(resultadoLabel.Text);
                double resultado = 0;

                // Realizar la operación correspondiente según el operador seleccionado
                if (operador == "+")
                {
                    resultado = valor1 + valor2;
                }
                else if (operador == "-")
                {
                    resultado = valor1 - valor2;
                }
                else if (operador == "*")
                {
                    resultado = valor1 * valor2;
                }
                else if (operador == "/")
                {
                    resultado = valor1 / valor2;
                }

                resultadoLabel.Text = resultado.ToString();
                operador = null;
                valor1 = resultado;
                valor2EnProceso = false;
            }
            else  // Agregar el número o el punto al resultado
            {
                if (valor2EnProceso)  // Ingresando el segundo valor
                {
                    resultadoLabel.Text = texto;
                    valor2EnProceso = false;
                }
                else if (resultadoLabel.Text == "0")  // El resultado es 0
                {
                    resultadoLabel.Text = texto;
                }
                else  // Agregar el número o el punto al resultado existente
                {
                    resultadoLabel.Text += texto;
                }
            }
        }
    }
}
