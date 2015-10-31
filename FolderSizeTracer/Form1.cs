/* 
 
 Aplicación de escritorio para localizar las carpetas con mayor ocupación de la Unidad lógica seleccionada
 Una Vez listadas con dobleclick sobre ella lanza el explorer a esa ubicación para que se pueda gestionar a mano el exceso de ocupación 
 
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderSizeTracer
{
    public partial class FST : Form
    {
        public static FST form = null;        
        
        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public FST()
        {
            InitializeComponent();
            form = this;
           
        }
        /// <summary>
        /// Al cargarse el formulario se buscan las unidades disponibles en el sistema.
        /// Se construye un radio button con cada una (se selecciona la primera) y se añade informaíón del espacio
        /// </summary>        
        private void FST_Load(object sender, EventArgs e)
        {                        
            int tt = 0;
            double freeSpace, totalSpace, percentFree;   
            tt = 0;
            foreach (var drive in System.IO.DriveInfo.GetDrives())
            {                
                if (drive.IsReady)
                {
                    RadioButton rButton = new RadioButton();
                    rButton.Name = "Drives";
                    rButton.Text = drive.Name;
                    rButton.Location = new Point(20, tt);                    
                    rButton.Width = 50;
                    if (tt == 0)
                    {
                        rButton.Checked = true;
                    }
                    rButton.CheckedChanged += delegate {
                        if (rButton.Checked)
                        {
                            LoadFirstFolders();
                        }
                    };
                    panUnits.Controls.Add(rButton);
                    freeSpace = drive.TotalFreeSpace / 1073741824; ;
                    totalSpace = drive.TotalSize / 1073741824;
                    percentFree = Math.Round((freeSpace / totalSpace) * 100,2);
                    Label lDriveInfo1 = new Label();
                    lDriveInfo1.Text = "Total:" + totalSpace + " Gb";
                    lDriveInfo1.Location = new Point(70, tt);
                    lDriveInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    lDriveInfo1.Height = rButton.Height;
                    lDriveInfo1.Width = 100;

                    Label lDriveInfo2 = new Label();
                    lDriveInfo2.Text = " - Libre: " + freeSpace + "Gb";
                    lDriveInfo2.Location = new Point(180, tt);
                    lDriveInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    lDriveInfo2.Height = rButton.Height;
                    lDriveInfo2.Width = 100;

                    Label lDriveInfo3 = new Label();
                    lDriveInfo3.Text = " " + percentFree + "% ";
                    lDriveInfo3.Location = new Point(290, tt);
                    lDriveInfo3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    lDriveInfo3.Height = rButton.Height;
                    lDriveInfo3.Width = 75;

                    panUnits.Controls.Add(lDriveInfo1);
                    panUnits.Controls.Add(lDriveInfo2);
                    panUnits.Controls.Add(lDriveInfo3);
                    tt += 20;
                }
            }

            LoadFirstFolders();
        }

      

        private void LoadFirstFolders()
        { 
            foreach (CheckBox oCheck in panelWindows.Controls.Find("Folders", true))
            {
                panelWindows.Controls.Remove(oCheck);
            }
            string sUnitAnalize="";
            int tt=0;
            //busca la unidad seleccionada
            foreach (RadioButton oBDrive in panUnits.Controls.Find("Drives", true))
            {
                if (oBDrive.Checked)
                {
                    sUnitAnalize = oBDrive.Text;
                    break;
                }
            }
            if (sUnitAnalize == "")
            {
                MessageBox.Show("No se ha localizado ningún origen válido para buscar carpetas");
                Form.ActiveForm.Refresh();
                return;
            }
            DirectoryInfo dMainDirectory = new DirectoryInfo(sUnitAnalize);                   
            //busca las las carpetas de primer nivel de la unidad
            foreach (DirectoryInfo dSubFolder in dMainDirectory.GetDirectories())
            {
                //Inserta un checkbox en el listado de carpetas 
                CheckBox rCheck = new CheckBox();
                rCheck.Name = "Folders";
                rCheck.Text = dSubFolder.Name;
                rCheck.Location = new Point(20, tt);
                rCheck.Width = 300;
                if ((dSubFolder.Name != "Windows") && (dSubFolder.Name.IndexOf("Program")<0))
                {
                    rCheck.Checked = true;
                }
                panelWindows.Controls.Add(rCheck);
                tt += 20;
            }

            
        }
        /// <summary>
        /// Acción que lanza el Análisis de espacio de la unidad seleccionada
        /// </summary>        
        private void btnAnalize_Click(object sender, EventArgs e)
        {
            form.dgwFolders.Rows.Clear();
            form.btnAnalize.Enabled = false;
            string sUnitAnalize = "";
             foreach (RadioButton oBDrive in  panUnits.Controls.Find("Drives",true)){

                 if (oBDrive.Checked) {
                     sUnitAnalize = oBDrive.Text;
                     break;
                 }
             }            
             if (sUnitAnalize != "")
             {                
                 DirectoryInfo dMainDirectory = new DirectoryInfo(sUnitAnalize);
                 TraceFolder(dMainDirectory, true);               
             }
             else
             {
                 MessageBox.Show("No se ha localizado ningún origen válido para analizar");
                 Form.ActiveForm.Refresh();
             }
            //ordena de mayor a menor ocupación
             form.dgwFolders.Sort(form.dgwFolders.Columns["Bytes"], ListSortDirection.Descending);
             form.btnAnalize.Enabled = true;
        }
        /// <summary>
        /// Analiza la carpeta que se le indique. Después analiza sus sucarpetas de manera recursiva.
        /// Recopila la información de los archivos que contenga: tamaño y número y
        /// llama al procedimiento que introduce un registro con esta información en la lista ordenada de mayor a menor       
        /// </summary>
        /// <param name="dFolder">Directorio a analizar</param>
        public static void TraceFolder(DirectoryInfo dFolder, bool bFirstLevel) {
            double dFilesSize = 0;
            string sSelectedFolders = "|";

            if (bFirstLevel){

                foreach (CheckBox oCheck in form.panelWindows.Controls.Find("Folders", true))
                {
                    if(oCheck.Checked){
                        sSelectedFolders += oCheck.Text + "|";
                    }
                }
                if (sSelectedFolders == "|")
                {
                    MessageBox.Show("Debe selecccionar al menos una carpeta de primer nivel para iniciar el análisis");
                    return;
                }
            }

            try
            {
                FileInfo[] oFiles = dFolder.GetFiles();
                foreach (FileInfo oFile in oFiles)
                {
                    dFilesSize += oFile.Length;
                }
                //Inserta un registro en el listado
                form.dgwFolders.Rows.Add(dFolder.FullName, SizeSuffix((Int64)dFilesSize), oFiles.Length, dFilesSize);

                //procesa las subcarpetas 
                foreach (DirectoryInfo dSubFolder in dFolder.GetDirectories())
                {
                    //si estamos en el primer nivel la carpeta debe estar entre las seleccioandas
                    if ((!bFirstLevel) || (sSelectedFolders.IndexOf("|" + dSubFolder.Name + "|") >= 0))
                    {
                        TraceFolder(dSubFolder,false);
                    }
                }
            }
            catch (UnauthorizedAccessException ex) 
            {
                //inserta la carpeta que no ha podido leer
            }
           
        
        }
        
        
       
        static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }
        private void dgwFolders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", form.dgwFolders.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            CheckFolders(false);
        }         

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            CheckFolders(true);
        }

        private void CheckFolders(bool p)
        {
            foreach (CheckBox oCheck in form.panelWindows.Controls.Find("Folders", true))
            {
                oCheck.Checked = p;
            }

        }

       
        
 
    }
}
