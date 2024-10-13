using Microsoft.UI.Xaml;
using SGDM_CFE.DataAccess;
using System;
using System.Data.SqlClient;

namespace SGDM_CFE.UI.Views
{
    public sealed partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            this.InitializeComponent();
            DatabaseConnection databaseConnection = new DatabaseConnection();
            try
            {
                var connection = databaseConnection.GetConnection();
                Console.WriteLine("Conexión exitosa a la base de datos.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
            
        }
    }
}