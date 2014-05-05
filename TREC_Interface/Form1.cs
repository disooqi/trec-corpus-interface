using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using nsTREC_Corpus;

namespace TREC_Interface
{
    public partial class Form1 : Form
    {
        TREC_Corpus corpus;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\D\work\Goals\Academic\Master\Experiments\Dictionary";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox1.Text = openFileDialog1.FileName;

                    if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                    {
                        corpus = new TREC_Corpus(textBox1.Text.Trim(), 'P', 1256);
                    }
                    //if ((myStream = openFileDialog1.OpenFile()) != null)
                    //{
                    //    using (myStream)
                    //    {
                    //        // Insert code to read the stream here.
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TREC_Corpus corpus = new TREC_Corpus(textBox1.Text, 'P', 1256);
            if (corpus != null)
                corpus.process_PTF_Documents_text(textBox2.Text.Trim());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (corpus != null)
            {
                corpus.process_corpus(textBox2.Text.Trim());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (corpus != null)
            {
                document_viewer dv_form = new document_viewer();
                dv_form.Corpus = corpus;
                dv_form.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (corpus != null)
                corpus.from_PTF_format_to_TREC_format(textBox2.Text.Trim());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (corpus != null)
                corpus.process_PTF_topics_text(textBox2.Text.Trim());
        }
    }
}