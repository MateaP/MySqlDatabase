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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySql_Windows_Forms_Project1
{
	public partial class frmanimals1 : Form
	{
		private MySqlDataAdapter ad;
		
		public frmanimals1()
		{
			InitializeComponent();
		}
		
		private void frmanimals1_Load(object sender, EventArgs e)
		{
			string strConn = "server=localhost;user id=root;password=0000;database=menagerie;";
			ad = new MySqlDataAdapter("select * from `animals1`", strConn);
			MySqlCommandBuilder builder = new MySqlCommandBuilder(ad);
			ad.Fill(this.newDataSet.animals1);
			ad.DeleteCommand = builder.GetDeleteCommand();
			ad.UpdateCommand = builder.GetUpdateCommand();
			ad.InsertCommand = builder.GetInsertCommand();
			MySqlDataAdapter ad3;
			
		}
		
		private void Save_Click(object sender, EventArgs e)
		{
			if (!this.Validate()) return;
			animals1BindingSource.EndEdit();
			ad.Update(this.newDataSet.animals1);
			
		}
		
		private void frmanimals1_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = false;
		}
		
		private void grpTextBox_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
			if( string.IsNullOrEmpty( grpTextBox.Text ) )
			{
				e.Cancel = true;
				errorProvider1.SetError( grpTextBox, "The field grp is required" ); 
			}
			if( !e.Cancel ) { errorProvider1.SetError( grpTextBox, "" ); } 
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
		
		private void nameTextBox_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
			if( string.IsNullOrEmpty( nameTextBox.Text ) )
			{
				e.Cancel = true;
				errorProvider1.SetError( nameTextBox, "The field name is required" ); 
			}
			if( !e.Cancel ) { errorProvider1.SetError( nameTextBox, "" ); } 
		}
		
		
		
		
		private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
		{
			animals1BindingSource.AddNew();
		}
	}
}
