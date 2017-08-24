using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VogalUnica
{
    public partial class Form1 : Form
    {
        private List<char> vogais = new List<char>() { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };

        public Form1()
        {
            InitializeComponent();
        }

        void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;

            Manipulate mLetras = new Manipulate(txtTexto.Text);

            List<char> vogaisEncontradas = new List<char>();
            List<char> vogaisObedecemCriterios = new List<char>();
            char ultimaletra = char.MinValue;

            while (mLetras.hasNext())
            {
                char letraAtual = mLetras.getNext();
                bool removido = false;
                if (vogais.Contains(letraAtual))
                {
                    if (!vogaisEncontradas.Contains(Convert.ToChar(letraAtual.ToString().ToLower())))
                        vogaisEncontradas.Add(Convert.ToChar(letraAtual.ToString().ToLower()));
                    else
                    {
                        removido = true;
                        vogaisObedecemCriterios.Remove(Convert.ToChar(letraAtual.ToString().ToUpper()));
                        vogaisObedecemCriterios.Remove(Convert.ToChar(letraAtual.ToString().ToLower()));
                    }

                    if (!vogais.Contains(ultimaletra) && !removido && ultimaletra != char.MinValue)
                        vogaisObedecemCriterios.Add(letraAtual);
                }

                ultimaletra = letraAtual;

            }

            if (vogaisObedecemCriterios.Count > 0)
                lblResultado.Text = vogaisObedecemCriterios.FirstOrDefault().ToString();
        }
    }
}
