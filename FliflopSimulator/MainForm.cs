/*
 * Created by SharpDevelop.
 * User: Dour-Andish
 * Date: 12/20/2019
 * Time: 2:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace FliflopSimulator
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private byte counter=0;
		private string Clk;
		private bool[] clkarr;
		private string J;
		private bool[] jarr;
		private string K;
		private bool[] karr;
		private bool[] Right;
		private bool[] Qarr;
		private string Q;
		private string Qperim;
		private StringBuilder state;
		
		public MainForm()
		{
			this.state=new StringBuilder();
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if(counter==1){
				this.Clk=this.textBox1.Text;
				this.J=this.textBox2.Text;
				this.K=this.textBox3.Text;
				
				SettingClkarr(this.Clk);
				SettingJarr(this.J);
				Settingkarr(this.K);
				SettingQarr();
				SetQ();
				SetQperim();
				addcomp();	
			}
			if(radioButton1.Checked){
				this.textBox3.Text=this.textBox2.Text;
				this.label2.Text="T";
				this.label3.Text="T";
			}
				
			addcomp1();
			
			
			counter++;
		}
	
		private void SettingClkarr(string str){
			this.clkarr =new bool[str.Length];
			this.Right =new bool[str.Length];
			
			for(int i=0;i<str.Length;i++){
				this.clkarr[i]=(str.ToCharArray()[i]=='-');
			}
			
			this.Right[0]=false;
			for(int j=1;j<str.Length;j++){
				this.Right[j]=(this.clkarr[j])&&(!this.clkarr[j-1]);
				
			}
		}
		
	    private void Settingkarr(string str){
			this.karr =new bool[str.Length];
			
			for(int i=0;i<str.Length;i++){
				this.karr[i]=(str.ToCharArray()[i]=='-');
			}
	}
		
		private void SettingJarr(string str){
			    this.jarr =new bool[str.Length];
			
			   for(int i=0;i<str.Length;i++){
				this.jarr[i]=(str.ToCharArray()[i]=='-');
			  }
	}
		
		private void SettingQarr(){
			int minlen=Minimummlen(this.K,this.J,this.Clk);
			this.Qarr=new bool[this.K.Length];
			this.Qarr[0]=false;
		 for(int i=1;i<minlen;i++){
				if(this.Right[i]){
				
					if(!this.jarr[i]&&!this.karr[i]){
					this.Qarr[i]=this.Qarr[i-1];
					}
					
					if(this.jarr[i]&&!this.karr[i]){
						this.Qarr[i]=true;
						this.state.Append("Set ");
					}
					
					if(!this.jarr[i]&&this.karr[i]){
						this.Qarr[i]=false;
						this.state.Append("Reset ");
					}
					
					if(this.jarr[i]&&this.karr[i]){
						this.Qarr[i]=!this.Qarr[i-1];
						this.state.Append("Toggle ");
					}
					
				}
				else{
					this.Qarr[i]=this.Qarr[i-1];
				}
			  }
		}
		
		private int Minimummlen(string x,string y,string z){
			int min=(x.Length<y.Length)? x.Length:y.Length;
			int min1=(min<z.Length)? min:z.Length;
			
			return min1;
		}
		
		private void SetQ(){
		int minlen=Minimummlen(this.K,this.J,this.Clk);
		var sb=new StringBuilder();
		for(int i=0;i<minlen;i++){
			if(this.Qarr[i])
				sb.Append('-');
			else{
				sb.Append('_');
			}
		}
		
		this.Q=sb.ToString();
}
		
		private void SetQperim(){
			var re=new StringBuilder();
			
			foreach(char c in this.Q){
			if(c=='-')
				re.Append('_');
			else
				re.Append('-');
			}
			
			this.Qperim=re.ToString();
		}
		
		private void addcomp(){
				this.textBox4.Text=this.Q;
				
		     this.label5 = new Label();
			this.label5.Font = new Font("MV Boli", 13.8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new Point(275, 570);
			this.label5.Name = "label5";
			this.label5.Size = new Size(554, 559);
			this.label5.TabIndex = 5;
			this.label5.Text =this.state.ToString();
			this.Controls.Add(this.label5);
			
			this.label6 = new Label();
			this.label6.Font = new Font("MV Boli", 13.8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new Point(54, 485);
			this.label6.Name = "label6";
			this.label6.Size = new Size(30, 153);
			this.label6.TabIndex = 1;
			this.label6.Text = "Q'";
			this.Controls.Add(this.label6);
				
			
		    this.textBox5 = new TextBox();
			this.textBox5.Location = new Point(129, 475);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new Size(590, 42);
			this.textBox5.TabIndex = 6;
			this.Controls.Add(this.textBox5);
			this.textBox5.Text=this.Qperim;
		
		}
		
		private void addcomp1(){
				this.textBox4 = new TextBox();
			this.textBox4.Location = new Point(129, 359);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new Size(590, 44);
			this.textBox4.TabIndex = 6;
			this.Controls.Add(this.textBox4);
			
			this.label4 = new Label();
			this.label4.Font = new Font("MV Boli", 13.8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new Point(57, 364);
			this.label4.Name = "label4";
			this.label4.Size = new Size(54, 39);
			this.label4.TabIndex = 5;
			this.label4.Text = "Q";
			this.Controls.Add(this.label4);
		
		}
		
		void Label3Click(object sender, EventArgs e)
		{
	
		}
	
}
}
