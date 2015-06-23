using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Matrix_Calculator {
    public partial class MatrixForm : Form {
        public MatrixForm() {
            InitializeComponent();
        }

        private void buttonOpenA_Click(object sender, EventArgs e) {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = @"Text Files|*.txt|All Files|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            textBox1.Text = sr.ReadToEnd().Trim();
            sr.Close();
        }

        private void buttonOpenB_Click(object sender, EventArgs e) {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = @"Text Files|*.txt|All Files|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            textBox2.Text = sr.ReadToEnd().Trim();
            sr.Close();
        }

        private void buttonSaveA_Click(object sender, EventArgs e) {
            Save("A", textBox1.Text);
        }

        private void buttonSaveB_Click(object sender, EventArgs e) {
            Save("B", textBox2.Text);
        }

        private void button12_Click(object sender, EventArgs e) {
            Save("Result", textBox3.Text);
        }

        private void Save(string name, string matrix) {
            saveFileDialog1.FileName = name;
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.Filter = @"Text Files|*.txt|All Files|*.*";
            saveFileDialog1.Title = @"Save As";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.WriteLine(matrix);
                sw.Close();
            }
        }

        private void buttonClearA_Click(object sender, EventArgs e) {
            textBox1.Clear();
        }

        private void buttonClearB_Click(object sender, EventArgs e) {
            textBox2.Clear();
        }

        private void buttonResult_Click(object sender, EventArgs e) {
            textBox3.Clear();
        }

        private void buttonTransfer_Click(object sender, EventArgs e) {
            var tmp = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = tmp;
        }

        private void buttonA_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            string logText = "A = \r";

            try {
                matrixA = new Matrix(textBox1.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            logText += matrixA + Environment.NewLine + Environment.NewLine;
            textBox3.Text += logText;
        }

        private void buttonB_Click(object sender, EventArgs e) {
            Matrix matrixB = null;
            string logText="B = \r" ;

            try {
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            logText += matrixB + Environment.NewLine + Environment.NewLine;
            textBox3.Text += logText;
        }


        private void buttonA1_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            string logText = "Inverted matrix of A= " + Environment.NewLine;

            try {
                matrixA = new Matrix(textBox1.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }

            try {
                logText += Matrix.ToString(matrixA.Invert()).Trim();
            }
            catch (Exception exception) {
                SystemSounds.Beep.Play();
                logText += exception.Message;
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonB1_Click(object sender, EventArgs e) {
            Matrix matrixB = null;
            string logText = "Inverted matrix of B= " + Environment.NewLine;

            try {
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            try {
                logText += Matrix.ToString(matrixB.Invert()).Trim();
            }
            catch (Exception exception) {
                SystemSounds.Beep.Play();

                logText += exception.Message;
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }


        private void buttonAT_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            string logText = "Transpose matrix of A= ";

            try {
                matrixA = new Matrix(textBox1.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            logText += Matrix.ToString(matrixA.Transpose()) + Environment.NewLine +
                       Environment.NewLine;
            textBox3.Text += logText;
        }

        private void buttonBT_Click(object sender, EventArgs e) {
            Matrix matrixB = null;
            string logText = "Transpose matrix of B= ";

            try {
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            logText += Matrix.ToString(matrixB.Transpose()) + Environment.NewLine +
                       Environment.NewLine;
            textBox3.Text += logText;
        }

        private void buttonApowerX_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            string logText = "Power of matrix A and X= ";

            try {
                matrixA = new Matrix(textBox1.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            double x = (double) numericUpDown1.Value;
            try {
                logText += Matrix.ToString(MatrixEditor.Power(matrixA.MainMatrix, (int)x));

            }
            catch (Exception exception) {
                logText += exception.Message;
                
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonBpowerX_Click(object sender, EventArgs e) {
            Matrix matrixB = null;
            string logText = "Power of matrix B and X= ";

            try {
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            double x = (double) numericUpDown1.Value;
            try {
                logText += Matrix.ToString(MatrixEditor.Power(matrixB.MainMatrix, (int)x));

            }
            catch (Exception exception) {
                logText += exception.Message;
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonAX_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            string logText = "Multiplication of matrix A and X= ";

            try {
                matrixA = new Matrix(textBox1.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            double x = (double) numericUpDown1.Value;
            logText += Matrix.ToString(MatrixEditor.Multiplication(matrixA.MainMatrix, x));
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonBX_Click(object sender, EventArgs e) {
            Matrix matrixB = null;
            string logText = "Multiplication of matrix B and X= ";

            try {
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            double x = (double) numericUpDown1.Value;
            logText += Matrix.ToString(MatrixEditor.Multiplication(matrixB.MainMatrix, x));
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonTraceA_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            string logText = "Trace of matrix B= " + Environment.NewLine;

            try {
                matrixA = new Matrix(textBox1.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            try {
                logText += matrixA.Trace();
            }
            catch (Exception exception) {
                SystemSounds.Beep.Play();

                logText += exception.Message;
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonTraceB_Click(object sender, EventArgs e) {
            Matrix matrixB = null;
            string logText = "Trace of matrix B= " + Environment.NewLine;

            try {
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            try {
                logText += matrixB.Trace();
            }
            catch (Exception exception) {
                SystemSounds.Beep.Play();

                logText += exception.Message;
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonMaxA_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            string logText = "Max value in matrix A= " + Environment.NewLine;
            try {
                matrixA = new Matrix(textBox1.Text);
            }
            catch (Exception exception) {
                logText += exception.Message;
            }
            logText += matrixA.MaxValue();
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonMaxB_Click(object sender, EventArgs e) {
            Matrix matrixB = null;
            string logText = "Max value in matrix B= " + Environment.NewLine;
            try {
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exception) {
                logText += exception.Message;
            }
            logText += matrixB.MaxValue();
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonMinA_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            string logText = "Min value in matrix A= " + Environment.NewLine;
            try {
                matrixA = new Matrix(textBox1.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            logText += matrixA.MinValue();
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonMinB_Click(object sender, EventArgs e) {
            Matrix matrixB = null;
            string logText = "Min value in matrix B= " + Environment.NewLine;
            try {
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            logText += matrixB.MinValue();
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonDimA_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            string logText = "Dimension of matrix A= " + Environment.NewLine;
            try {
                matrixA = new Matrix(textBox1.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            logText += matrixA.Dimension();

            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonDimB_Click(object sender, EventArgs e) {
            Matrix matrixB = null;
            string logText = "Dimension of matrix B= " + Environment.NewLine;
            try {
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            logText+= matrixB.Dimension();

            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonDetA_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            string logText = "Determinant of A= " + Environment.NewLine;
            try {
                matrixA = new Matrix(textBox1.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            try {
                logText += matrixA.Determ();
            }
            catch (Exception exe) {
                logText += exe.Message;
                SystemSounds.Beep.Play();
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonDetB_Click(object sender, EventArgs e) {
            Matrix matrixB = null;
            string logText = "Determinant of B= " + Environment.NewLine;
            try {
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            try {
                logText += matrixB.Determ();
            }
            catch (Exception exe) {
                logText += exe.Message;
                SystemSounds.Beep.Play();
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonRankA_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            string logText = "Rank of matrix A= " + Environment.NewLine;

            try {
                matrixA = new Matrix(textBox1.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            try {
                logText += matrixA.Rank();
            }
            catch (Exception exeException) {
                logText += exeException.Message;
                SystemSounds.Beep.Play();
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonRankB_Click(object sender, EventArgs e) {
            Matrix matrixB = null;
            string logText = "Rank of matrix B= " + Environment.NewLine;
            try {
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            try {
                logText += matrixB.Rank();
            }
            catch (Exception exeException) {
                SystemSounds.Beep.Play();
                logText += exeException.Message;
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonAdjA_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            string logText = "Adjugate matrix of A= " + Environment.NewLine;
            try {
                matrixA = new Matrix(textBox1.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            try {
                logText += Matrix.ToString(matrixA.Adjugate(matrixA.MainMatrix)).Trim();
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }


        private void buttonAdjB_Click(object sender, EventArgs e) {
            Matrix matrixB = null;
            string logText = "Adjugate matrix of B= " + Environment.NewLine;

            try {
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            try {
                logText += Matrix.ToString(matrixB.Adjugate(matrixB.MainMatrix)).Trim();
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }


        private void buttonLU_A_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            string logText = "LU matrix of A= " + Environment.NewLine;

            try {
                matrixA = new Matrix(textBox1.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            try {
                logText += "L matrix of A= " + Environment.NewLine;
                logText += Matrix.ToString(matrixA.LUmatrix(0)).Trim();
                logText += Environment.NewLine + Environment.NewLine + "U matrix of A= " + Environment.NewLine;
                logText += Matrix.ToString(matrixA.LUmatrix(1)).Trim();
            }
            catch (Exception exe) {
                logText += exe.Message;
                SystemSounds.Beep.Play();
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonLU_B_Click(object sender, EventArgs e) {
            Matrix matrixB = null;

            string logText = "LU matrix of B= " + Environment.NewLine;

            try {
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            try {
                logText += "L matrix of B= " + Environment.NewLine;
                logText += Matrix.ToString(matrixB.LUmatrix(0)).Trim();
                logText += Environment.NewLine + Environment.NewLine + "U matrix of B= " + Environment.NewLine;
                logText += Matrix.ToString(matrixB.LUmatrix(1)).Trim();
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonAB_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            Matrix matrixB = null;

            string logText = "Multiplication of matrix A and matrix B= " + Environment.NewLine;

            try {
                matrixA = new Matrix(textBox1.Text);
                matrixB = new Matrix(textBox2.Text);

            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            try {
                logText += Matrix.ToString(MatrixEditor.Multiplication(matrixA.MainMatrix, matrixB.MainMatrix));
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();

                logText += exe.Message;
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonAplusB_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            Matrix matrixB = null;

            string logText = "Addition of matrix A and matrix B= " + Environment.NewLine;

            try {
                matrixA = new Matrix(textBox1.Text);
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
            try {
                logText += Matrix.ToString(MatrixEditor.Addition(matrixA.MainMatrix, matrixB.MainMatrix));
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();

                logText += exe.Message;
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void buttonAminusB_Click(object sender, EventArgs e) {
            Matrix matrixA = null;
            Matrix matrixB = null;
            string logText = "Subtraction of matrix A and matrix B= " + Environment.NewLine;

            try {
                matrixA = new Matrix(textBox1.Text);
                matrixB = new Matrix(textBox2.Text);
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();
                logText += exe.Message;
            }
           
            try {
                logText += Matrix.ToString(MatrixEditor.Subtraction(matrixA.MainMatrix, matrixB.MainMatrix));
            }
            catch (Exception exe) {
                SystemSounds.Beep.Play();

                logText += exe.Message;
            }
            textBox3.Text += logText + Environment.NewLine + Environment.NewLine;
        }

        private void textBox3_TextChanged(object sender, EventArgs e) {
            textBox3.SelectionStart = textBox3.Text.Length;
            textBox3.ScrollToCaret();
        }

        private void MatrixForm_Load(object sender, EventArgs e) {
        }
    }
}
