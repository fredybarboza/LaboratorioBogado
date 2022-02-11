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
using LaboratorioBogado.Estudios;
using System.Collections.ObjectModel;

namespace LaboratorioBogado
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConnectionDB conDB = new ConnectionDB();

        ObservableCollection<Hemograma> ListaHemograma = new ObservableCollection<Hemograma>();

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

            FechaActualLabel.Content = DateTime.Now.ToString("dd-MM-yyyy");

            edadTextBox.IsReadOnly = false;

            guardarTodoButton.Visibility = Visibility.Hidden;

            estudiosTabControl.Visibility = Visibility.Hidden;

            guardarButton.IsEnabled = false;

            buscarButton.IsEnabled = false;

            hemogramaGroupBox.Visibility = Visibility.Hidden;

            activarDesactivarDatos(true, 0.3);

            initHemograma(true, 0.3);

            //HISTORIAL
            nombreHistorialTextBox.IsReadOnly = true;
            apellidoHistorialTextBox.IsReadOnly = true;
            fechaNacHistorialTextBox.IsReadOnly = true;
            edadHistorialTextBox.IsReadOnly = true;

            buttonBuscarHistorial.IsEnabled = false;

            visibilityHistorialHemograma(false);



        }

        //HEMOGRAMA OPCION 1 CHECK BOX
        private void Opcion1CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            visibilityEstudios(true);
            tabItem1.Visibility = Visibility.Visible;
            grid1.Visibility = Visibility.Visible;
            allOptionsHemograma(true);
            initHemograma(false, 1.0);
        }

        private void Opcion1CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            tabItem1.Visibility = Visibility.Collapsed;
            grid1.Visibility = Visibility.Collapsed;
            allOptionsHemograma(false);
        }


        //METODO PARA INICIALIZAR HEMOGRAMA
        private void initHemograma(bool a, double o)
        {
            ActivarDesactivarHemoglobina(a, o);
            ActivarDesactivarHematocrito(a, o);
            ActivarDesactivarGR(a, o);
            ActivarDesactivarGB(a, o);
            ActivarDesactivarPlaquetas(a, o);
            ActivarDesactivarEritro(a, o);
            ActivarDesactivarNeutrofilos(a, o);
            ActivarDesactivarLinfocitos(a, o);
            ActivarDesactivarMonocitos(a, o);
            ActivarDesactivarEosinofilos(a, o);
            ActivarDesactivarBasofilos(a, o);
        }

        //METODO PARA OCULTAR EL TABITEM1 Y EL GRID1
        private void ocultarCargaHemograma()
        {
            tabItem1.Visibility = Visibility.Collapsed;
            grid1.Visibility = Visibility.Collapsed;
        }

        //FUNCION PARA MARCAR-DESMARCAR SUBOPCIONES DEL HEMOGRAMA
        private void allOptionsHemograma(bool a)
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

        //METODO PARA ACTIVAR PANEL DE ESTUDIOS DESDE SUBOPCIONES
        private void activarPenel1()
        {
            visibilityEstudios(true);
            //ocultarCargaHemograma();
            tabItem1.Visibility = Visibility.Visible;
            grid1.Visibility = Visibility.Visible;
        }

        //HEMOGLOBINA
        private void HemoglobinaCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            activarPenel1();
            ActivarDesactivarHemoglobina(false, 1.0);
        }

        private void HemoglobinaCheckBox_Unchecked(object sender, RoutedEventArgs e)
        { 
            hemoglobinaTextBox.Text = "";
            ActivarDesactivarHemoglobina(true, 0.3);
        }

        //HEMATOCRITO
        private void HematocritoCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            activarPenel1();
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
            activarPenel1();
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
            activarPenel1();
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
            activarPenel1();
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
            activarPenel1();
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
            activarPenel1();
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
            activarPenel1();
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
            activarPenel1();
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
            activarPenel1();
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
            activarPenel1();
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

            MySqlDataReader reade = conDB.ListSql("select ci from pacientes where ci=" + ciTextBox.Text);
            if (reade.Read()==false)
            {
                if (nombreTextBox.Text!=""&&apellidoTextBox.Text!=""&&fechaNacDatePicker.SelectedDate!=null&&edadTextBox.Text!="")
                {
                    if (masculinoRadioButton.IsChecked==true||femeninoRadioButton.IsChecked==true) {
                        sql = "INSERT INTO `pacientes` (`ci`,`nombre`, `apellido`,`fecha_nacimiento`, `edad`, `sexo`) VALUES ('" + ciTextBox.Text + "','" + nombreTextBox.Text + "', '" + apellidoTextBox.Text + "', '" + fechaNacDatePicker.SelectedDate.ToString() + "', '" + edadTextBox.Text + "', '" + s + "')";
                        conDB.ExecuteSQL(sql);
                    }
                }
                else
                {
                    MessageBox.Show("complete todos los datos");
                }
                
            }
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
        private void activarDesactivarDatos(bool a, double b)
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
                fechaNacDatePicker.IsEnabled = false;
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
                activarDesactivarDatos(true, 1.0);
            }
            else
            {
                clearInput();
                activarDesactivarDatos(false, 1.0);
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

            hemogramaGroupBox.Visibility = Visibility.Visible;
            
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            allOptionsHemograma(false);
            guardarTodoButton.Visibility = Visibility.Hidden;
            guardarButton.Visibility = Visibility.Visible;

            hemogramaGroupBox.Visibility = Visibility.Hidden;
            

            opcion1CheckBox.IsChecked = false;

            visibilityEstudios(false);
        }
        //VALIDACION DE DATOS HEMOGRAMA
        private int validacionHemograma()
        {
            int n = 0;
            if (hemoglobinaCheckBox.IsChecked == true) { if (hemoglobinaTextBox.Text == ""){ n = 1;} }

            if (hematocritoCheckBox.IsChecked == true) { if (hematocritoTextBox.Text == "") { n = 1; }}

            if (grCheckBox.IsChecked == true) { if (grTextBox.Text == ""){ n = 1;} }

            if (gbCheckBox.IsChecked == true) { if (gbTextBox.Text == "") { n = 1; } }

            if (plaquetasCheckBox.IsChecked == true) { if (plaquetasTextBox.Text == "") { n = 1; } }

            if(eritroCheckBox.IsChecked == true){ if (h1TextBox.Text==""||h2TextBox.Text==""){n = 1;}}

            if (neCheckBox.IsChecked == true) { if (neuTextBox.Text == "") { n = 1; } }

            if (linCheckBox.IsChecked==true) { if (linTextBox.Text == "") { n = 1; } }

            if(monoCheckBox.IsChecked==true) { if (monoTextBox.Text == "") { n = 1; } }

            if (eosCheckBox.IsChecked == true) { if (eoTextBox.Text == "") { n = 1; } }

            if(basoCheckBox.IsChecked == true) { if (basTextBox.Text == "") { n = 1; } }

            
            return n;
        }
        //GUARDAR HEMOGRAMA
        private void guardarHemograma()
        {
            int a = validacionHemograma();
            if (hemoglobinaTextBox.Text!=""||hematocritoTextBox.Text!=""||grTextBox.Text!=""||gbTextBox.Text!=""||plaquetasTextBox.Text!=""||eritroCheckBox.IsChecked==true||neuTextBox.Text!=""||linTextBox.Text!=""||monoTextBox.Text!=""||eoTextBox.Text!=""||basTextBox.Text!="") {

                if (a!=1) {
                    string sql = "";
                    sql = "INSERT INTO `hemogramas` (`id`, `hemoglobina`, `hematocrito`, `gr`, `gb`, `plaquetas`, `eritro1h`, `eritro2h`, `neutrofilos`, `linfocitos`, `monocitos`, `eosinofilos`, `basofilos`, `observacion`) VALUES ('" + ciTextBox.Text + "', '" + hemoglobinaTextBox.Text + "', '" + hematocritoTextBox.Text + "', '" + grTextBox.Text + "', '" + gbTextBox.Text + "', '" + plaquetasTextBox.Text + "', '" + h1TextBox.Text + "', '" + h2TextBox.Text + "', '" + neuTextBox.Text + "', '" + linTextBox.Text + "', '" + monoTextBox.Text + "', '" + eoTextBox.Text + "', '" + basTextBox.Text + "', '" + observacionTextBox.Text + "')";
                    conDB.ExecuteSQL(sql);
                }
                else
                {
                    MessageBox.Show("FUNCIONA");
                }

            }
            else
            {
                MessageBox.Show("COMPLETE TODOS LOS CAMPOS");
            }
        }

        //GUARDAR TODO BUTTON
        private void GuardarTodoButton_Click(object sender, RoutedEventArgs e)
        {
            guardarHemograma();
            guardarPaciente();
        }

        private void CiTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (ciTextBox.Text == "")
            {
                guardarButton.IsEnabled = false;
                guardarTodoButton.IsEnabled = false;
                buscarButton.IsEnabled = false;
            }
            else
            {
                guardarButton.IsEnabled = true;
                guardarTodoButton.IsEnabled = true;
                buscarButton.IsEnabled = true;
            }
            activarDesactivarDatos(true, 0.3);
            clearInput();
        }


        /*------------HISTORIAL--------*/

        private void clearDateHistorial()
        {
            nombreHistorialTextBox.Text = "";
            apellidoHistorialTextBox.Text = "";
            fechaNacHistorialTextBox.Text = "";
            edadHistorialTextBox.Text = "";
        }

        private void visibilityHistorialHemograma(bool a)
        {
            if (a == false) {
                historialTabControl.Visibility = Visibility.Hidden;
                hemogramaHistorialTabItem.Visibility = Visibility.Hidden;
                gridHemogramaHistorial.Visibility = Visibility.Hidden;
            }
            else
            {
                historialTabControl.Visibility = Visibility.Visible;
                hemogramaHistorialTabItem.Visibility = Visibility.Visible;
                gridHemogramaHistorial.Visibility = Visibility.Visible;
            }
        }

        private void getHistorialHemograma()
        {
            MySqlDataReader reade = conDB.ListSql("select id, hemoglobina, hematocrito, gr, gb, plaquetas, eritro1h, eritro2h, neutrofilos, linfocitos, monocitos, eosinofilos,  basofilos, observacion from hemogramas where id=" + ciHistorialTextBox.Text);

                while (reade.Read())
                {
                    visibilityHistorialHemograma(true);

                    Hemograma h = new Hemograma();
                    h.Id = reade.GetValue(0).ToString();
                    h.Hemoglobina = reade.GetValue(1).ToString();
                    h.Hematocrito = reade.GetValue(2).ToString();
                    h.Gr = reade.GetValue(3).ToString();
                    h.Gb = reade.GetValue(4).ToString();
                    h.Plaquetas = reade.GetValue(5).ToString();
                    h.Eritro1h = reade.GetValue(6).ToString();
                    h.Eritro2h = reade.GetValue(7).ToString();
                    h.Neutrofilos = reade.GetValue(8).ToString();
                    h.Linfocitos = reade.GetValue(9).ToString();
                    h.Monocitos = reade.GetValue(10).ToString();
                    h.Eosinofilos = reade.GetValue(11).ToString();
                    h.Basofilos = reade.GetValue(12).ToString();
                    h.Observacion = reade.GetValue(13).ToString();

                    ListaHemograma.Add(h);

                    hemogramaDataGrid.Items.Add(ListaHemograma);

                }
            
        }

        private void ButtonBuscarHistorial_Click(object sender, RoutedEventArgs e)
        {
            visibilityHistorialHemograma(false);

            clearDateHistorial();

            int n = 0;
            MySqlDataReader reade = conDB.ListSql("select nombre, apellido, fecha_nacimiento, edad from pacientes where ci=" + ciHistorialTextBox.Text);
            while (reade.Read())
            {
                nombreHistorialTextBox.Text = reade.GetValue(0).ToString();
                apellidoHistorialTextBox.Text = reade.GetValue(1).ToString();
                fechaNacHistorialTextBox.Text = reade.GetValue(2).ToString();
                edadHistorialTextBox.Text = reade.GetValue(3).ToString();
                n = 1;
            }

            getHistorialHemograma();

            if (n==0)
            {
                MessageBox.Show("SIN COINCIDENCIAS");
            }
            
            
            
        }

        private void CiHistorialTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (ciHistorialTextBox.Text == "")
            {
                buttonBuscarHistorial.IsEnabled = false;
            }
            else
            {
                buttonBuscarHistorial.IsEnabled = true;
            }
        }

        /*----------FIN HISTORIAL----*/
    }
}
