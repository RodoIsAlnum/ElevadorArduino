using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elevador
{
    public partial class Form1 : Form
    {
        public SerialPort ard { get; set;  }
        public Form1()
        {
            InitializeComponent();
            ard = new SerialPort();
            ard.BaudRate = 9600;
            ard.DataBits = 8;
            ard.ReadTimeout = 500;
            ard.WriteTimeout = 500;
        }

        string sqlConnection = "server=localhost; port=3306; database=lift; uid=root; pwd=ligamaster21;";
        void insertRegistry(string action)
        {
            using (MySqlConnection connection = new MySqlConnection(sqlConnection))
            {
                connection.Open();

                string insertQuery = "insert into registry (action_Made, action_moment) " +
                    "values (@action, CURRENT_TIMESTAMP())";

                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@action", action);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        void loadSerialPorts()
        {
            cbPorts.Items.Clear();
            string [] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cbPorts.Items.Add(port);
            }

            if (cbPorts.Items.Count > 0)
            {
                cbPorts.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No se encontró ningun dispositivo Arduino");
            }
        }

        private void bttnConnect_Click(object sender, EventArgs e)
        {
            string selPort = cbPorts.SelectedItem.ToString();

            startConnection(selPort);
            insertRegistry("connected to ard");
        }

        private void BttnDisconnect_Click(object sender, EventArgs e)
        {
            if (ard.IsOpen) ard.Close(); 
            insertRegistry("disconnected from ard");
        }

        private void bttnRefresh_Click(object sender, EventArgs e)
        {
            loadSerialPorts();
        }


        void startConnection(string port)
        {
            try
            {
                ard.PortName = port;
                ard.Open();

                MessageBox.Show($"Conectado al puerto: {port}", "Conexión exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el puerto {port}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            

        }

        private void bttnOpenDoor_Click(object sender, EventArgs e)
        {
            ard.Write("a");
            insertRegistry("door opened");
            //Console.WriteLine(ard.ReadLine());
        }

        private void bttnCloseDoor_Click(object sender, EventArgs e)
        {
            ard.Write("b");
            insertRegistry("door closed");
            //  Console.WriteLine(ard.ReadLine());
        }

        private void bttnUp_Click(object sender, EventArgs e)
        {
            ard.Write("w");
            Console.WriteLine(ard.ReadLine());
            insertRegistry("elevator went up");
        }

        private void bttnDown_Click(object sender, EventArgs e)
        {
            ard.Write("f");
            Console.WriteLine(ard.ReadLine());
            insertRegistry("elevator went down");
        }
    }
}
