using HomeW_WF_Ado_31._08._2021.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeW_WF_Ado_31._08._2021
{
    public partial class Form1 : Form
    {
        ApplicationContext context = new ApplicationContext(); 
        public Form1()
        {
            
            InitializeComponent();


            //Use your DB , because my loccalDB has unstandart name

            //Use the code near in first code generation to get the same DB datas

            //Position ps = new Position("Manager", null);
            //Position ps2 = new Position("Director", null);
            //Position ps3 = new Position("CEO", null);
            //Position ps4 = new Position("Junior", null);
            //Position ps5 = new Position("Senior", null);
            //Position ps6 = new Position("Middle", null);
            //context.Positions.Add(ps);
            //context.Positions.Add(ps2);
            //context.Positions.Add(ps3);
            //context.Positions.Add(ps4);
            //context.Positions.Add(ps5);
            //context.Positions.Add(ps6);
            //context.SaveChanges();


            foreach (var item in context.Positions)
            {
               cmbPosition.Items.Add(item.Name);
            }
            cmbPosition.SelectedIndex = 3;
            foreach (var item in context.Positions)
            {
                cmbUpdatePosition.Items.Add(item.Name);
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int age = 0;
            Position ps = new Position();
            try
            {
                age = Convert.ToInt32(tbxAge.Text);
                foreach (Position item in context.Positions)
                {
                    if(item.Name == (cmbPosition.SelectedItem as string))
                    {
                        ps = item;
                    }
                }
            }
            catch(Exception ex )
            {
                Console.WriteLine(ex);
                return;
            }
            Employee emp = new Employee
            {
                Name = tbxName.Text,
                Surname = tbxSurname.Text,
                Age = age,
                Position = ps
            };
            foreach (Position item in context.Positions)
            {
                if (ps == item)
                {
                    item.Employees.Add(emp);
                }
            }
            context.Employees.Add(emp);
            context.SaveChanges();

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
            foreach (var item in context.Employees)
            {
                MessageBox.Show($"Id : {item.Id} , Name : {item.Name} , Lastname : {item.Surname} , Age : {item.Age} , Position : {item.Position.Name}","Employee",MessageBoxButtons.OK);
                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int DelId = Convert.ToInt32(tbxDeleteId.Text);
                foreach (var item in context?.Employees)
                {
                    if (item.Id == DelId)
                    {
                        context.Employees.Remove(item);
                        break;
                        
                    }
                }                
                context.SaveChanges();
                tbxDeleteId.Text = "";
                return;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                
                int UpdId = Convert.ToInt32(tbxId.Text);
                foreach (var item in context?.Employees)
                {
                    if (item.Id == UpdId)
                    {
                        var NewItem = item;
                        
                        if (tbxUpdateAge.Text != null) {
                            item.Age = Convert.ToInt32(tbxUpdateAge.Text);
                        }
                        if (tbxUpdateName.Text != null)
                        {
                            item.Name = tbxUpdateName.Text;
                        }
                        if (tbxUpdateSurname.Text != null)
                        {
                            item.Surname = tbxUpdateSurname.Text;
                        }
                        if (cmbUpdatePosition.SelectedItem != null)
                        {
                            foreach (var position in context?.Positions)
                            {
                                if(position.Name == cmbUpdatePosition.SelectedItem.ToString())
                                {
                                    item.Position = position; 
                                }
                            }
                        }               
                        
                        

                    }
                }
                context.SaveChanges();
                tbxId.Text = "";
                tbxUpdateAge.Text = "";
                tbxUpdateName.Text = "";
                tbxUpdateSurname.Text = "";
                cmbUpdatePosition.SelectedItem = null;
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }
    }
}
