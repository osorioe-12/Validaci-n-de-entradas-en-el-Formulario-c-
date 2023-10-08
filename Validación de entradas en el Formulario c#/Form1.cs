using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Validación_de_entradas_en_el_Formulario_c_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombres = textBox1.Text;
            string apellidos = textBox2.Text;
            string edad = textBox3.Text;
            string estatura = textBox4.Text;
            string telefono = textBox5.Text;

            // Obtener el género seleccionado
            string genero = "";
            if (radioButton1.Checked)
            {
                genero = "Hombre";
            }
            else if (radioButton2.Checked)
            {
                genero = "Mujer";
            }

            // Validar que los campos tengan el formato correcto
            if ((EsEnteroValido(edad) && EsDecimalValido(estatura) &&
            EsEnteroValidoDe10Digitos(telefono) && EsTextoValido(nombres) && EsTextoValido(apellidos)))
            {
                // Crear una cadena con los datos
                string datos = $"Nombres: {nombres}\nApellidos: {apellidos}\nEdad: {edad} años\nEstatura: {estatura} cm\nTeléfono: {telefono}\nGénero: {genero}";

                // Guardar los datos en un archivo de texto
                using (StreamWriter archivo = new StreamWriter("datos.txt", true))
                {
                    archivo.WriteLine(datos + "\n\n");
                }

                // Mostrar un mensaje con los datos capturados
                MessageBox.Show("Datos guardados con éxito:\n\n" + datos, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los controles después de guardar
               
            }
            else
            {
                MessageBox.Show("Por favor, ingrese datos válidos en los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             bool EsEnteroValido(string valor)
            {
                int resultado;
                return int.TryParse(valor, out resultado);
            }

           bool EsDecimalValido(string valor)
            {
                decimal resultado;
                return decimal.TryParse(valor, out resultado);
            }

             bool EsEnteroValidoDe10Digitos(string valor)
            {
                return valor.Length == 10 && valor.All(char.IsDigit);
            }

            bool EsTextoValido(string valor)
            {
                return Regex.IsMatch(valor, "^[a-zA-Z\\s]+$");
            }
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            
            
                textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            
        }
    }
}
 

