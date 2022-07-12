using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sysdemo
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public class general
        {
            // Definir variables con datos generales
            public static string xempresa = "Clínica Senati-Medic";
            public static string xdirec = "Av. 28 Julio 715";
            public static string xtelf = "622-3434";
            public static string añoperu = "Año del Bicentenario del Perú: 200 años de Independencia";
            public static string xusuario;
            public static string xrol;
            public static int xidrol;
            public static string xempleado;
        }
    }
}
