using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LaboratorioBogado.Utils;
using MySql.Data.MySqlClient;

namespace LaboratorioBogado
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConnectionDB conDB = new ConnectionDB();

        public MainWindow()
        {
            InitializeComponent();
            InitData();
            
        }

        void InitData()
        {
            //TabItem
            tabItem1.Visibility = Visibility.Collapsed;
            tabItem2.Visibility = Visibility.Collapsed;
            tabItem3.Visibility = Visibility.Collapsed;
            tabItem4.Visibility = Visibility.Collapsed;
            //GRIDS
            grid1.Visibility = Visibility.Collapsed;
            grid2.Visibility = Visibility.Collapsed;
            grid3.Visibility = Visibility.Collapsed;
            grid4.Visibility = Visibility.Collapsed;

            DisabledSubOptions(false);

            FechaActualLabel.Content = DateTime.Now.ToString("dd-MM-yyyy");

            edadTextBox.IsReadOnly = false;

            guardarTodoButton.Visibility = Visibility.Hidden;

            estudiosTabControl.Visibility = Visibility.Hidden;

            

            //DESACTIVA LOS DATOS PERSONALES
            nombreTextBox.IsReadOnly = true;
            nombreTextBox.Opacity = 0.3;
            nombreLabel.Opacity = 0.3;
            apellidoTextBox.IsReadOnly = true;
            apellidoTextBox.Opacity = 0.3;
            apellidoLabel.Opacity = 0.3;
            fechaNacLabel.Opacity = 0.3;
            fechaNacDatePicker.IsEnabled = false;
            edadLabel.Opacity = 0.3;
            edadTextBox.IsReadOnly = true;
            edadTextBox.Opacity = 0.3;
            femeninoRadioButton.Opacity = 0.3;
            masculinoRadioButton.Opacity = 0.3;
            sexoLabel.Opacity = 0.3;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Opcion1CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            tabItem1.Visibility = Visibility.Visible;
            grid1.Visibility = Visibility.Visible;
            SelectedOptionsHemograma(true);
            DisabledSubOptions(true);

        }

        //FUNCIONES PARA DESHABILITAR SUBOPCIONES
        private void DisabledSubOptions(bool a)
        {
            hemoglobinaCheckBox.IsEnabled = a;
            hematocritoCheckBox.IsEnabled = a;
            grCheckBox.IsEnabled = a;
            gbCheckBox.IsEnabled = a;
            plaquetasCheckBox.IsEnabled = a;
            eritroCheckBox.IsEnabled = a;
            neCheckBox.IsEnabled = a;
            linCheckBox.IsEnabled = a;
            monoCheckBox.IsEnabled = a;
            eosCheckBox.IsEnabled = a;
            basoCheckBox.IsEnabled = a;
        } 

        //FUNCION PARA MARCAR-DESMARCAR OPCIONES DEL HEMOGRAMA
        private void SelectedOptionsHemograma(bool a)
        {
            hemoglobinaCheckBox.IsChecked = a;
            hematocritoCheckBox.IsChecked = a;
            grCheckBox.IsChecked = a;
            gbCheckBox.IsChecked = a;
            plaquetasCheckBox.IsChecked = a;
            eritroCheckBox.IsChecked = a;
            neCheckBox.IsChecked = a;
            linCheckBox.IsChecked = a;
            monoCheckBox.IsChecked = a;
            eosCheckBox.IsChecked = a;
            basoCheckBox.IsChecked = a;
        }

        private void Opcion2CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            tabItem2.Visibility = Visibility.Visible;
            grid2.Visibility = Visibility.Visible;
        }

        private void Opcion3CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            tabItem3.Visibility = Visibility.Visible;
            grid3.Visibility = Visibility.Visible;
        }

        private void Opcion4CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            tabItem4.Visibility = Visibility.Visible;
            grid4.Visibility = Visibility.Visible;
        }

        private void Opcion1CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            tabItem1.Visibility = Visibility.Collapsed;
            grid1.Visibility = Visibility.Collapsed;
            SelectedOptionsHemograma(false);
            DisabledSubOptions(false);
        }

        private void Opcion2CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            tabItem2.Visibility = Visibility.Collapsed;
            grid2.Visibility = Visibility.Collapsed;
        }

        private void Opcion3CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            tabItem3.Visibility = Visibility.Collapsed;
            grid3.Visibility = Visibility.Collapsed;
        }

        private void Opcion4CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            tabItem4.Visibility = Visibility.Collapsed;
            grid4.Visibility = Visibility.Collapsed;
        }



        //FUNCIONES PARA HABILITAR Y DESHABILITAR LAS OPCIONES INDIVIDUALES

        private void ActivarDesactivarHemoglobina(bool a, double b)
        {
            hemoglobinaTextBox.IsReadOnly = a;
            hemoglobinaTextBox.Opacity = b;
            hemoglobinaLabel.Opacity = b;
            u1.Opacity = b;
            vr1.Opacity = b;
        }
        
        private void ActivarDesactivarHematocrito(bool a, double b)
        {
            hematocritoTextBox.IsReadOnly = a;
            hematocritoTextBox.Opacity = b;
            hematocritoLabel.Opacity = b;
            u2.Opacity = b;
            vr2.Opacity = b;
        }

        private void ActivarDesactivarGR(bool a, double b)
        {
            grTextBox.IsReadOnly = a;
            grTextBox.Opacity = b;
            grLabel.Opacity = b;
            u3.Opacity = b;
            vr3.Opacity = b;
        }

        private void ActivarDesactivarGB(bool a, double b)
        {
            gbTextBox.IsReadOnly = a;
            gbTextBox.Opacity = b;
            gbLabel.Opacity = b;
            u4.Opacity = b;
            vr4.Opacity = b;
        }

        private void ActivarDesactivarPlaquetas(bool a, double b)
        {
            plaquetasTextBox.IsReadOnly = a;
            plaquetasTextBox.Opacity = b;
            plaquetasLabel.Opacity = b;
            u5.Opacity = b;
            vr5.Opacity = b;
        }

        private void ActivarDesactivarEritro(bool a, double b)
        {
            h1TextBox.IsReadOnly = a;
            h2TextBox.IsReadOnly = a;
            h1TextBox.Opacity = b;
            h2TextBox.Opacity = b;
            eritroLabel.Opacity = b;
            u6.Opacity = b;
            u7.Opacity = b;
        }

        private void ActivarDesactivarNeutrofilos(bool a, double b)
        {
            neuTextBox.IsReadOnly = a;
            neuTextBox.Opacity = b;
            neuLabel.Opacity = b;
            u8.Opacity = b;
        }

        private void ActivarDesactivarLinfocitos(bool a, double b)
        {
            linTextBox.IsReadOnly = a;
            linTextBox.Opacity = b;
            linLabel.Opacity = b;
            u9.Opacity = b;
        }

        private void ActivarDesactivarMonocitos(bool a, double b)
        {
            monoTextBox.IsReadOnly = a;
            monoTextBox.Opacity = b;
            monoLabel.Opacity = b;
            u10.Opacity = b;
        }

        private void ActivarDesactivarEosinofilos(bool a, double b)
        {
            eoTextBox.IsReadOnly = a;
            eoTextBox.Opacity = b;
            eoLabel.Opacity = b;
            u11.Opacity = b;
        }

        private void ActivarDesactivarBasofilos(bool a, double b)
        {
            basTextBox.IsReadOnly = a;
            basTextBox.Opacity = b;
            basLabel.Opacity = b;
            u12.Opacity = b;
        }

        //HEMOGLOBINA
        private void HemoglobinaCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            hemoglobinaTextBox.Text = "";
            ActivarDesactivarHemoglobina(true, 0.3);
        }

        private void HemoglobinaCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ActivarDesactivarHemoglobina(false, 1.0);
        }

        //HEMATOCRITO
        private void HematocritoCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ActivarDesactivarHematocrito(false, 1.0);
        }

        private void HematocritoCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            hematocritoTextBox.Text = "";
            ActivarDesactivarHematocrito(true, 0.3);
        }

        //GLOBULOS ROJOS
        private void GrCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ActivarDesactivarGR(false, 1.0);
        }

        private void GrCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            grTextBox.Text = "";
            ActivarDesactivarGR(true, 0.3);
        }

        //GLOBULOS BLANCOS
        private void GbCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ActivarDesactivarGB(false, 1.0);
        }

        private void GbCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            gbTextBox.Text = "";
            ActivarDesactivarGB(true, 0.3);
        }

        //PLAQUETAS
        private void PlaquetasCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ActivarDesactivarPlaquetas(false, 1.0);
        }

        private void PlaquetasCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            plaquetasTextBox.Text = "";
            ActivarDesactivarPlaquetas(true, 0.3);
        }


        //ERITROSEDIMENTACION
        private void EritroCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ActivarDesactivarEritro(false, 1.0);
        }

        private void EritroCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            h1TextBox.Text = "";
            h2TextBox.Text = "";
            ActivarDesactivarEritro(true, 0.3);
        }

        //NEUTRÓFILOS
        private void NeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ActivarDesactivarNeutrofilos(false, 1.0);
        }

        private void NeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            neuTextBox.Text = "";
            ActivarDesactivarNeutrofilos(true, 0.3);
        }

        //LINFOCITOS
        private void LinCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ActivarDesactivarLinfocitos(false, 1.0);
        }

        private void LinCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            linTextBox.Text = "";
            ActivarDesactivarLinfocitos(true, 0.3);
        }

        //MONOCITOS
        private void MonoCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ActivarDesactivarMonocitos(false, 1.0);
        }

        private void MonoCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            monoTextBox.Text = "";
            ActivarDesactivarMonocitos(true, 0.3);
        }


        //EOSINOFILOS
        private void EosCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ActivarDesactivarEosinofilos(false, 1.0);
        }

        private void EosCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            eoTextBox.Text = "";
            ActivarDesactivarEosinofilos(true, 0.3);
        }

        //BASOFILOS
        private void BasoCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ActivarDesactivarBasofilos(false, 1.0);
        }

        private void BasoCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            basTextBox.Text = "";
            ActivarDesactivarBasofilos(true, 0.3);
        }

        /*---------------------------------------------------------*/

        public string returnMF()
        {
            if (masculinoRadioButton.IsChecked == true)
            {
                string s = "M";
                return s;
            }
            else
            {
                string s = "F";
                return s;
            }
        }



        //METODO PARA GUARDAR PACIENTE
        private void guardarPaciente()
        {
            string sql = "";
            string s = returnMF();

            sql = "INSERT INTO `pacientes` (`ci`,`nombre`, `apellido`,`fecha_nacimiento`, `edad`, `sexo`) VALUES ('" + ciTextBox.Text + "','" + nombreTextBox.Text + "', '" + apellidoTextBox.Text + "', '" + fechaNacDatePicker.SelectedDate.ToString() + "', '" + edadTextBox.Text + "', '" + s + "')";
            conDB.ExecuteSQL(sql);
        }

        //GUARDAR BUTTON
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            guardarPaciente();
        }

        //LIMPIAR DATOS
        void clearInput()
        {
            nombreTextBox.Text = "";
            apellidoTextBox.Text = "";
            edadTextBox.Text = "";
            fechaNacDatePicker.SelectedDate = null;
        }

        //ACTIVAR Y DESACTIVAR CARGA DE DATOS PERSONALES
        private void activarDesacticarDatos(bool a, double b)
        {
            //nombre
            nombreLabel.Opacity = b;
            nombreTextBox.IsReadOnly = a;
            nombreTextBox.Opacity = b;
            //apellido
            apellidoLabel.Opacity = b;
            apellidoTextBox.IsReadOnly = a;
            apellidoTextBox.Opacity = b;
            //edad
            edadLabel.Opacity = b;
            edadTextBox.IsReadOnly = a;
            edadTextBox.Opacity = b;
            //sexo
            sexoLabel.Opacity = b;
            masculinoRadioButton.Opacity = b;
            femeninoRadioButton.Opacity = b;
            //fecha_nacimiento
            fechaNacLabel.Opacity = b;

            if (a == true)
            {
                masculinoRadioButton.IsEnabled = false;
                femeninoRadioButton.IsEnabled = false;
            }
            else
            {
                masculinoRadioButton.IsEnabled = true;
                femeninoRadioButton.IsEnabled = true;
            }
            
            //fecha de nacimiento
            if (a == false)
            {
                fechaNacDatePicker.IsEnabled = true;
            }
            
        }

        //BUSCAR BUTTON
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string ci = ciTextBox.Text;
            int c = 0;
            MySqlDataReader reade = conDB.ListSql("select nombre, apellido, edad, fecha_nacimiento, sexo from pacientes where ci=" + ci);

            while (reade.Read())
            {
                nombreTextBox.Text = reade.GetValue(0).ToString();
                apellidoTextBox.Text = reade.GetValue(1).ToString();
                edadTextBox.Text = reade.GetValue(2).ToString();
                fechaNacDatePicker.SelectedDate = Convert.ToDateTime(reade.GetValue(3).ToString());
                string s = reade.GetValue(4).ToString();
                if (s == "M")
                {
                    masculinoRadioButton.IsChecked = true;
                }
                else
                {
                    femeninoRadioButton.IsChecked = true;
                }

                c = 1;
            }

            if (c == 1)
            {
                activarDesacticarDatos(true, 1.0);
            }
            else
            {
                clearInput();
                activarDesacticarDatos(false, 1.0);
            }
            
            

                
            
        }

        //VISIBILIDAD DE ESTUDIOS
        private void visibilityEstudios(bool a)
        {
            if (a == false)
            {
                estudiosTabControl.Visibility = Visibility.Hidden;
            }
            else
            {
                estudiosTabControl.Visibility = Visibility.Visible;
            }
        }
            
        //RESULTADOS CHECKBOX
        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            guardarButton.Visibility = Visibility.Hidden;
            guardarTodoButton.Visibility = Visibility.Visible;
            visibilityEstudios(true);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            guardarTodoButton.Visibility = Visibility.Hidden;
            guardarButton.Visibility = Visibility.Visible;
            visibilityEstudios(false);
        }

        //GUARDAR TODO BUTTON
        private void GuardarTodoButton_Click(object sender, RoutedEventArgs e)
        {
            guardarPaciente();
            string sql = "";
            sql = "INSERT INTO `hemogramas` (`id`, `hemoglobina`, `hematocrito`, `gr`, `gb`, `plaquetas`, `eritro1h`, `eritro2h`, `neutrofilos`, `linfocitos`, `monocitos`, `eosinofilos`, `basofilos`, `observacion`) VALUES ('" + ciTextBox.Text + "', '" + hemoglobinaTextBox.Text + "', '" + hematocritoTextBox.Text + "', '" + grTextBox.Text + "', '" + gbTextBox.Text + "', '" + plaquetasTextBox.Text + "', '" + h1TextBox.Text + "', '" + h2TextBox.Text + "', '" + neuTextBox.Text + "', '" + linTextBox.Text + "', '" + monoTextBox.Text + "', '" + eoTextBox.Text + "', '" + basTextBox.Text + "', '" + observacionTextBox.Text +"')";
            conDB.ExecuteSQL(sql);
        }

        private void CiTextBox_KeyUp(object sender, KeyEventArgs e)
        {
                activarDesacticarDatos(true, 0.3);
                clearInput();
        }
    }
}
