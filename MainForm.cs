using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace VAPO
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			dgvCarregaObj.Rows.Add();
			dgvCarregaObj.Rows.Add();
			dgvCarregaObj.Rows.Add();
			dgvCarregaObj.Rows.Add();
			
			ListaBase.Add("JANEIRO");
			ListaBase.Add("FEVEREIRO");
			ListaBase.Add("MARÇO");
			ListaBase.Add("ABRIL");
			ListaBase.Add("MAIO");
			ListaBase.Add("JUNHO");
			ListaBase.Add("JULHO");
			ListaBase.Add("AGOSTO");
			ListaBase.Add("SETEMBRO");
			ListaBase.Add("OUTUBRO");
			ListaBase.Add("NOVEMBRO");
			ListaBase.Add("DEZEMBRO");
		}
		
		AutoCompleteStringCollection ListaBase = new AutoCompleteStringCollection();
		AutoCompleteStringCollection ListaDinamica = new AutoCompleteStringCollection();
		TextBox autoText = new TextBox();
		int eixoX;
		int eixoY;

		void DgvCarregaObjEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			
			autoText = e.Control as TextBox;
			autoText.CharacterCasing = CharacterCasing.Upper;
			autoText.TextChanged += (DigitandoTexto);
			autoText.KeyDown += (ok);
			
			
			
//			autoText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//			autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
//			autoText.AutoCompleteCustomSource = textBox1.AutoCompleteCustomSource;
			
			
				
		}
		
		void ListaTxt()
		{
			ListaDinamica.Clear();
			
			for (int i = 0; i < listBox1.Items.Count; i++)
			{
				ListaDinamica.Add((string)listBox1.Items[i]);
				
			}
			
			//textBox1.AutoCompleteCustomSource = ListaDinamica;
			//autoText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			//autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
			//autoText.AutoCompleteCustomSource = textBox1.AutoCompleteCustomSource;
		}
	
		
		void DigitandoTexto(object sender, EventArgs e)
		{
			string txt = autoText.Text;
			listBox1.Items.Clear();

			for (int i = 0; i < ListaBase.Count; i++)
			{
				if (Regex.IsMatch(ListaBase[i], txt, RegexOptions.IgnoreCase))
				{
					listBox1.Items.Add(ListaBase[i]);
				}
			}
			
		}
		
		void DgvCarregaObjCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			label1.Text = "X:"+e.X + " Y:"+ e.Y;
			label2.Text = "X:"+ Control.MousePosition.X + " Y:"+ Control.MousePosition.Y;
			label3.Text = Size.Height+"  " + Size.Width;
			eixoX = int.Parse(e.X.ToString());
			eixoY = int.Parse(e.Y.ToString());
			
			PosicionCaixaTexto(eixoX,eixoY,listBox1);
	
		}
		
		
		
		
		void PosicionCaixaTexto(int Locx, int Locy , Control ctrl)
		{
			if (WindowState == FormWindowState.Maximized) 
			{
			ctrl.Location = new Point(Control.MousePosition.X-Locx+5, Control.MousePosition.Y-Locy);
			listBox1.Visible=true;
			}
			else
			{
				ctrl.Location = new Point(Control.MousePosition.X-Locx-2, Control.MousePosition.Y-Locy-7);
				listBox1.Visible=true;
			}
			
		}
		

		void MainFormSizeChanged(object sender, EventArgs e)
		{
			label3.Text = Size.Height+"  " + Size.Width;

			listBox1.Visible=false;
		}
		
		void SelecionaTexto(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Down) 
			{
				if (listBox1.Visible==true) 
				{
					
					
				}
			}
		}
		
		 protected  void ok(object sender, KeyEventArgs args)
        {
            // if user presses key.up
            if ((args.KeyCode == Keys.Up))
            {
                // move the selection in listbox one up
                MoveSelectionInListBox((SelectedIndex - 1));
                // work is done
                args.Handled = true;
            }
            // on key.down
            else if ((args.KeyCode == Keys.Down))
            {
                //move one down
                MoveSelectionInListBox((SelectedIndex + 1));
                args.Handled = true;
            }
            else if ((args.KeyCode == Keys.PageUp))
            {
                //move 10 up
                MoveSelectionInListBox((SelectedIndex - 10));
                args.Handled = true;
            }
            else if ((args.KeyCode == Keys.PageDown))
            {
                //move 10 down
                MoveSelectionInListBox((SelectedIndex + 10));
                args.Handled = true;
            }
            // on enter
            else if ((args.KeyCode == Keys.Enter))
            {
                // select the item in the ListBox
                //SelectItem();
                args.Handled = true;
            }
            else
            {
                // work is not done, maybe the base class will process the event, so call it...
                base.OnKeyDown(args);
            }
        }
		 
		  private void MoveSelectionInListBox(int Index)
        {
            // beginning of list
            if (Index <= -1)
            { this.SelectedIndex = 0; }
            else
                // end of liste
                if (Index > (listBox1.Items.Count - 1))
                {
                    SelectedIndex = (listBox1.Items.Count - 1);
                }
                else
                // somewhere in the middle
                { SelectedIndex = Index; }
        }
		  
		   public int SelectedIndex
        {
            get
            {
                return listBox1.SelectedIndex;
            }
            set
            {
                // musn't be null
                if (listBox1.Items.Count != 0)
                { listBox1.SelectedIndex = value; }
            }
        }
	}
}