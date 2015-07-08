/*
* ++++++++++++++++++++++++++++++++++++++++++++++++++
* This code is generated by a tool and is provided "as is", without warranty of any kind,
* express or implied, including but not limited to the warranties of merchantability,
* fitness for a particular purpose and non-infringement.
* In no event shall the authors or copyright holders be liable for any claim, damages or
* other liability, whether in an action of contract, tort or otherwise, arising from,
* out of or in connection with the software or the use or other dealings in the software.
* ++++++++++++++++++++++++++++++++++++++++++++++++++
* */

using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data.Common;
using System.Windows.Forms;

namespace MySql_Windows_Forms_Project1
{
	public partial class frmshirt : Form
	{
        private DbDataAdapter ad;
		
		public frmshirt()
		{
			InitializeComponent();
		}

        private DbDataAdapter returnAdapter()
        {
            return new MySqlDataAdapter();
        }

        private DbCommandBuilder returnBuilder()
        {
            return new MySqlCommandBuilder();
        }	
		
		private void frmshirt_Load(object sender, EventArgs e)
		{
            DbCommand idbCommand = Connection.provideConnection().CreateCommand();
            idbCommand.CommandText = "select * from `shirt`";
            ad = returnAdapter();
            DbCommandBuilder builder = returnBuilder();
            builder.DataAdapter = ad;
            ad.SelectCommand = idbCommand;
            ad.Fill(this.newDataSet.shirt);
			ad.DeleteCommand = builder.GetDeleteCommand();
			ad.UpdateCommand = builder.GetUpdateCommand();
			ad.InsertCommand = builder.GetInsertCommand();
			MySqlDataAdapter ad3;
			
		}
		
		private void Save_Click(object sender, EventArgs e)
		{
			if (!this.Validate()) return;
			shirtBindingSource.EndEdit();
			ad.Update(this.newDataSet.shirt);
			
		}
		
		private void frmshirt_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = false;
		}
		
		private void idTextBox_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
			if( string.IsNullOrEmpty( idTextBox.Text ) )
			{
				e.Cancel = true;
				errorProvider1.SetError( idTextBox, "The field id is required" ); 
			}
			int v;
			string s = idTextBox.Text;
			if( !int.TryParse( s, out v ) )
			{
				e.Cancel = true;
				errorProvider1.SetError( idTextBox, "The field id must be int." );
			}
			if( !e.Cancel ) { errorProvider1.SetError( idTextBox, "" ); } 
		}
		
		private void stypeTextBox_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
			if( string.IsNullOrEmpty( stypeTextBox.Text ) )
			{
				e.Cancel = true;
				errorProvider1.SetError( stypeTextBox, "The field stype is required" ); 
			}
			if( !e.Cancel ) { errorProvider1.SetError( stypeTextBox, "" ); } 
		}
		
		private void colorTextBox_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
			if( string.IsNullOrEmpty( colorTextBox.Text ) )
			{
				e.Cancel = true;
				errorProvider1.SetError( colorTextBox, "The field color is required" ); 
			}
			if( !e.Cancel ) { errorProvider1.SetError( colorTextBox, "" ); } 
		}
		
		private void ownerTextBox_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
			if( string.IsNullOrEmpty( ownerTextBox.Text ) )
			{
				e.Cancel = true;
				errorProvider1.SetError( ownerTextBox, "The field owner is required" ); 
			}
			int v;
			string s = ownerTextBox.Text;
			if( !int.TryParse( s, out v ) )
			{
				e.Cancel = true;
				errorProvider1.SetError( ownerTextBox, "The field owner must be int." );
			}
			if( !e.Cancel ) { errorProvider1.SetError( ownerTextBox, "" ); } 
		}
		
		
		
		
		private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
		{
			shirtBindingSource.AddNew();
		}
	}
}
