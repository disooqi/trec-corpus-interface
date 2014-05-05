using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using nsTREC_Corpus;

namespace TREC_Interface
{
    public partial class document_viewer : Form
    {
        TREC_Corpus corpus;

        public document_viewer()
        {
            InitializeComponent();
        }

        private void document_viewer_Load(object sender, EventArgs e)
        {
            string doc;
            corpus.get_first_DOC(out doc);
            richTextBox1.Text = doc;
        }

        public TREC_Corpus Corpus
        {
            set { corpus = value; }
            get { return corpus; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string next_doc;
            corpus.get_next_DOC(out next_doc);
            richTextBox1.Text = next_doc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string next_doc;
            while (corpus.get_next_DOC(out next_doc))
            {
                if (next_doc.StartsWith("<DOC>"))
                {
                    if(Regex.Match(next_doc, @"<DOCNO>(?<DOCNO>.*)</DOCNO>", RegexOptions.IgnoreCase).Groups["DOCNO"].Value == textBox1.Text)
                    {
                        richTextBox1.Text = next_doc;
                        break;
                    }
                    
                }
                else
                {
                    if (next_doc.Substring(5, 21) == textBox1.Text)
                    {
                        richTextBox1.Text = next_doc;
                        break;
                    }
                }
            }
        }
    }
}