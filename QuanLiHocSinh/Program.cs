﻿using QuanLiHocSinh.DTO;

namespace QuanLiHocSinh
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            Application.Run(new frmQLHocSinh("3", "admin"));
        }
    }
}
